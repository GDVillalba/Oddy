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
            if(Category.Name == Category.DisplayOrder.ToString() )  // Custom Validation.
            {
                ModelState.AddModelError(String.Empty, "The Dislay Order cannot exactly match the Name.");
            }

            if (ModelState.IsValid) //server side validation of Model
            {
                await _db.Categories.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Created Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
