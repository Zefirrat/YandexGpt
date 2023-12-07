> ! Only **russian** language supported

# Description
The basis for using existing methods and models of YandexGpt, as well as creating new ones using a ready-made template. There is an API wrapper and data substitution for authorization.

# Installation
// Todo: add Nugets

# Usage
## AspNet
// Todo: add link
Install [Zefirrat.YandexGpt.AspNet.Di]()
In `Configure` class add:
```csharp
            services.AddYandexGpt(Configuration);
```

Then use in controller something like that:
```csharp
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
    }
}
```

# Example
Swagger provided:
[Examples/Example.AspNet](https://github.com/Zefirrat/YandexGpt/tree/1e2c31c04c98d99c85367b289434ec56d2a6d47d/Examples/Example.AspNet)

![image](https://github.com/Zefirrat/YandexGpt/assets/37443756/566ce130-2dd1-4484-a2b4-6a6f3a91e8e4)

# Custom trained models
To implement work with custom trained model inherit from `YandexGptBase` and overwrite the `Model` to the name of your trained model, then change settings.  
> See [Yandex cloud doc. Tuned models.](https://cloud.yandex.ru/docs/datasphere/concepts/models/tuned-models)
