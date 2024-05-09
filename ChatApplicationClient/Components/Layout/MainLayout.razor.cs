using BaseLibrary.DTO.ApplicationUserDTOs;
using BaseLibrary.DTO.messageDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;

namespace ChatApplicationClient.Components.Layout
{
    public partial class MainLayout
    {
        [Inject] private IConfiguration Configuration { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }

        public HubConnection ApplicationHub {  get; set; }

        protected override async Task OnInitializedAsync()
        {

            var url = Configuration["chathub"];
            ApplicationHub = new HubConnectionBuilder().WithUrl(url).Build();
            ApplicationHub.On<DateTime>("RecieveMessage", date => 
            {
                Snackbar.Add("New message", Severity.Info);
            });

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
