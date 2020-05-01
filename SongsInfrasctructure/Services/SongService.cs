using System;
using System.Collections.Generic;
using System.Text;
using SongsApplication.Interfaces;
using SongsDomain;
using SongsInfrasctructure;
using SongsApplication;
using SongSystem.Data;
using System.Linq;

namespace SongsInfrasctructure.Services
{
    public class SongService : ISongService
    {
        private readonly SongSystemContext _context;

        public SongService (SongSystemContext context)
        {
            _context = context;
        }

        public void removeASong()
        {
            var aSong = _context.Songs.Where(x => x.Length == 10).FirstOrDefault();

            this._context.Remove(aSong);

            _context.SaveChanges();

        }

        public void addSong (SongDetails aSong)
        {
            this._context.Add(aSong);
            _context.SaveChanges();
        }

        public ICollection <SongDetails> GetAllSongs()
        {
            return _context.Songs.ToList();
        }

        public SongDetails GetSong(int id)
        {
            return this._context.Songs.Find(id);
        }
   }
}
