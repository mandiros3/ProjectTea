using ProjectTea.Models;
using ProjectTea.Interfaces;
using System;
using System.Collections.Generic;
using Npgsql;
using Dapper;

namespace ProjectTea.DataProviders
{
    public class DataRepository : IRepository
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=codeblocks3;Database=postgres";
        public DataRepository()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {//Todo: Instead of catching exception, check if table exists programmatically
              //Have a DB configurator script what will auto-generate schemas, as long as db is setup.  
                try
                {
                    conn.Open();
                    conn.Execute(QueryStrings.CreateTableTracks());
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Table already exists. Details:" +ex);
                }                 
                conn.Close();
               
            }
        }
        public List<Track> GetAll()
        {
            var tracks = new List<Track>();

            Track track = new Track
            {
                Id = 1,
                Artist = "Rammstein",
                GenreId = 11,
                MoodId = 3,
                Title = "Ich Wil",
                Year = 1995
            };
            Track track2 = new Track
            {
                Id = 2,
                Artist = "Fela Kuti",
                GenreId = 11,
                MoodId = 1,
                Title = "Water no get Enemy",
                Year = 2000
            };
            Track track3 = new Track
            {
                Id = 3,
                Artist = "Justin Bieber",
                GenreId = 4,
                MoodId = 2,
                Title = "Sorry",
                Year = 2016
            };

            tracks.Add(track);
            tracks.Add(track2);
            tracks.Add(track3);
            return tracks;
        }
    }
}