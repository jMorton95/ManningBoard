using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class LineHub : Hub
    {
        private readonly ILineService _lineService;
        public LineHub(ILineService lineService)
        {
          _lineService = lineService;
        }
        public async Task PushLineState()
        {
            LineStateDTO lineStateDTO = await _lineService.GetLineState();
            await Clients.All.SendAsync("LineStateUpdate", lineStateDTO);
        }
    }
}