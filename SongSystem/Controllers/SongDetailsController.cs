using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SongSystem.Data;
using SongsDomain;
using SongSystem.Models;
using SongsApplication.Interfaces;

namespace SongSystem.Controllers
{
    public class SongDetailsController : Controller
    {
        private readonly SongSystemContext _context;
        private readonly ISongService SongService;

        public SongDetailsController(ISongService songservice, SongSystemContext context)
        {
            _context = context;
            SongService = songservice;
        }
        public IActionResult Index()
        {
            var vm = new SongIndexVm();
            vm.songs = SongService.GetAllSongs();
            return View(vm);
        }

        //public ActionResult Index2()
        //{
        //    SongService.removeASong();
        //    return RedirectToAction("Index");
        //}

        // GET: SongDetails
        //public async Task <IActionResult> Index()
        //{
        //    return View(await _context.SongDetails.ToListAsync()); 
        //}

        // GET: SongDetails/Details/5
        public async Task <IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songDetails = await _context.Songs.FirstOrDefaultAsync(m => m.Id == id);
           
            if (songDetails == null)
            {
                return NotFound();
            }

            return View (songDetails);
        }

        // GET: SongDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SongDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (SongDetails aSong)
        {
            if (ModelState.IsValid)
            {
                SongService.addSong(aSong);

                return RedirectToAction(nameof(Index));
            }


            return View(aSong);
        }

        // GET: SongDetails/Edit/5
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songDetails = await _context.Songs.FindAsync(id);

            if (songDetails == null)
            {
                return NotFound();
            }

            return View(songDetails);
        }

        // POST: SongDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongDetails songDetails)
        {
            if (id != songDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongDetailsExists(songDetails.Id))
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

            return View(songDetails);
        }

        // GET: SongDetails/Delete/5
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songDetails = await _context.Songs.FirstOrDefaultAsync(m => m.Id == id);

            if (songDetails == null)
            {
                return NotFound();
            }

            return View(songDetails);
        }

        // POST: SongDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songDetails = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(songDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongDetailsExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
