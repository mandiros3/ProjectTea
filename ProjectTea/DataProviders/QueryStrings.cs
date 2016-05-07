using Dapper;
using ProjectTea.Models;

namespace ProjectTea.DataProviders
{
    //PostgresSQL queries
    public static class QueryStrings
    {

        public static string CreateTableTracks()
        {

            return @"CREATE TABLE IF NOT EXISTS Tracks (
                 Id serial PRIMARY KEY,
                 Title varchar(50) NOT NULL,
                 Artist varchar(50) NOT NULL,
                 GenreId integer Not Null,
                 Year integer Not Null,
                 MoodId integer,
                 dateCreated timestamp DEFAULT current_timestamp
                );";
        }

        public static string CreateTableGenre()
        {

            return @"CREATE TABLE IF NOT EXISTS Genres(
                          Id serial PRIMARY KEY,
                          Name varchar(50) NOT NULL,
                          Description varchar (500) NOT NULL);";

        }

        public static string InsertTrack()
        {
            return @"INSERT INTO tracks (title, artist, genreid, year, moodid) VALUES (@Title, @Artist, @GenreId, @Year, @MoodId) RETURNING Id;";
        }

        public static string InsertGenre()
        {
            return @"INSERT INTO genres (name, description) VALUES (@Name, @Description) RETURNING Id";
        }


    }
}