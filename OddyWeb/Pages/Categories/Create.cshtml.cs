using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OddyWeb.Data;
using OddyWeb.Model;

namespace OddyWeb.Pages.Categories
{
    //[BindProperties]  //binds all of the properties of the class
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]    //Uses Category property inside methods 
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync(); 
            return RedirectToPage("Index");
        }
    }
}
