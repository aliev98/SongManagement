using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SongsDomain
{
   public class SongForPlaylist
    {
        public int Id { get; set; }

        //SONG
        
        [ForeignKey(nameof(SongDetailsId))]
        public SongDetails SongDetails { get; set; }
        public int SongDetailsId { get; set; }

        //PLAYLIST

        [ForeignKey(nameof(PlaylistId))]
        public PlaylistDetails Playlist { get; set; }
        public int PlaylistId { get; set; }
    }
}
