using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryDelivery;

namespace OnlineGroceryDelivery.Pages.DeliveryPerson
{
    public class IndexModel : PageModel
    {
        private readonly OnlineGroceryDeliveryContext _context;

        public IndexModel(OnlineGroceryDeliveryContext context)
        {
            _context = context;
        }

        public IList<Models.DeliveryPerson> DeliveryPerson { get;set; }

        public async Task OnGetAsync()
        {
            DeliveryPerson = await _context.DeliveryPerson.ToListAsync();
        }
    }
}
