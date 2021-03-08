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
    public class DeleteModel : PageModel
    {
        private readonly OnlineGroceryDelivery.OnlineGroceryDeliveryContext _context;

        public DeleteModel(OnlineGroceryDelivery.OnlineGroceryDeliveryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.DeliveryPerson DeliveryPerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeliveryPerson = await _context.DeliveryPerson.FirstOrDefaultAsync(m => m.DeliveryPersonId == id);

            if (DeliveryPerson == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeliveryPerson = await _context.DeliveryPerson.FindAsync(id);

            if (DeliveryPerson != null)
            {
                _context.DeliveryPerson.Remove(DeliveryPerson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
