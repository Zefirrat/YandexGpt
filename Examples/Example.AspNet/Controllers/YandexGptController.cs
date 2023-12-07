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

        public YandexGptController(IYaSummarizer summarizer)
        {
            _summarizer = summarizer;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Summarize([FromBody] string text)
        {
            return Ok(await _summarizer.SendAsync(text));
        }
    }
}