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
        private static readonly String getRepliesByAdvertId = "SELECT * FROM reply WHERE advert_id=$1;";
        private static readonly String getUserById = "SELECT * FROM userss WHERE id=$1";
        private static readonly String getUserByUsername = "SELECT * FROM userss WHERE username = $1;";
        private static readonly String getUserByEmail = "SELECT * FROM userss WHERE email = $1;";
        private static readonly String getUserByEmailAndPassword = "SELECT * FROM userss WHERE email = $1 AND password = $2";
        private static readonly String getAdvertById = "SELECT * FROM advert WHERE id=$1";
        private static readonly String getReplyById = "SELECT * FROM advert WHERE id=$1";
        private static readonly String insertUser = "INSERT INTO userss (email, password, first_name, last_name, username) VALUES($1, $2, $3, $4, $5)"; // id, email, password, fname, lname, username
        private static readonly String insertAdvert = "INSERT INTO advert (title, description, total_price, status, user_id) VALUES($1, $2, $3, $4, $5)"; // id, title, desc, price, status, userId
        private static readonly String insertReply = "INSERT INTO reply (message, price, user_id, advert_id) VALUES($1, $2, $3, $4)"; // id, message, price, userId, advertId
        private static readonly String updateUser = "UPDATE userss SET email=$2, password=$3, first_name=$4, last_name=$5, username=$6 WHERE id=$1";
        private static readonly String updateAdvert = "UPDATE advert SET title=$2, description=$3, total_price=$4, status=$5, user_id=$6 WHERE id=$1";
        private static readonly String updateReply = "UPDATE reply SET message=$2, price=$3, user_id=$4, advert_id=$5 WHERE id=$1";
        private static readonly String deleteUserById = "DELETE FROM userss WHERE id = $1";
        private static readonly String deleteAdvertById = "DELETE FROM advert WHERE id = $1";
        private static readonly String deleteReplyById = "DELETE FROM reply WHERE id = $1";

        public async Task<NpgsqlDataReader> query(string query)
        {   
            using (var command = new NpgsqlCommand(query, conn))
            {
                var result = await command.ExecuteReaderAsync();
                return result;
            }
        }

        public async Task<NpgsqlDataReader> query(NpgsqlCommand cmd)
        {

            var result = await cmd.ExecuteReaderAsync();
            return result;
        }

        public async Task<int> nonQuery(NpgsqlCommand cmd)
        {

            var result = await cmd.ExecuteNonQueryAsync();
            return result;
        }

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
                     rdr.GetString(3), // fname
                     rdr.GetString(4), // lname
                     rdr.GetString(5) // username
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
                    rdr.GetInt32(5), // userId
                    rdr.GetDateTime(6) // Posted
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
                     rdr.GetString(3), // fname
                     rdr.GetString(4), // lname
                     rdr.GetString(5) // username
                     );
        }

        public User? GetUserByUsername(String username)
        {
            using var cmd = new NpgsqlCommand(getUserByUsername, conn);
            cmd.Parameters.AddWithValue(username);
            using var rdr = cmd.ExecuteReader();
            if( rdr.Read() )
                return new User(
                        rdr.GetInt32(0), // Id
                        rdr.GetString(1), // email
                        rdr.GetString(2), // password
                        rdr.GetString(3), // fname
                        rdr.GetString(4), // lname
                        rdr.GetString(5) // username
                     );
            return null;
        }

        public User? GetUserByEmail(String email)
        {
            using var cmd = new NpgsqlCommand(getUserByEmail, conn);
            cmd.Parameters.AddWithValue(email);
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
                return new User(
                         rdr.GetInt32(0), // Id
                         rdr.GetString(1), // email
                         rdr.GetString(2), // password
                         rdr.GetString(3), // fname
                         rdr.GetString(4), // lname
                         rdr.GetString(5) // username
                     );
            return null;
        }

        public User? GetUserByEmailAndPassword(string email, string password)
        {
            using var cmd = new NpgsqlCommand(getUserByEmailAndPassword, conn);
            cmd.Parameters.AddWithValue(email);
            cmd.Parameters.AddWithValue(password);
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
                return new User(
                         rdr.GetInt32(0), // Id
                         rdr.GetString(1), // email
                         rdr.GetString(2), // password
                         rdr.GetString(3), // fname
                         rdr.GetString(4), // lname
                         rdr.GetString(5) // username
                     );
            return null;
        }

        public Advert? GetAdvertById(int id)
        {
            using var cmd = new NpgsqlCommand(getAdvertById, conn);
            cmd.Parameters.AddWithValue(id);
            using var rdr = cmd.ExecuteReader();
            if ( rdr.Read() )
                return new Advert(
                    rdr.GetInt32(0), // Id
                    rdr.GetString(1), // title
                    rdr.GetString(2), // description
                    rdr.GetString(3), // price
                    rdr.GetString(4), // status
                    rdr.GetInt32(5) // userId
               );
            return null;
        }

        public Reply? GetReplyById(int id)
        {
            using var cmd = new NpgsqlCommand(getReplyById, conn);
            cmd.Parameters.AddWithValue(id);
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
                return new Reply(
                    rdr.GetInt32(0), // Id
                    rdr.GetString(1), // message
                    rdr.GetInt32(2), // price
                    rdr.GetInt32(3), // userId
                    rdr.GetInt32(4) // advertId
                  );
            return null;
        }

        public List<Reply> GetRepliesByAdvertId(int advertId)
        {
            using var cmd = new NpgsqlCommand(getRepliesByAdvertId, conn);
            cmd.Parameters.AddWithValue(advertId);
            using var rdr = cmd.ExecuteReader();
            List<Reply> replies = new();
            while (rdr.Read())
            {
                replies.Add(new Reply(
                    rdr.GetInt32(0), // Id
                    rdr.GetString(1), // message
                    rdr.GetInt32(2), // price
                    rdr.GetInt32(3), // userId
                    rdr.GetInt32(4) // advertId
                    ));
            }
            return replies;
        }

        public bool InsertUser(User u)
        {
            using var cmd = new NpgsqlCommand(insertUser, conn)
            {
                Parameters = {
                    new() {Value = u.Email},
                    new() {Value = u.Password},
                    new() {Value = u.FirstName},
                    new() {Value = u.LastName},
                    new() {Value = u.UserName}
                }
            };
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
        }

        public bool InsertAdvert(Advert a)
        {
            using var cmd = new NpgsqlCommand(insertAdvert, conn)
            {
                Parameters = {
                    new() {Value = a.Title},
                    new() {Value = a.Description},
                    new() {Value = a.TotalPrice},
                    new() {Value = a.Status},
                    new() {Value = a.UserId}
                }
            };
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
        }

        public bool InsertReply(Reply r)
        {
            using var cmd = new NpgsqlCommand(insertReply, conn)
            {
                Parameters = {
                    new() {Value = r.Message},
                    new() {Value = r.Price},
                    new() {Value = r.UserId},
                    new() {Value = r.AdvertId}
                }
            };
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
        }

        public bool UpdateUser(User u)
        {
            using var cmd = new NpgsqlCommand(updateUser, conn)
            {
                Parameters = {
                    new() {Value = u.Id},
                    new() {Value = u.Email},
                    new() {Value = u.Password},
                    new() {Value = u.FirstName},
                    new() {Value = u.LastName},
                    new() {Value = u.UserName}
                }
            };
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
        }

        public bool UpdateAdvert(Advert a)
        {
            using var cmd = new NpgsqlCommand(updateAdvert, conn)
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
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
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
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
        }

        public bool DeleteUser(int id)
        {
            using var cmd = new NpgsqlCommand(deleteUserById, conn);
            cmd.Parameters.AddWithValue(id);
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
        }

        public bool DeleteAdvert(int id)
        {
            using var cmd = new NpgsqlCommand(deleteAdvertById, conn);
            cmd.Parameters.AddWithValue(id);
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
        }

        public bool DeleteReply(int id)
        {
            using var cmd = new NpgsqlCommand(deleteReplyById, conn);
            cmd.Parameters.AddWithValue(id);
            var rdr = cmd.ExecuteNonQuery();
            return (rdr != -1);
        }
    }
}
