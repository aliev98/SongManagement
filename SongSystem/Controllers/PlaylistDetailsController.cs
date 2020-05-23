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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SongSystem.Controllers
{
    public class PlaylistDetailsController : Controller
    {
        private readonly SongSystemContext _context;
        private readonly IPlaylistService playlistService;
        private readonly ISongService songService;
        private readonly ISongPlayService songplayservice;

        public PlaylistDetailsController(SongSystemContext context, IPlaylistService playlistservice, ISongService Songservice, ISongPlayService songplayService)
        {
            songplayservice = songplayService;
            playlistService = playlistservice;
            songService = Songservice;
            _context = context;
        }
    
        // GET: PlaylistDetails
        public IActionResult Index()
        {
            var vm = new PlaylistIndexVm();
            vm.playlists = playlistService.GetAllPlaylists();
            return View(vm);

            //return View(await _context.Playlists.ToListAsync());
        }


        //addSong: GET

        //public IActionResult addSong()
        //{
        //    //var vm = new addSongVm();

        //    ////vm.songList = new SelectList(songService.GetAllSongs(), "Id", "Title"); 

        //    //return View(chosenSong);

        //}

        public IActionResult viewSongs (int? id)
        {
            //    var playlist = playlistService.GetPlaylist((int)id);
 
            var vm = new SongsPlaylistsVm();

            //    vm.songsforplaylists= playlistService.theSongs((int)id);

            vm.songsforplaylists = _context.songForPlaylists.Include (x => x.SongDetails).Include(x => x.Playlist).Where(x => x.PlaylistId == id).ToList();

           
            //playlist.SongList = new List<SongDetails>();

            return View(vm);
        }

        public IActionResult newOrnot (int Id)
        {
            var playlist = playlistService.GetPlaylist (Id);
            
            //ViewBag.message = playlist.Name;

            ViewBag.theId = Id;
            
            return View();
        }

        [HttpGet]
        public IActionResult newSong ()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> newSong (SongDetails aSong)
        {
            if (ModelState.IsValid)
            {
                songService.addSong(aSong);

                playlistandsong(aSong.Id );

                //return RedirectToAction(nameof(Index));
            }

            return View(aSong);
        }

        public ActionResult playlistandsong (int songId, int playlistId)
        {
            var thesong = songService.GetSong(songId);
            var theplaylist = playlistService.GetPlaylist(playlistId);

            var songplay = new SongForPlaylist();
            
            songplay.SongDetailsId = thesong.Id;
            songplay.PlaylistId = theplaylist.Id;

            songplayservice.addSongPlay(songplay);

            return RedirectToAction("Index");
        }




        // GET: PlaylistDetails/Details/5
        public async Task <IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlistDetails = await _context.Playlists.FirstOrDefaultAsync(m => m.Id == id);

            if (playlistDetails == null)
            {
                return NotFound();
            }

            return View (playlistDetails);
        }

        // GET: PlaylistDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaylistDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create (PlaylistCreateVm vm)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(playlistDetails);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                var newList = new PlaylistDetails();
                newList.Name = vm.Name;
                newList.Description = vm.Description;

                //newList.SongList = new List <SongDetails>();

                playlistService.addPlaylist(newList);


                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error", "Home", "");

            //   return View(playlistDetails);
        }

        // GET: PlaylistDetails/Edit/5
        public async Task <IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlistDetails = await _context.Playlists.FindAsync(id);
            
            if (playlistDetails == null)
            {
                return NotFound();
            }

            return View (playlistDetails);
        }

        // POST: PlaylistDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind("Id,Name,Description")] PlaylistDetails playlistDetails)
        {
            if (id != playlistDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlistDetails);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistDetailsExists(playlistDetails.Id))
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

            return View(playlistDetails);
        }

        // GET: PlaylistDetails/Delete/5
        public async Task <IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlistDetails = await _context.Playlists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlistDetails == null)
            {
                return NotFound();
            }

            return View(playlistDetails);
        }

        // POST: PlaylistDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playlistDetails = await _context.Playlists.FindAsync(id);
            _context.Playlists.Remove(playlistDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistDetailsExists(int id)
        {
            return _context.Playlists.Any(e => e.Id == id);
        }
    }
}
