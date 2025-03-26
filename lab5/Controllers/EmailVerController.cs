using Microsoft.AspNetCore.Mvc;
using lab5.Services;
using System.Threading.Tasks;
using System.Web;

namespace lab5.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailVerController : ControllerBase
    {
        private readonly ApiClient _apiClient;

        public EmailVerController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("verify")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest(new { message = "Email is required" });

            var encodedEmail = HttpUtility.UrlEncode(email);

            var result = await _apiClient.GetAsync<EmailVerificationResult>($"check?email={encodedEmail}");

            return StatusCode(result.StatusCode, result);
        }
    }

    public class EmailVerificationResult
    {
        public string Email { get; set; }
        public bool? DidYouMean { get; set; }
        public string User { get; set; }
        public string Domain { get; set; }
        public bool FormatValid { get; set; }
        public bool? Free { get; set; }
        public double? Score { get; set; }
    }
}
