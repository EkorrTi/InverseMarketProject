using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InverseMarketProject.entity;

namespace InverseMarketProject
{
    public class Database
    {
        private static readonly NpgsqlConnection conn = new("Host=localhost;Username=postgres;Password=ninja;Database=market");
        public Database() { conn.Open(); }

        private static readonly String getUsers = "SELECT * FROM userss;";
        private static readonly String getAdverts = "SELECT * FROM advert;";
        private static readonly String getReplies = "SELECT * FROM reply;";
        private static readonly String insertUser = "INSERT INTO userss VALUES($1, '$2','$3', '$4', '$5', '$6', '$7')"; // id, email, password, phone, fname, lname, username
        private static readonly String insertAdvert = "INSERT INTO advert VALUES($1, '$2','$3', $4, '$5', '$6')"; // id, email, password, phone_num, company_name, address
        private static readonly String insertReply = "INSERT INTO reply VALUES($1, '$2', $3, $4, $5)"; // id, cust_id, title, descrip, total_price, date, status

        public List<User> GetUsers()
        {
            List<User> list = new();
            using var cmd = new NpgsqlCommand(getUsers, conn);
            using var rdr = cmd.ExecuteReader();

            while (rdr.Read()) {
                 list.Add( new User(
                     rdr.GetInt32(0), // Id
                     rdr.GetString(1), // email
                     rdr.GetString(2), // password
                     rdr.GetString(3), // phone_number
                     rdr.GetString(4), // fname
                     rdr.GetString(5), // lname
                     rdr.GetString(6) // username
                     )
                 );
            }

            return list;
        }

        public List<Advert> GetResponses()
        {
            List<Advert> list = new();

            using var cmd = new NpgsqlCommand(getAdverts, conn);
            using var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Advert(
                    rdr.GetInt32(0), // Id
                    rdr.GetString(1), // title
                    rdr.GetString(2), // description
                    rdr.GetString(3), // price
                    rdr.GetString(4), // status
                    rdr.GetInt32(5) // userId
                    )
                 );
            }
            return list;
        }

        public List<Reply> GetRequests()
        {
            List<Reply> list = new();

            using var cmd = new NpgsqlCommand(getReplies, conn);
            using var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Reply(
                    rdr.GetInt32(0), // Id
                    rdr.GetString(1), // message
                    rdr.GetInt32(2), // price
                    rdr.GetInt32(3), // userId
                    rdr.GetInt32(4) // advertId
                    ));
            }
            return list;
        }

        public bool InsertUser(User u)
        {
            using var cmdd = new NpgsqlCommand(insertUser, conn)
            {
                Parameters = {
                    new() {Value = u.Id},
                    new() {Value = u.Email},
                    new() {Value = u.Password}
                }
            };
            if (cmdd.ExecuteNonQuery() != -1) return true;
            else return false;
        }
    }
}
