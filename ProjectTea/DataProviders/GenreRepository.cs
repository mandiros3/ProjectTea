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
    public class GenreRepository : IGenre
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=codeblocks3;Database=postgres";

        public GenreRepository()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
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


        public Genre Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var genre = conn.Get<Genre>(id);
                return genre;
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