using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OddyWeb.Data;
using OddyWeb.Model;

namespace OddyWeb.Pages.Categories
{
    //[BindProperties]  //binds all of the properties of the class
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]    //Uses Category property inside methods 
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            Category = _db.Categories.Find(id);  // Find solo sirve para traer con la clave primaria
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) //server side validation of Model
            {
                _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
