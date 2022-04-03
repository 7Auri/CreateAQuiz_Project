using Blazored.LocalStorage;
using CreateAQuiz.UI.State;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.UI
{
    public static class Start
    {
        public static string ApiURL = @"http://localhost:7001/api/";

    }
}
