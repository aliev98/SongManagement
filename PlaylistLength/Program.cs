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
using SongsInfrasctructure.Helper;
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
            var allPlayLists = playlistService.GetAllPlaylists();
            //Perform logic
            Console.WriteLine("Hello World");
            Console.ReadLine();
         }
    }

    public class ConsoleContext: SongSystemContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SongSystemContext-4e702422-1bb2-41d3-a0ca-1142dad41803;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}