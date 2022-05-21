using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    internal struct Request
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double total_price { get; set; }
        public DateOnly date { get; set; }
        public string status { get; set; }

        public Request(int id, int customer_id, string title, string description, double total_price, DateOnly date, string status)
        {
            this.id = id;
            this.customer_id = customer_id;
            this.title = title;
            this.description = description;
            this.total_price = total_price;
            this.date = date;
            this.status = status;
        }
    }
}
