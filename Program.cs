using InverseMarketProject.entity;
using InverseMarketProject;
using Npgsql;
using System.Data;

Database database = new();
DataTable table = new();
NpgsqlDataAdapter adapter = new();

adapter.SelectCommand = new NpgsqlCommand("SELECT * FROM userss", Database.conn);
adapter.Fill(table);

//database.InsertUser(new User(
//        "email@hen.com", "password", "firstname", "lastname", "user"
//    ));

Console.WriteLine( database.GetUsers() );
Console.WriteLine( database.GetUserByUsername("userguy") );