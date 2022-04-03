using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Entities.Concrete;
using CreateAQuiz.Entities.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace CreateAQuiz.UI.State
{
  public class LoginManager : ILoginService
  {
    private HttpClient _http { get; set; }
    private AppStateManager _state { get; set; }
    public LoginManager(HttpClient http, AppStateManager state)
    {
      _http = http;
      _state = state;

    }

    public async Task<IDataResult<User>> Login(UserForLoginDto auth)
    {
      HttpResponseMessage response = await _http.PostAsJsonAsync("http://localhost:5000/api/auth/login", auth);

      if (response.IsSuccessStatusCode)
      {
        var json = await response.Content.ReadFromJsonAsync<IDataResult<User>>();
        return json;
      }
      return null;
    }
  }
}
