using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Back_End.Models
{
    public class Database
    {
        private string server {get; set;}
        private string database{get; set;}
        private string port{get; set;}
        private string username{get; set;}
        private string password{get; set;}
        public string cs{get; set;}
        public Database()
        {
            
            server = "q3vtafztappqbpzn.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            database = "gtjytuh7vzr4bzmq";
            port = "3306";
            username = "w9qo8tyo6puecu82";
            password = "wecn50qrwml1n2l0";


            // MySQL connection string
            cs = $@"server={server};user={username};database={database};port={port};password={password};";
        }
    }
}