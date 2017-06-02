using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnAir.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnAir.Models;
using OnAirServices;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnAir.Controllers
{
    public class OnAirController : Controller
    {
        private readonly HDStationPS_V4Context _context;
        private readonly Sector _pi;
        static HttpClient client;

        public OnAirController(HDStationPS_V4Context context, IOptions<Sector> pi)
        {
            _pi = pi.Value;
            _context = context;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:65000/AutomationAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            string x = await GetPlaylistAsync();
            var items = GetPlaylistItems(GetPlaylist(_pi.SectorID).FirstOrDefault().ListId);
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
        public async Task<string> GetPlaylistAsync()
        {
            string test = "";
            string path = "http://localhost:65000/AutomationAPI/Playlist/1";
         HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                test = await response.Content.ReadAsStringAsync();
            }
            return test;
        }
        public List<PlayList> GetPlaylist(int sectorId)
        {
            return _context.PlayList.Where(m => m.DateList == DateTime.Now.Date).ToList();
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