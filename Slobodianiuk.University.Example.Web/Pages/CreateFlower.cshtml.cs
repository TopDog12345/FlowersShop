using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Logging;
using Slobodianiuk.University.Example.Models.Database;
using Slobodianiuk.University.Example.Models.Frontend;
using Slobodianuik.University.Example.Database.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Slobodianiuk.University.Example.Web.Pages
{
    public class CreateFlowerModel : PageModel
    {
        [BindProperty]
        public CreateFlowerRequest Flower { get; set; }

        private readonly IDbEntityService<Flower> _flowerService;

        public CreateFlowerModel(IDbEntityService<Flower> flowerService)
        {
            _flowerService = flowerService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
               
                return Page();
            }

            if (Flower == null)
            {
                return Page();
            }


            await _flowerService.Create(new Flower()
            {
                Name = Flower?.Name,
                price = Flower?.price
            });

            return new RedirectToPageResult("/FlowerList");
        }
    }
}
