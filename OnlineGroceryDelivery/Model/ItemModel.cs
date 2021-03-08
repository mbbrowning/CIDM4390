using System.Collections.Generic;
using System; 
using System.Linq; 
using System.Threading.Tasks;

namespace DeliveryCart.Models
{
    public class ItemModel
    {
        public int ID { get; set; }
        public string item_name { get; set; }
        public string price { get; set; }
        public string item_photo { get; set; }
        public string description { get; set; }
        public string stock { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}