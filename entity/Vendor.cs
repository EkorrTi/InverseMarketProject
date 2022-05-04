using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    internal struct Vendor
    {
        int id;
        string email;
        string password;
        string phone_number;
        string company_name;
        string address;

        public Vendor(int id, string email, string password, string phone_number, string company_name, string address)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.phone_number = phone_number;
            this.company_name = company_name;
            this.address = address;
        }
    }
}
