using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Zefirrat.YandexGpt.Abstractions;

namespace Example.AspNet.Controllers
{
    [Route("[controller]")]
    public class YandexGptController : Controller
    {
        private readonly IYaSummarizer _summarizer;
        private readonly IYaPrompter _prompter;

        public YandexGptController(IYaSummarizer summarizer, IYaPrompter prompter)
        {
            _summarizer = summarizer;
            _prompter = prompter;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Summarize([FromBody] string text)
        {
            return Ok(await _summarizer.SendAsync(text));
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Prompt([FromBody] string text)
        {
            return Ok(await _prompter.SendAsync(text));
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PromptToken([FromBody] (string Message, int Token) text)
        {
            return Ok(await _prompter.SendAsync(text.Message, text.Token));
        }
    }
}