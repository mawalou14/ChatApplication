using Microsoft.AspNetCore.SignalR.Client;

namespace ChatApplicationClient.Extension
{
    public static class HubExtensions
    {
        public static async Task KeppAlive(this HubConnection hubConnection)
        {
            if (hubConnection != null && hubConnection.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await hubConnection.StartAsync();
                }
                catch
                {

                }
            }
        }
    }
}
