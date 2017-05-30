using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HDAutomation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using HDAutomation.Models;


namespace HDAutomation.Controllers
{
    public class OnAirController : Controller
    {
        private readonly HDStationPS_V4Context _context;
        private readonly Sector _sector;        

        public OnAirController(HDStationPS_V4Context context, IOptions<Sector> sector)
        {
            _sector = sector.Value;
            _context = context;
        }

        public IActionResult Index()
        {
            var sectorId = _sector.SectorID;
            var items = GetPlaylistItems(GetPlaylist(sectorId).Where(m => m.DateList.Date == DateTime.Now.Date).FirstOrDefault().ListId);
            var lstItems = new List<ItemViewModel>();
            foreach (var temp in items)
            {
                var tape = GetInforTape(temp.Idclip);
                lstItems.Add(new ItemViewModel()
                {
                    ProgramName = tape.Tenchuongtrinh,
                    FileName = tape.FileName,
                    Duration = temp.PlayTime,
                    StartTime = temp.StartTime,
                    TCIn = temp.PlayTcIn,
                    TCOut = temp.PlayTcOut
                });
            }
            return View(lstItems);
        }
        public List<PlayList> GetPlaylist(int sectorId)
        {
            return _context.PlayList.Where(m => m.SystemId == sectorId).ToList();
        }
        public List<PlayListItem> GetPlaylistItems(int playlistId)
        {
            return _context.PlayListItem.Where(m => m.ListId == playlistId).ToList();
        }
        public InforTape GetInforTape(long idClip)
        {
            return _context.InforTape.Where(m => m.Idclip == idClip).FirstOrDefault();
        }

    }
}