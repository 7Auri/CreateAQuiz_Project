using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Entities.Concrete;
using CreateAQuiz.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace CreateAQuiz.UI.State
{
   public interface ILoginService
    {
        public Task<IDataResult<User>> Login(UserForLoginDto auth);
    }
}
