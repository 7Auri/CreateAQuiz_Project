using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace CreateAQuiz.UI.State
{
   public interface IArticleServiceUI 
   {
      Task<IDataResult<List<Article>>> GetAll();
      Task<IResult> Sync();
      

   }
}