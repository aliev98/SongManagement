using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SongSystem;
using SongsApplication.Interfaces;
using Microsoft.Extensions.Logging;
using SongSystem.Controllers;
using System.Net.Http;
using SongSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongsInfrasctructure.Services;
//using SongSystem.Controllers;

namespace SongTesting
{
    public class songtest
    {

        [Fact]
        public void Testing_Numberofsongs_Fromstart()
        {
            //Arrange
            var context = new TestContext();
            ISongService songservice = new SongService (context);

            //Act
            var allsongs = songservice.GetAllSongs();
            var numberofsongs = allsongs.Count;

            //Assert
            Assert.Equal (7, numberofsongs);
        }

        [Fact]
        public void CreateMethod_SongController_NotNull()
        {
            //Arrange
            var context = new TestContext();
            ISongService songservice = new SongService(context);
            SongDetailsController songcontroller = new SongDetailsController(songservice, context);

            //Act
            ViewResult theResult = songcontroller.Create() as ViewResult;

            //Assert
            Assert.NotNull (theResult);

        }

    }

    public class TestContext : SongSystemContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=SongSystemContext-4e702422-1bb2-41d3-a0ca-1142dad41803; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
    }
}
