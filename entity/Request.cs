using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    internal struct Request
    {
        int id;
        int customer_id;
        string title;
        string description;
        double total_price;
        DateOnly date;
        string status;

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
