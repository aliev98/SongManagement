using SongsDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongsApplication.Interfaces
{
   public interface ISongService
   {
        public void addSong(SongDetails aSong);
        ICollection <SongDetails> GetAllSongs();

        public SongDetails GetSong(int id);

        public void removeASong();
   }
}
