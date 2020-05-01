using Microsoft.AspNetCore.Mvc.Rendering;
using SongsDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongSystem.Models
{
    public class SongInPlayCreateVm
    {
        //public SongDetails SongDetails { get; set; }

        [Display(Name = "Which song?")]
        public SelectList SongSelectlist { get; set; }
        public int SongDetailsId { get; set; }


        //public PlaylistDetails Playlist { get; set; }

        [Display(Name ="To which playlist?")]
        public SelectList PlayListSelectlist { get; set; }
        public int PlaylistId { get; set; }
    }
}
