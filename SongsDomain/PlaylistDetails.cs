using System;
using System.Collections.Generic;
using System.Text;

namespace SongsDomain
{
    public class PlaylistDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public object IntemediateEntity { get; set; }

        //    public ICollection <SongForPlaylist> SongList { get; set; }
    }
}
