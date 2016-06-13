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
    public class TrackRepository : ITrack
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=codeblocks3;Database=postgres";
        public TrackRepository()
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
                    //DRY, for open() and close()
                    conn.Open();
                    
                   //Expecting only a single int row identity, we need the id, for the model to be complete.
                    var trackId = conn.Query<int>(QueryStrings.InsertTrack(), track).Single();
                    track.Id = trackId;
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Cannot Insert data. Details:" + ex);
                }
            }
            return  track.Id > 0 ? track : null;
        }
    }
}