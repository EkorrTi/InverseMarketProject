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
        public static readonly NpgsqlConnection conn = new("Host=localhost;Username=postgres;Password=ninja;Database=market");
        public Database()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        private static readonly String getUsers = "SELECT * FROM userss;";
        private static readonly String getAdverts = "SELECT * FROM advert;";
        private static readonly String getReplies = "SELECT * FROM reply;";
        private static readonly String getUserById = "SELECT * FROM userss WHERE id=$1";
        private static readonly String getUserByUsername = "SELECT * FROM userss WHERE username = $1;";
        private static readonly String getUserByEmail = "SELECT * FROM userss WHERE email = $1;";
        private static readonly String getAdvertById = "SELECT * FROM advert WHERE id=$1";
        private static readonly String getReplyById = "SELECT * FROM advert WHERE id=$1";
        private static readonly String insertUser = "INSERT INTO userss VALUES($1, $2, $3, $4, $5, $6, $7)"; // id, email, password, phone, fname, lname, username
        private static readonly String insertAdvert = "INSERT INTO advert VALUES($1, $2, $3, $4, $5, $6)"; // id, title, desc, price, status, userId
        private static readonly String insertReply = "INSERT INTO reply VALUES($1, $2, $3, $4, $5)"; // id, message, price, userId, advertId
        private static readonly String updateUser = "UPDATE userss SET email=$2, password=$3, phone=$4, first_name=$5, last_name=$6, username=%7 WHERE id=$1";
        private static readonly String updateAdvert = "UPDATE advert SET title=$2, description=$3, totalPrice=$4, status=$5, user_id=$6 WHERE id=$1";
        private static readonly String updateReply = "UPDATE reply SET message=$2, price=$3, user_id=$4, advert_id=$5 WHERE id=$1";
        private static readonly String deleteUserById = "DELETE FROM userss WHERE id = $1";
        private static readonly String deleteAdvertById = "DELETE FROM advert WHERE id = $1";
        private static readonly String deleteReplyById = "DELETE FROM reply WHERE id = $1";

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

        public List<Advert> GetAdverts()
        {
            List<Advert> list = new();

            using var cmd = new NpgsqlCommand(getAdverts, conn);
            using var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add( new Advert(
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

        public List<Reply> GetReplies()
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
        
        public User GetUserById(int id)
        {
            using var cmd = new NpgsqlCommand(getUserById, conn);
            cmd.Parameters.AddWithValue(id);
            using var rdr = cmd.ExecuteReader();
            rdr.Read();

            return new User(
                     rdr.GetInt32(0), // Id
                     rdr.GetString(1), // email
                     rdr.GetString(2), // password
                     rdr.GetString(3), // phone_number
                     rdr.GetString(4), // fname
                     rdr.GetString(5), // lname
                     rdr.GetString(6) // username
                     );
        }

        public User GetUserByUsername(String username)
        {
            using var cmd = new NpgsqlCommand(getUserByUsername, conn);
            cmd.Parameters.AddWithValue(username);
            using var rdr = cmd.ExecuteReader();
            rdr.Read();

            return new User(
                     rdr.GetInt32(0), // Id
                     rdr.GetString(1), // email
                     rdr.GetString(2), // password
                     rdr.GetString(3), // phone_number
                     rdr.GetString(4), // fname
                     rdr.GetString(5), // lname
                     rdr.GetString(6) // username
                     );
        }

        public User GetUserByEmail(String email)
        {
            using var cmd = new NpgsqlCommand(getUserByEmail, conn);
            cmd.Parameters.AddWithValue(email);
            using var rdr = cmd.ExecuteReader();
            rdr.Read();

            return new User(
                     rdr.GetInt32(0), // Id
                     rdr.GetString(1), // email
                     rdr.GetString(2), // password
                     rdr.GetString(3), // phone_number
                     rdr.GetString(4), // fname
                     rdr.GetString(5), // lname
                     rdr.GetString(6) // username
                     );
        }

        public Advert GetAdvertById(int id)
        {
            using var cmd = new NpgsqlCommand(getAdvertById, conn);
            cmd.Parameters.AddWithValue(id);
            using var rdr = cmd.ExecuteReader();
            rdr.Read();

            return new Advert(
                    rdr.GetInt32(0), // Id
                    rdr.GetString(1), // title
                    rdr.GetString(2), // description
                    rdr.GetString(3), // price
                    rdr.GetString(4), // status
                    rdr.GetInt32(5) // userId
               );
        }

        public Reply GetReplyById(int id)
        {
            using var cmd = new NpgsqlCommand(getReplyById, conn);
            cmd.Parameters.AddWithValue(id);
            using var rdr = cmd.ExecuteReader();
            rdr.Read();

            return new Reply(
                    rdr.GetInt32(0), // Id
                    rdr.GetString(1), // message
                    rdr.GetInt32(2), // price
                    rdr.GetInt32(3), // userId
                    rdr.GetInt32(4) // advertId
                  );
        }

        public bool InsertUser(User u)
        {
            using var cmdd = new NpgsqlCommand(insertUser, conn)
            {
                Parameters = {
                    new() {Value = u.Id},
                    new() {Value = u.Email},
                    new() {Value = u.Password},
                    new() {Value = u.Phone},
                    new() {Value = u.FirstName},
                    new() {Value = u.LastName},
                    new() {Value = u.UserName}
                }
            };
            if (cmdd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }

        public bool InsertAdvert(Advert a)
        {
            using var cmdd = new NpgsqlCommand(insertAdvert, conn)
            {
                Parameters = {
                    new() {Value = a.Id},
                    new() {Value = a.Title},
                    new() {Value = a.Description},
                    new() {Value = a.TotalPrice},
                    new() {Value = a.Status},
                    new() {Value = a.UserId}
                }
            };
            if (cmdd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }

        public bool InsertReply(Reply r)
        {
            using var cmd = new NpgsqlCommand(insertReply, conn)
            {
                Parameters = {
                    new() {Value = r.Id},
                    new() {Value = r.Message},
                    new() {Value = r.Price},
                    new() {Value = r.UserId},
                    new() {Value = r.AdvertId}
                }
            };
            if (cmd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }

        public bool UpdateUser(User u)
        {
            using var cmdd = new NpgsqlCommand(updateUser, conn)
            {
                Parameters = {
                    new() {Value = u.Id},
                    new() {Value = u.Email},
                    new() {Value = u.Password},
                    new() {Value = u.Phone},
                    new() {Value = u.FirstName},
                    new() {Value = u.LastName},
                    new() {Value = u.UserName}
                }
            };
            if (cmdd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }

        public bool UpdateAdvert(Advert a)
        {
            using var cmdd = new NpgsqlCommand(updateAdvert, conn)
            {
                Parameters = {
                    new() {Value = a.Id},
                    new() {Value = a.Title},
                    new() {Value = a.Description},
                    new() {Value = a.TotalPrice},
                    new() {Value = a.Status},
                    new() {Value = a.UserId}
                }
            };
            if (cmdd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }

        public bool UpdateReply(Reply r)
        {
            using var cmd = new NpgsqlCommand(updateReply, conn)
            {
                Parameters = {
                    new() {Value = r.Id},
                    new() {Value = r.Message},
                    new() {Value = r.Price},
                    new() {Value = r.UserId},
                    new() {Value = r.AdvertId}
                }
            };
            if (cmd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }

        public bool DeleteUser(int id)
        {
            using var cmd = new NpgsqlCommand(deleteUserById, conn);
            cmd.Parameters.AddWithValue(id);
            if (cmd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }

        public bool DeleteAdvert(int id)
        {
            using var cmd = new NpgsqlCommand(deleteAdvertById, conn);
            cmd.Parameters.AddWithValue(id);
            if (cmd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }

        public bool DeleteReply(int id)
        {
            using var cmd = new NpgsqlCommand(deleteReplyById, conn);
            cmd.Parameters.AddWithValue(id);
            if (cmd.ExecuteNonQuery() != -1)
                return true;
            return false;
        }
    }
}
