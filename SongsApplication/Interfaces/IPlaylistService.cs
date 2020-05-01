using SongsDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongsApplication.Interfaces
{
   public interface IPlaylistService
   {
        //public void addSong (int listId, int songId);

        void addPlaylist(PlaylistDetails aPlaylist);
        public PlaylistDetails GetPlaylist(int id);
        ICollection<PlaylistDetails> GetAllPlaylists();

   }
}
