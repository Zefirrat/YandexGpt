> ! Only **russian** language supported by destination service

[![Release to NuGet](https://github.com/Zefirrat/YandexGpt/actions/workflows/main.yml/badge.svg)](https://github.com/Zefirrat/YandexGpt/actions/workflows/main.yml)

# Description
The basis for using existing methods and models of YandexGpt, as well as creating new ones using a ready-made template. There is an API wrapper and data substitution for authorization.

# Installation
## Nuget
- [Zefirrat.YandexGpt.Abstractions](https://www.nuget.org/packages/Zefirrat.YandexGpt.Abstractions/)
- [Zefirrat.YandexGpt.Api.Contracts](https://www.nuget.org/packages/Zefirrat.YandexGpt.Api.Contracts/)
- [Zefirrat.YandexGpt.Api.Client](https://www.nuget.org/packages/Zefirrat.YandexGpt.Api.Client/)
- [Zefirrat.YandexGpt.AspNet.Di](https://www.nuget.org/packages/Zefirrat.YandexGpt.AspNet.Di/)
- [Zefirrat.YandexGpt.Base](https://www.nuget.org/packages/Zefirrat.YandexGpt.Base/)
- [Zefirrat.YandexGpt.Chatter](https://www.nuget.org/packages/Zefirrat.YandexGpt.Chatter/)
- [Zefirrat.YandexGpt.Prompter](https://www.nuget.org/packages/Zefirrat.YandexGpt.Prompter/)


# Usage
## AspNet
Install [Zefirrat.YandexGpt.AspNet.Di](https://www.nuget.org/packages/Zefirrat.YandexGpt.AspNet.Di/)
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

## Configuration

Main config:  
```json
  "YandexGptOptions": {
    "Client": {
      "AuthenticationScheme": "API-Key",
      "Token": "*******",
      "CatalogId":"********"
    }
  }
```

Additionaly can overwrite default urls and methods, without rebuilding and changing source code:  
```json
  "YandexGptOptions": {
    "Client": {
        // ...
    },
  "Overrides": {
      "LlmBaseUrl": "https://llm.api.cloud.yandex.net/foundationModels/v1/",
      "OperationBaseUrl": "https://operation.api.cloud.yandex.net/operations/",
      "Completion": "completion",
      "CompletionAsync": "completionAsync",
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
