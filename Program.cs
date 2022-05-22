using InverseMarketProject.entity;
using InverseMarketProject;
using Npgsql;
using System.Data;

Database database = new();
DataTable table = new();
NpgsqlDataAdapter adapter = new();

adapter.SelectCommand = new NpgsqlCommand("SELECT * FROM userss", Database.conn);
adapter.Fill(table);

Console.WriteLine(table.DefaultView);
Console.WriteLine(table.Columns);
Console.WriteLine(table.Rows);

//database.InsertUser( new User(
//        1, "email@hentai.com", "password", "87773334422", "firstname", "lastname", "userguy"
//    ));

Console.WriteLine( database.GetUsers() );
Console.WriteLine( database.GetUserByUsername("userguy") );