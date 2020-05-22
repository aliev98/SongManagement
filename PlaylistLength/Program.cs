using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SongsApplication;
using SongsApplication.Interfaces;
using SongsDomain;
using SongsInfrasctructure;
using SongSystem;
using SongSystem.Data;
using Microsoft.EntityFrameworkCore;
using SongsInfrasctructure.Services;

namespace PlaylistLength
{

    public class Program
    {
         static void Main (string[] args)
         {
            var context = new ConsoleContext();

            IPlaylistService playlistService = new PlaylistService(context);
            ISongService songservice = new SongService(context);
            ISongPlayService songplayservice = new SongPlayService(context);

            var allPlayLists = playlistService.GetAllPlaylists();
            var allsongs = songservice.GetAllSongs();
            var allplaysongs = songplayservice.GetList();

            var nameandlengthlist = new List <playlistsnameandLength>();

            foreach (var item in allPlayLists)
            {
                var namelength = new playlistsnameandLength();

                var length = 0;
                var nameofplaylist = item.Name;

                foreach (var songplay in allplaysongs)
                {
                    if (item.Id == songplay.PlaylistId)
                    {
                        length += songplay.SongDetails.Length;
                    }
                }

                namelength.Name = nameofplaylist;
                namelength.Length = length;

                nameandlengthlist.Add (namelength);

            }

            foreach (var item in nameandlengthlist)
            {
                Console.WriteLine($"{item.Name} has length {item.Length}");
            }

            //Perform logic

            Console.ReadLine();
         }
    }

    public class playlistsnameandLength
    {
        public string Name { get; set; }
        public int Length { get; set; }
    }

    public class ConsoleContext : SongSystemContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SongSystemContext-4e702422-1bb2-41d3-a0ca-1142dad41803;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}