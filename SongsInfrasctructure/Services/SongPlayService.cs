using SongsApplication.Interfaces;
using SongsDomain;
using SongSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongsInfrasctructure.Services
{
   public class SongPlayService : ISongPlayService
    {

        private readonly SongSystemContext _context;

        public SongPlayService (SongSystemContext context)
        {
            _context = context;
        }

        public bool checkifnull (int id)
        {
            // return _context.songForPlaylists.Where(x => x.SongDetailsId == id).FirstOrDefault();

            var songsplay = _context.songForPlaylists.Find(id);

            if (songsplay == null) return true;

            return false;
        }


        public void addSongPlay (SongForPlaylist songForPlay)
        {
            this._context.Add(songForPlay);
            this._context.SaveChanges();
        }

        public ICollection <SongForPlaylist> GetList()
        {
            return _context.songForPlaylists.ToList();
        }
    }
}
