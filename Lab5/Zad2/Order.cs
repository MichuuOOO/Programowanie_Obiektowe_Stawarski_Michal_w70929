using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad2;
namespace Zad2
{
    public class Order(int orderNumber, List<string> produkty, StatusZamowienia status)
    {
        public int OrderNumber { get; set; } = orderNumber;
        public StatusZamowienia Status { get; set; } = status;
        public List<string> Produkty { get; set; } = produkty;
    }
}
