using ZodiacLab.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ZodiacLab.Pages;

public class IndexModel : PageModel
{
   [Display(Name="Year")]
   [BindProperty]
    public int Years { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public void OnGet()
    {
        ViewData["Zodiac"] = "";
        ViewData["isPost"] = false;
    }

    public void OnPost()
    {
        ViewData["isPost"] = true;
        if (Years >= 1900 && Years <= DateTime.Now.Year + 1) {
            ViewData["Zodiac"] = Utils.GetZodiac(Years);
        } else {
            ViewData["Zodiac"] = "";
        }

    }

}
