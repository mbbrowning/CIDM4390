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
    public class IndexModel : PageModel
    {
        private readonly OnlineGroceryDeliveryContext _context;

        public IndexModel(OnlineGroceryDeliveryContext context)
        {
            _context = context;
        }

        public IList<Models.Customer> Customer { get;set; }

        public OnlineGroceryDeliveryContext Context => _context;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
