using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives; // Add this for StringValues

namespace ChequeWriterApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Property to store the submitted amount
        public string SubmittedAmount { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // Handle form submissions
        public void OnPost()
        {
            // Get the form value safely
            if (Request.Form.TryGetValue("amount", out StringValues amount))
            {
                // Assign the first value or an empty string if it's null
                SubmittedAmount = amount.ToString() ?? string.Empty;
            }
            else
            {
                // Handle the case where the form field does not exist
                SubmittedAmount = "No input provided.";
            }
        }

        public void OnGet()
        {

        }
    }
}
