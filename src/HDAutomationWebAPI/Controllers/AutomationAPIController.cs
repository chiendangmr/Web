using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HDAutomationWebAPI.Data;
using HDAutomationWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HDAutomationWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AutomationAPIController : Controller
    {
        private readonly HDStationPS_V4Context _context;
        public AutomationAPIController(HDStationPS_V4Context context)
        {
            _context = context;
        }
        //Playlist
        [HttpGet("{sectorId}", Name = "GetPlaylists")]
        public IEnumerable<PlayList> GetPlaylists(int sectorId)
        {
            return _context.PlayList.Where(m => m.SystemId == sectorId).Where(m => m.DateList >= DateTime.Now.Date).ToList();
        }
        //PlaylistItems
        [HttpGet]
        public IEnumerable<PlayListItem> GetPlaylistItems(int playlistId)
        {
            return _context.PlayListItem.Where(m => m.ListId == playlistId).ToList();
        }
    }
}
