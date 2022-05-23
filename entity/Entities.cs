using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public User(int id, string email, string password, string username, string fname, string lname)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.FirstName = fname;
            this.LastName = lname;
            this.UserName = username;
        }

        public User(string email, string password, string username, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            UserName = username;
            FirstName = firstName;
            LastName = lastName;
        }

        public override String ToString()
        {
            return Id.ToString();
        }
    }

    public class Advert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        public DateTime Posted { get; set;}

        public Advert(int id, string title, string description, string totalPrice, string status, int userId)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalPrice = Convert.ToInt32(totalPrice);
            Status = status;
            UserId = userId;
        }

        public Advert(int id, string title, string description, string totalPrice, string status, int userId, DateTime posted) : 
            this(id, title, description, totalPrice, status, userId)
        {
            Posted = posted;
        }
    }

    public class Reply
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public int AdvertId { get; set; }

        public Reply(int id, string message, int price, int userId, int advertId)
        {
            Id = id;
            Message = message;
            Price = price;
            UserId = userId;
            AdvertId = advertId;
        }

        public Reply(string message, int price, int userId, int advertId)
        {
            Message = message;
            Price = price;
            UserId = userId;
            AdvertId = advertId;
        }
    }
}
