using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using CreateAQuiz.Business.DependencyResolvers.Autofac;
using CreateAQuiz.UI.State;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CreateAQuiz.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Startup.ApiURL) });

          

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddSingleton<AppStateManager>();
            builder.Services.AddSingleton<AnswerStateManager>();
            builder.Services.AddSingleton(sp => new HttpClient() { BaseAddress = new Uri(Startup.ApiURL) });
            builder.Services.AddSingleton<IArticleServiceUI, ArticleManagerUI>();
            builder.Services.AddSingleton<IQuizServiceUI, QuizManagerUI>();
            builder.Services.AddSingleton<ILoginService, LoginManager>();
            await builder.Build().RunAsync();
        }
    }
}


