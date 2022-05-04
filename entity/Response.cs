using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    internal struct Response
    {
        int id=0;
        int request_id=0;
        int response_id=0;
        string title="";
        string message="";
        double total_price=0;
        string phone_number="";

        public Response(int id, int request_id, int response_id, string title, string message, double total_price, string phone_number)
        {
            this.id=id;
            this.request_id=request_id;
            this.response_id=response_id;
            this.title=title;
            this.message=message;
            this.total_price=total_price;
            this.phone_number=phone_number;
        }
    }
}
