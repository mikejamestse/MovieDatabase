using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly WebApp1.Data.ApplicationDbContext _context;

        public IndexModel(WebApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString {get;set;}
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Linq query for the search functionnality.
            var movies = from m in _context.Movie select m;

            // Searches for movie by title.
            if (!string.IsNullOrEmpty(SearchString)) {
                movies = movies.Where(s => s.Title.ToLower().Contains(SearchString.ToLower()) || 
                s.Director.ToLower().Contains(SearchString.ToLower()));
            }

            Movie = await movies.ToListAsync();
        }
    }
}
