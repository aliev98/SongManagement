using SongsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongSystem.Models
{
    public class SongsPlaylistsVm
    {
        public ICollection<SongForPlaylist> songsforplaylists = new List <SongForPlaylist>();
    }
}
