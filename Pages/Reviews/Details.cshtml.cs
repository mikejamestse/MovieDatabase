using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.Reviews
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp1.Data.ApplicationDbContext _context;

        public DetailsModel(WebApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Review.FirstOrDefaultAsync(m => m.ID == id);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
