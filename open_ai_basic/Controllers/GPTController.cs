using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;

namespace open_ai_basic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GPTController : Controller
    {
        [HttpGet("OpenAI")]
        public async Task<IActionResult> OpenAI()
        {
            string Repon = "";
            string api = "";

            var client = new OpenAI_API.OpenAIAPI(api);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = "";
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 1024;

            var completionOpenAi= await client.Completions.CreateCompletionAsync(completionRequest);
            foreach (var completion in completionOpenAi.Completions)
            {
                Repon += completion.Text;
            }


            return Ok(Repon);
        }
    }
}
