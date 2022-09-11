using Microsoft.AspNetCore.SignalR;

namespace SignalRSample
{
    public class MyHub: Hub
    { 
        private static int _total = 0;

        public async Task Send(int i)
        {
            //_total+= i;
            int total = Interlocked.Add(ref _total, i);           
            await Clients.Others.SendAsync("CountNotification", $"Total = {total}");
        }
    }
}
