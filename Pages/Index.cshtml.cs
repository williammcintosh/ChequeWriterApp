using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives; // Add this for StringValues

namespace ChequeWriterApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Properties to store the submitted amount and its conversion
        public string SubmittedAmount { get; set; } = string.Empty;
        public string ConvertedAmount { get; set; } = string.Empty;

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

                // Validate the input and convert it
                if (decimal.TryParse(SubmittedAmount, out decimal number))
                {
                    ConvertedAmount = NumberToWordsConverter.Convert(number);
                }
                else
                {
                    ConvertedAmount = "Invalid input. Please enter a valid number.";
                }
            }
            else
            {
                // Handle the case where the form field does not exist
                SubmittedAmount = "No input provided.";
                ConvertedAmount = string.Empty;
            }
        }

        public void OnGet()
        {
        }
    }
}
