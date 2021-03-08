using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryDelivery;

namespace OnlineGroceryDelivery.Pages.DeliveryPerson
{
    public class EditModel : PageModel
    {
        private readonly OnlineGroceryDelivery.OnlineGroceryDeliveryContext _context;

        public EditModel(OnlineGroceryDelivery.OnlineGroceryDeliveryContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeliveryPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryPersonExists(DeliveryPerson.DeliveryPersonId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeliveryPersonExists(int id)
        {
            return _context.DeliveryPerson.Any(e => e.DeliveryPersonId == id);
        }
    }
}
