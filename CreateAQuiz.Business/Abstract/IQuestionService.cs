using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.Business.Abstract
{
    public interface IQuestionService
    {
        IResult Add(Question question);
        IResult Delete(Question question);
        IResult Update(Question question);
        IDataResult<Question> GetById(int questionId);
        IDataResult<List<Question>> GetAll();
    }
}
