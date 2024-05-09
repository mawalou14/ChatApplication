using BaseLibrary.DTO.ApplicationUserDTOs;
using BaseLibrary.DTO.messageDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http;

namespace ChatApplicationClient.Components.Pages
{
    public partial class Home
    {
        [CascadingParameter]
        public HubConnection ApplicationHub { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ApplicationHub != null && ApplicationHub.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await ApplicationHub.StartAsync();
                }
                catch
                {

                }
            }
        }
    }

}



//@code {

//    // Inject an HttpClient to make API calls
//    [Inject]
//private HttpClient httpClient { get; set; }

//private HubConnection? hubConnection;

//private List<GetMessageDTO> messages;
//private List<GetApplicationUsersDTO> users;
//private Guid selectedUserId;
//private string messageText;
//private DateTime Date = DateTime.Now;

//protected override async Task OnInitializedAsync()
//{
//    // Load messages and users from the API
//    await GetUsersFromAPI();
//    await GetMessagesFromAPI();

//    // Initialize SignalR connection
//    hubConnection = new HubConnectionBuilder()
//        .WithUrl(NavManager.ToAbsoluteUri("/chatHub"))
//        .Build();

//    // Start the SignalR connection
//    // await hubConnection.StartAsync();

//    hubConnection.On<string, string, DateTime>("RecieveMessage", async (UserName, Message, Date) =>
//    {
//        await GetMessagesFromAPI();
//    });
//}

//private async Task<List<GetMessageDTO>?> GetMessagesFromAPI()
//{
//    try
//    {
//        // Use HttpClient to call your API and retrieve data
//        var response = await httpClient.GetAsync("api/message");
//        if (response.IsSuccessStatusCode)
//        {
//            return messages = await response.Content.ReadFromJsonAsync<List<GetMessageDTO>>();
//        }
//        else
//        {
//            // Handle errors here
//            return new List<GetMessageDTO>();
//        }
//    }
//    catch (Exception ex)
//    {
//        // Handle exceptions here
//        Console.WriteLine($"Error during the API call: {ex.Message}");
//        return new List<GetMessageDTO>();
//    }
//}

//private async Task<List<GetApplicationUsersDTO>?> GetUsersFromAPI()
//{
//    try
//    {
//        // Use HttpClient to call your API and retrieve data
//        var response = await httpClient.GetAsync("api/user");
//        if (response.IsSuccessStatusCode)
//        {
//            return users = await response.Content.ReadFromJsonAsync<List<GetApplicationUsersDTO>>();
//        }
//        else
//        {
//            // Handle errors here
//            return new List<GetApplicationUsersDTO>();
//        }
//    }
//    catch (Exception ex)
//    {
//        // Handle exceptions here
//        Console.WriteLine($"Error during the API call: {ex.Message}");
//        return new List<GetApplicationUsersDTO>();
//    }
//}

//// To verify if the hub is connected
//// private bool IsConnected =>
//// hubConnection!.State == HubConnectionState.Connected;

//private async Task SendMessage()
//{
//    try
//    {
//        var messageDTO = new AddMessageDTO
//        {
//            Message = messageText,
//            ApplicationUserId = selectedUserId
//        };

//        var response = await httpClient.PostAsJsonAsync("api/message", messageDTO);
//        if (response.IsSuccessStatusCode)
//        {
//            await hubConnection!.SendAsync("SendMessage", "Mouhamadou", "awalou@gmail.com", Date);
//            messageText = "";
//        }
//        else
//        {
//            Console.WriteLine("Failed to send message.");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Error sending message: {ex.Message}");
//    }
//}
//}


