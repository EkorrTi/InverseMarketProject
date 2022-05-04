using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    internal struct Customer
    {
        int id;
        string email;
        string password;
        string phone_number;

        public Customer(int id, string email, string password, string phone_number)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.phone_number = phone_number;
        }
    }
}
