
using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Core.Utilities.Security.Jwt;
using CreateAQuiz.Entities.Concrete;
using CreateAQuiz.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<Token> CreateToken(User user);
    }
}
