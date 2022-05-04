using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    internal struct Vendor
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone_number { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }

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
