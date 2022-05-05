using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InverseMarketProject.entity;

namespace InverseMarketProject
{
    internal class Database
    {
        public static NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ninja;Database=market");
        private NpgsqlCommand cmd;
        public Database() {
            conn.Open();
            cmd = conn.CreateCommand();
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> list = new();

            cmd.CommandText = "SELECT * FROM customer;";
            using var rdr = cmd.ExecuteReader();

            while (rdr.Read()) {
                 list.Add( new Customer(
                     rdr.GetInt32(0), // Id
                     rdr.GetString(1), // email
                     rdr.GetString(2), // password
                     rdr.GetDecimal(3).ToString()) // phone_number
                     );
            }

            return list;
        }

        public List<Vendor> GetVendors()
        {
            List<Vendor> list = new();

            cmd.CommandText = "SELECT * FROM vendor;";
            using var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Vendor(
                    rdr.GetInt32(0), // Id
                    rdr.GetString(1),// email
                    rdr.GetString(2),// password
                    rdr.GetDecimal(3).ToString(), // phone num
                    rdr.GetString(4), // company name
                    rdr.GetString(5) // address
                    ));
            }
            return list;
        }

        public List<Response> GetResponses()
        {
            List<Response> list = new();

            cmd.CommandText = "SELECT * FROM response;";
            using var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Response(
                    rdr.GetInt32(0), // Id
                    rdr.GetInt32(1), // request_id
                    rdr.GetString(2), // title
                    rdr.GetString(3), // message
                    rdr.GetDouble(4), // total price
                    rdr.GetDecimal(5).ToString() // phone
                    ));
            }
            return list;
        }

        public List<Request> GetRequests()
        {
            List<Request> list = new();

            cmd.CommandText = "SELECT * FROM request;";
            using var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Request(
                    rdr.GetInt32(0), // Id
                    rdr.GetInt32(1), // customer_id
                    rdr.GetString(2), // title
                    rdr.GetString(3), // description
                    rdr.GetDouble(4), // total price
                    DateOnly.FromDateTime( rdr.GetDateTime(5) ), // date
                    rdr.GetString(6) // phone
                    ));
            }
            return list;
        }

        public void Populate()
        {
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
        }
    }
}
