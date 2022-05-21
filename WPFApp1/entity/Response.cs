using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    internal struct Response
    {
        public int id { get; set; }
        public int request_id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public double total_price { get; set; }
        public string phone_number { get; set; }

        public Response(int id, int request_id, string title, string message, double total_price, string phone_number)
        {
            this.id=id;
            this.request_id=request_id;
            this.title=title;
            this.message=message;
            this.total_price=total_price;
            this.phone_number=phone_number;
        }
    }
}
