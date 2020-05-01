using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SongSystem.Data;
using SongsDomain;
using SongsApplication.Interfaces;

namespace SongSystem.Controllers
{
    public class SongForPlaylistsController : Controller
    {
        private readonly SongSystemContext _context;
        private readonly ISongPlayService songplayservice;
        private readonly ISongService songservice;
        
        public SongForPlaylistsController(SongSystemContext context, ISongPlayService Songplayservice)
        {
            _context = context;
            this.songplayservice = Songplayservice;
        }

        // GET: SongForPlaylists
        public async Task <IActionResult> Index()
        {
            var songSystemContext = _context.songForPlaylists.Include(s => s.Playlist).Include(s => s.SongDetails);

            return View (await songSystemContext.ToListAsync());
        }

        // GET: SongForPlaylists/Details/5
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songForPlaylist = await _context.songForPlaylists
                .Include(s => s.Playlist)
                .Include(s => s.SongDetails)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (songForPlaylist == null)
            {
                return NotFound();
            }

            return View(songForPlaylist);
        }

        // GET: SongForPlaylists/Create
        public IActionResult Create()
        {
            ViewData["PlaylistId"] = new SelectList (_context.Playlists, "Id", "Name");
            ViewData["SongDetailsId"] = new SelectList (_context.Songs, "Id", "Title");

            return View();
        }

        // POST: SongForPlaylists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (SongForPlaylist songForPlaylist)
        {
            if (ModelState.IsValid)
            {
                var collection = songplayservice.GetList();

                foreach(var item in collection)
                {
                    if(songForPlaylist.PlaylistId == item.PlaylistId && songForPlaylist.SongDetailsId == item.SongDetailsId)
                    {
                        return RedirectToAction(nameof(error123));
                    }
                }

                _context.Add(songForPlaylist);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }


            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", songForPlaylist.PlaylistId);
            ViewData["SongDetailsId"] = new SelectList(_context.Songs, "Id", "Id", songForPlaylist.SongDetailsId);

            return View(songForPlaylist);
        }

        public ActionResult error123()
        {
            TempData["alertMessage"] = "...";

            return RedirectToAction("Create");
        }

        // GET: SongForPlaylists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songForPlaylist = await _context.songForPlaylists.FindAsync(id);
            if (songForPlaylist == null)
            {
                return NotFound();
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", songForPlaylist.PlaylistId);
            ViewData["SongDetailsId"] = new SelectList(_context.Songs, "Id", "Id", songForPlaylist.SongDetailsId);
            return View(songForPlaylist);
        }

        // POST: SongForPlaylists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongDetailsId,PlaylistId")] SongForPlaylist songForPlaylist)
        {
            if (id != songForPlaylist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songForPlaylist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongForPlaylistExists(songForPlaylist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", songForPlaylist.PlaylistId);
            ViewData["SongDetailsId"] = new SelectList(_context.Songs, "Id", "Id", songForPlaylist.SongDetailsId);
            return View(songForPlaylist);
        }

        // GET: SongForPlaylists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songForPlaylist = await _context.songForPlaylists
                .Include(s => s.Playlist)
                .Include(s => s.SongDetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songForPlaylist == null)
            {
                return NotFound();
            }

            return View(songForPlaylist);
        }

        // POST: SongForPlaylists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songForPlaylist = await _context.songForPlaylists.FindAsync(id);
            _context.songForPlaylists.Remove(songForPlaylist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongForPlaylistExists(int id)
        {
            return _context.songForPlaylists.Any(e => e.Id == id);
        }
    }
}
