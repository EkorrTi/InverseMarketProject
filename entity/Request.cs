using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseMarketProject.entity
{
    internal class Request
    {
        int id;
        int customer_id;
        string title;
        string description;
        double total_price;
        DateOnly date;
        string status;
    }
}
