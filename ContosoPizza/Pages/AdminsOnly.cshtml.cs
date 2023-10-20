using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPizza.Pages
{
    [Authorize(Policy = "Admin")]
    public class AdminsOnlyModel : PageModel
    {
        private readonly ILogger<AdminsOnlyModel> _logger;

        public AdminsOnlyModel(ILogger<AdminsOnlyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
