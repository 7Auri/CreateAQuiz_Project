using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.Business.Abstract
{
   public interface IArticleService
    {
        IResult Add(Article article);
        IResult Delete(Article article);
        IResult Update(Article article);
        IDataResult<Article> GetById(int articleId);
        IDataResult<List<Article>> GetAll();
        IResult SyncArticleWithWired();
    }
}
