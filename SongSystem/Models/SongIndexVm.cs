using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SongsDomain;

namespace SongSystem.Models
{
    public class SongIndexVm
    {
        public ICollection<SongDetails> songs = new List <SongDetails>();
    }
}
