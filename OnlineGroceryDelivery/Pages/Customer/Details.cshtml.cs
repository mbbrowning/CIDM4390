using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryDelivery;

namespace OnlineGroceryDelivery.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly OnlineGroceryDelivery.OnlineGroceryDeliveryContext _context;

        public DetailsModel(OnlineGroceryDelivery.OnlineGroceryDeliveryContext context)
        {
            _context = context;
        }

        public Models.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
