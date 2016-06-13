using ProjectTea.Models;
using ProjectTea.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;

namespace ProjectTea.DataProviders
{
    public class MoodRepository : IMood
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=codeblocks3;Database=postgres";


        public MoodRepository()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    conn.Execute(QueryStrings.CreateTableMood());
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Table already exists. Details:" + ex);
                }
                conn.Close();
            }
        }
        public List<Mood> GetAll()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var allMood = conn.GetAll<Mood>().ToList();
                return allMood;
            }
        }


        public Mood Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var mood = conn.Get<Mood>(id);
                return mood;
            }
          
        }

      
    }
}