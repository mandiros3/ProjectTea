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
            {
                conn.Open();
               //conn.Execute($"CREATE TABLE IF NOT EXISTS Tracks () ")

            }
        }
        public List<Track> GetAll()
        {
            var tracks = new List<Track>();

            Track track = new Track
            {
                Id = 1,
                Artist = "Rammstein",
                Genre = "Industrial",
                Mood = "Angry",
                Title = "Ich Wil",
                Year = 1995
            };
            Track track2 = new Track
            {
                Id = 2,
                Artist = "Fela Kuti",
                Genre = "Afro Beat",
                Mood = "Revolutionary",
                Title = "Water no get Enemy",
                Year = 2000
            };
            Track track3 = new Track
            {
                Id = 3,
                Artist = "Justin Bieber",
                Genre = "Riddim",
                Mood = "Sad",
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