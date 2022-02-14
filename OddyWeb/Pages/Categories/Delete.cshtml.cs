using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OddyWeb.Data;
using OddyWeb.Model;

namespace OddyWeb.Pages.Categories
{
    //[BindProperties]  //binds all of the properties of the class
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]    //Uses Category property inside methods 
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            Category = _db.Categories.Find(id);  // Find solo sirve para traer con la clave primaria
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _db.Categories.Find(Category.Id); //As the fields Name and DisplayOrder are disabled Category only contains Category.Id

            if (categoryFromDb != null) 
            {
                _db.Categories.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
