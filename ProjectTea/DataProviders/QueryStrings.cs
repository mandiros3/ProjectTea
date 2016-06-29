using Dapper;
using ProjectTea.Models;

namespace ProjectTea.DataProviders
{
    //PostgresSQL queries
    public static class QueryStrings
    {

        public static string CreateTableTracks()
        {
            var query = @"CREATE TABLE IF NOT EXISTS Tracks (
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

        public static string CreateTableGenre()
        {
            var query = @"CREATE TABLE IF NOT EXISTS Genres (
                          Id serial PRIMARY KEY, 
                          Name varchar(50) NOT NULL,
                          Description varchar(500)  
                          );";
            return query;
        }
        public static string CreateTableMood()
        {
            var query = @"CREATE TABLE IF NOT EXISTS Moods (
                          Id serial PRIMARY KEY, 
                          Name varchar(50) NOT NULL,
                          Description varchar(500)  
                          );";
            return query;
        }
        public static string CreateTableDecade()
        {
            var query = @"CREATE TABLE IF NOT EXISTS Decades (
                          Id serial PRIMARY KEY, 
                          Year varchar(50) NOT NULL,
                          Description varchar(500)  
                          );";
            return query;
        }



        public static string InsertTrack()
        {
            var query = @"INSERT INTO tracks (title, artist, genreid, year, moodid) VALUES (@Title, @Artist, @GenreId, @Year, @MoodId) RETURNING Id;";
            return query;
        }

        public static string InsertGenre()
        {
            var query =
                @"INSERT INTO genres (name, description) VALUES (@Name, @Description) RETURNING Id;";
            return query;
        }
        


    }
}