using SongsApplication.Interfaces;
using SongSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongsInfrasctructure.Helper
{
    public class PrintOutPlaylists
    {

        private readonly SongSystemContext _ctx; 
        PrintOutPlaylists (SongSystemContext ctx) 
        {
            _ctx = ctx;
        }

    }
}
