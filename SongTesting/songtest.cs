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
//using SongSystem.Controllers;

namespace SongTesting
{
    
    public class songtest
    {
        private readonly ISongService _songservice;
        private readonly ILogger<SongDetailsController> _logger;
        private readonly SongDetailsController _songcontroller;
        private readonly HttpClient _client;
        private readonly SongSystemContext _context;

        

        //public songtest (SongSystemContext context, HttpClient client ,ISongService songservice, SongDetailsController songcontroller, ILogger <SongDetailsController> logger)
        public songtest ()
        {
            //this._songservice = songservice;
            this._songcontroller = new SongDetailsController(_songservice, _context);
        }

        [Fact]

        public void Index()
        {
            SongDetailsController sdc = new SongDetailsController(_songservice, _context);
        }

    }
}
