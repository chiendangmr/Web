using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HDAutomation.Data;
using HDAutomation.Models;

namespace HDAutomation.Controllers
{
    public class PlayListItemsController : Controller
    {
        private readonly HDStationPS_V4Context _context;

        public PlayListItemsController(HDStationPS_V4Context context)
        {
            _context = context;    
        }

        // GET: PlayListItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayListItem.ToListAsync());
        }

        // GET: PlayListItems/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playListItem = await _context.PlayListItem
                .SingleOrDefaultAsync(m => m.Id == id);
            if (playListItem == null)
            {
                return NotFound();
            }

            return View(playListItem);
        }

        // GET: PlayListItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayListItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListId,Idclip,IdclipSubstitute,OrderClip,PlayTcIn,PlayTcOut,Command,Command1,Note,Setting,StartTime,ColorDisplay,Status,RouterInput,CommandAtEnd,StandbyPlaylistId,MasterPlaylistItemId,VtrId,Changed,ClusterId,PlayTime,EventType,Approved,RealPlayTcIn,RealPlayTcOut,SyncId,RowColor,ProgramNote")] PlayListItem playListItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(playListItem);
        }

        // GET: PlayListItems/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playListItem = await _context.PlayListItem.SingleOrDefaultAsync(m => m.Id == id);
            if (playListItem == null)
            {
                return NotFound();
            }
            return View(playListItem);
        }

        // POST: PlayListItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ListId,Idclip,IdclipSubstitute,OrderClip,PlayTcIn,PlayTcOut,Command,Command1,Note,Setting,StartTime,ColorDisplay,Status,RouterInput,CommandAtEnd,StandbyPlaylistId,MasterPlaylistItemId,VtrId,Changed,ClusterId,PlayTime,EventType,Approved,RealPlayTcIn,RealPlayTcOut,SyncId,RowColor,ProgramNote")] PlayListItem playListItem)
        {
            if (id != playListItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playListItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayListItemExists(playListItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(playListItem);
        }

        // GET: PlayListItems/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playListItem = await _context.PlayListItem
                .SingleOrDefaultAsync(m => m.Id == id);
            if (playListItem == null)
            {
                return NotFound();
            }

            return View(playListItem);
        }

        // POST: PlayListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var playListItem = await _context.PlayListItem.SingleOrDefaultAsync(m => m.Id == id);
            _context.PlayListItem.Remove(playListItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlayListItemExists(long id)
        {
            return _context.PlayListItem.Any(e => e.Id == id);
        }
    }
}
