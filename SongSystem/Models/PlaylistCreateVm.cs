using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongSystem.Models
{
    public class PlaylistCreateVm
    {
        [Display(Name="Name of playlist")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
    }
}
