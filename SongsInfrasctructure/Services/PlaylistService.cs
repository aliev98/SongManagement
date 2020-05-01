using SongsApplication.Interfaces;
using SongsDomain;
using SongSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SongsInfrasctructure.Services
{
   public class PlaylistService : IPlaylistService
   {
        private readonly SongSystemContext _context;
        //private readonly SongService songService;

        public PlaylistService (SongSystemContext context)
        {
            _context = context;
            //this.songService = songservice;
        }

        public PlaylistDetails GetPlaylist (int id)
        {
            //return _context.Playlists.Where(x => x.Id == id).FirstOrDefault();

            return _context.Playlists.Find(id);
        }


        public void addPlaylist (PlaylistDetails aPlaylist)
        {
            this._context.Add (aPlaylist);

            _context.SaveChanges();
        }
        
        public ICollection <PlaylistDetails> GetAllPlaylists()
        {
             return _context.Playlists.ToList();
        }

    }


}
