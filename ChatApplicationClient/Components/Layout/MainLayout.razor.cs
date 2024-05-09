using BaseLibrary.DTO.ApplicationUserDTOs;
using BaseLibrary.DTO.messageDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System.Net.Http;

namespace ChatApplicationClient.Components.Layout
{
    public partial class MainLayout
    {
        [Inject] private IConfiguration Configuration { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }

        public HubConnection ApplicationHub {  get; set; }

        [Inject]
        private HttpClient httpClient { get; set; }

        private List<GetMessageDTO> messages;
        private List<GetApplicationUsersDTO> users;
        private Guid selectedUserId;
        private string messageText;
        private DateTime Date = DateTime.Now;

        private async Task<List<GetMessageDTO>?> GetMessagesFromAPI()
        {
            try
            {
                // Use HttpClient to call your API and retrieve data
                var response = await httpClient.GetAsync("api/message");
                if (response.IsSuccessStatusCode)
                {
                    return messages = await response.Content.ReadFromJsonAsync<List<GetMessageDTO>>();
                }
                else
                {
                    // Handle errors here
                    return new List<GetMessageDTO>();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine($"Error during the API call: {ex.Message}");
                return new List<GetMessageDTO>();
            }
        }

        private async Task<List<GetApplicationUsersDTO>?> GetUsersFromAPI()
        {
            try
            {
                // Use HttpClient to call your API and retrieve data
                var response = await httpClient.GetAsync("api/user");
                if (response.IsSuccessStatusCode)
                {
                    return users = await response.Content.ReadFromJsonAsync<List<GetApplicationUsersDTO>>();
                }
                else
                {
                    // Handle errors here
                    return new List<GetApplicationUsersDTO>();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine($"Error during the API call: {ex.Message}");
                return new List<GetApplicationUsersDTO>();
            }
        }
    }
}
