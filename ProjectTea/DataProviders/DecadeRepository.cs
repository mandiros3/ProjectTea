
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
using ProjectTea.DataProviders;
using ProjectTea.Models;
using ProjectTea.Interfaces;

namespace ProjectTea.DataProviders
{
    public class DecadeRepository : IDecade
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=codeblocks3;Database=postgres";

        public DecadeRepository()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {//Todo: Instead of catching exception, check if table exists programmatically
             // TODO: Have a DB configurator script what will auto-generate schemas, as long as db is setup.  
                try
                {
                    conn.Open();
                    conn.Execute(QueryStrings.CreateTableDecade());
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Table already exists. Details:" + ex);
                }
                conn.Close();
            }
        }

        public List<Decade> GetAll()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var allDecade = conn.GetAll<Decade>().ToList();
                return allDecade;
            }
        }

        public Decade Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var decade = conn.Get<Decade>(id);
                return decade;
            }
        }

    }
}