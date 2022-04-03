using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.Business.Abstract
{
   public interface IQuizService
    {
        IResult Add(Quiz quiz);
        IResult Delete(Quiz quiz);
        IResult Update(Quiz quiz);
        IDataResult<Quiz> GetById(int quizId);
        IDataResult<List<Quiz>> GetAll();
        Task<IDataResult<List<int>>> CheckAnswer(List<AnswerDto> answers);
       
    }
}
