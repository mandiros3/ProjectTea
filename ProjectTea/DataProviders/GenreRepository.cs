using System;
using ProjectTea.Models;
using ProjectTea.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;


namespace ProjectTea.DataProviders
{
    public class GenreRepository : IGenreRepository
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=codeblocks3;Database=postgres";

        public GenreRepository()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {//Todo: Instead of catching exception, check if table exists programmatically
             // TODO: Have a DB configurator script what will auto-generate schemas, as long as db is setup.  
                try
                {
                    conn.Open();
                    conn.Execute(QueryStrings.CreateTableGenre());
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Table already exists. Details:" + ex);
                }
                conn.Close();
            }
        }

        public  List<Genre> GetAll()
      {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var allGenres = conn.GetAll<Genre>().ToList();
                return allGenres;
            }
        }

        public Genre Create(Genre genre)
        {
            if (genre == null)
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
                    var trackId = conn.Query<int>(QueryStrings.InsertGenre(), genre).Single();
                    genre.Id = trackId;
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Cannot Insert data. Details:" + ex);
                }
            }
            return genre.Id > 0 ? genre : null;
        }


    }
}