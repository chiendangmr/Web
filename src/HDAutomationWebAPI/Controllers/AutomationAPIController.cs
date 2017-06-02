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
        [HttpGet]
        [Route("Playlist/{sectorId}")]
        public IEnumerable<PlayList> GetPlaylists(int sectorId)
        {
            return _context.PlayList.Where(m => m.SystemId == sectorId).Where(m => m.DateList >= DateTime.Now.Date).ToList();
        }
        [HttpPost]
        public IActionResult CreatePlaylist([FromBody]PlayList item)
        {
            if (item == null) return BadRequest();
            _context.PlayList.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetPlaylists", new { sectorId = item.SystemId }, item);
        }
        //PlaylistItems
        [HttpGet]
        [Route("PlaylistItem/{playlistId}")]
        public IEnumerable<PlayListItem> GetPlaylistItems(int playlistId)
        {
            return _context.PlayListItem.Where(m => m.ListId == playlistId).ToList();
        }
        //CG_Playlist_Item
        [HttpGet]
        public IEnumerable<TblCgPlaylistItem> GetCGPlaylistItems(long playlistItemId)
        {
            return _context.TblCgPlaylistItem.Where(m => m.PlaylistItemId == playlistItemId).ToList();
        }
    }
}
