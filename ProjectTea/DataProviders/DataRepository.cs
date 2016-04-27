using ProjectTea.Models;
using ProjectTea.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using Dapper;
using Dapper.Contrib.Extensions;

namespace ProjectTea.DataProviders
{
    public class DataRepository : IRepository
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=codeblocks3;Database=postgres";
        public DataRepository()
        {/*
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
             */
        }
        public List<Track> GetAll()
        {
           
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var alltracks = conn.GetAll<Track>().ToList();
                return alltracks;
            }
            
        }

        public Track Create (Track track)
        {
            if(track == null)
            {
                return null;
            }
            //No need to close the sql, using will dispose of the object automatically at the end.
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    //That's because Insert returns an Id on success, since it's a collection, i return the first element
                    // once it work, delegate string to QueryStrings class
                    int trackId = conn.Query(@"INSERT INTO tracks(title, artist, genreid, year, moodid) VALUES(@Title, @Artist, @GenreId, @Year, @MoodId) RETURNING Id; ", track).First();
                    track.Id = trackId;
                   

                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Cannot Insert data. Details:" + ex);
                }
            }

            return track.Id != 0 ? track : null;
        }
    }
}