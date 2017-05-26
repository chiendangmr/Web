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
    public class PlayListsController : Controller
    {
        private readonly HDStationPS_V4Context _context;

        public PlayListsController(HDStationPS_V4Context context)
        {
            _context = context;    
        }

        // GET: PlayLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayList.ToListAsync());
        }

        // GET: PlayLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList
                .SingleOrDefaultAsync(m => m.ListId == id);
            if (playList == null)
            {
                return NotFound();
            }

            return View(playList);
        }

        // GET: PlayLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListId,DateList,SystemId,Isupdate,Playline,Islock,TimeStart,MasterPlaylistId,ApproverId,TimeLast,Changed,Cueline,UserId,LastTime")] PlayList playList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playList);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(playList);
        }

        // GET: PlayLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList.SingleOrDefaultAsync(m => m.ListId == id);
            if (playList == null)
            {
                return NotFound();
            }
            return View(playList);
        }

        // POST: PlayLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListId,DateList,SystemId,Isupdate,Playline,Islock,TimeStart,MasterPlaylistId,ApproverId,TimeLast,Changed,Cueline,UserId,LastTime")] PlayList playList)
        {
            if (id != playList.ListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayListExists(playList.ListId))
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
            return View(playList);
        }

        // GET: PlayLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList
                .SingleOrDefaultAsync(m => m.ListId == id);
            if (playList == null)
            {
                return NotFound();
            }

            return View(playList);
        }

        // POST: PlayLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playList = await _context.PlayList.SingleOrDefaultAsync(m => m.ListId == id);
            _context.PlayList.Remove(playList);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlayListExists(int id)
        {
            return _context.PlayList.Any(e => e.ListId == id);
        }
    }
}
