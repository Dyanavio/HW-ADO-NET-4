using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HW_ADO_NET_4
{
    class Item
    {
        public int Id { get; set; }
        public string Sort { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Grams { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} | Sort: {Sort} | Country: {Country} | Type: {Type} | Description: {Description} | Grams: {Grams} | Price: {Price}";
        }
    }
}
