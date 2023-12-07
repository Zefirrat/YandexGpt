using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zefirrat.YandexGpt.Abstractions;
using Zefirrat.YandexGpt.Api.Client;
using Zefirrat.YandexGpt.Base;
using Zefirrat.YandexGpt.Chatter;
using Zefirrat.YandexGpt.Prompter;
using Zefirrat.YandexGpt.Summarizer;

namespace Zefirrat.YandexGpt.AspNet.Di
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddYandexGpt(
            this IServiceCollection serviceCollection,
            bool useDefaultConfiguration = true)
        {
            serviceCollection.AddHttpClient(nameof(YaClient));
            serviceCollection.AddScoped<IYaClient, YaClient>();
            serviceCollection.AddTransient<IYaPrompter, YaPrompter>();
            serviceCollection.AddTransient<IYaChatter, YaChatter>();
            serviceCollection.AddTransient<IYaSummarizer, YaSummarizer>();

            if (useDefaultConfiguration)
            {
                var configuration = serviceCollection.BuildServiceProvider()
                    .GetRequiredService<IConfiguration>();
                serviceCollection.Configure<YandexGptOptions>(configuration.GetSection(nameof(YandexGptOptions)));
                serviceCollection.Configure<YaClientOptions>(configuration.GetSection(nameof(YandexGptOptions))
                    .GetSection(nameof(YaClientOptions)));
            }

            return serviceCollection;
        }
    }
}