using InverseMarketProject.entity;
using Npgsql;

var cs = "Host=localhost;Username=postgres;Password=ninja;Database=market";
using var con = new NpgsqlConnection(cs);
con.Open();

var sql = "SELECT version()";

using var cmd = new NpgsqlCommand(sql, con);

var version = cmd.ExecuteScalar().ToString();
Console.WriteLine(version);

Customer c = new Customer(1, "email", "pass", "87753932824");
Vendor v = new Vendor(1, "mail", "pass", "87775553322", "company", "kazakhfilm");
Request rq = new Request(1, 1, "money", "Where is the money Lebowski", 1000.0, DateOnly.Parse("12.01.2003"), "pending");
Response rs = new Response(1, 1, "title2", "message", 1000.0, "87775553322");

cmd.CommandText = $"INSERT INTO customer(email, password, phone_number) VALUES('{c.email}','{c.password}',{c.phone_number})";
cmd.ExecuteNonQuery();

cmd.CommandText = $"INSERT INTO vendor VALUES({v.id}, '{v.email}','{v.password}', {v.phone_number}, '{v.company_name}', '{v.address}')";
cmd.ExecuteNonQuery();

cmd.CommandText = $"INSERT INTO request VALUES({rq.id}, {rq.customer_id}, '{rq.title}', '{rq.description}', {rq.total_price}, '{rq.date}', '{rq.status}')";
cmd.ExecuteNonQuery();

cmd.CommandText = $"INSERT INTO response VALUES({rs.id}, {rs.request_id}, '{rs.title}', '{rs.message}', {rs.total_price}, {rs.phone_number})";
cmd.ExecuteNonQuery();