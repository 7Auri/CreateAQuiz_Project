using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace CreateAQuiz.UI.State
{
    public class ArticleManagerUI : IArticleServiceUI
    {
        private HttpClient _http;
        public ArticleManagerUI(HttpClient http)
        {
            _http = http;

        }

        public async Task<IDataResult<List<Article>>> GetAll()
        {
            return await _http.GetFromJsonAsync<IDataResult<List<Article>>>("http://localhost:5000/api/article");

        }

        public async Task<IResult> Sync()
        {
            return await _http.GetFromJsonAsync<IResult>("http://localhost:5000/api/article/sync");
        }
       
    }
}
