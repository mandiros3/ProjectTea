using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTea.DataProviders
{
    //PostgresSQL queries
    public static class QueryStrings
    {

        public static string CreateTableTracks()
        {
            var query = @"CREATE TABLE Tracks (
                 Id serial PRIMARY KEY,
                 Title varchar(50) NOT NULL,
                 Artist varchar(50) NOT NULL,
                 GenreId integer Not Null,
                 Year integer Not Null,
                 MoodId integer,
                 dateCreated timestamp DEFAULT current_timestamp
                );";

            return query;
        }

        public static string InsertTrack()
        {
            var query = @"INSERT INTO";
            return query;
        }


    }
}