using InverseMarketProject.entity;
using Npgsql;

var cs = "Host=localhost;Username=postgres;Password=ninja;Database=postgres";
using var con = new NpgsqlConnection(cs);
con.Open();

var sql = "SELECT version()";

using var cmd = new NpgsqlCommand(sql, con);

var version = cmd.ExecuteScalar().ToString();
Console.WriteLine(version);


Vendor v = new Vendor(1, "mail", "pass", "8777", "company", "kazakhfilm");


