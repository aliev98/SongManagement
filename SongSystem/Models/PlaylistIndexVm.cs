using SongsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongSystem.Models
{
    public class PlaylistIndexVm
    {
        public ICollection <PlaylistDetails> playlists = new List <PlaylistDetails>();
    }
}
