using SongsDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongsApplication.Interfaces
{
   public interface ISongPlayService
    {
        public ICollection <SongForPlaylist> GetList();
        public void addSongPlay(SongForPlaylist songforPlay);
        public bool checkifnull(int id);
    }
}
