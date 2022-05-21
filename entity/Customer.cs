using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    public struct Customer
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone_number { get; set; }

        public Customer(int id, string email, string password, string phone_number)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.phone_number = phone_number;
        }

        public override string ToString()
        {
            string str = base.ToString() + $" [id:{id}, email:{email}, password:{password}, phone_number:{phone_number}]";
            return str;
        }
    }
}
