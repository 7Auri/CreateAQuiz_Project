
using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreateAQuiz.UI.State
{
   public interface IQuizServiceUI
    {
        IResult Add(Quiz quiz);
        IResult Delete(Quiz quiz);
        IResult Update(Quiz quiz);
        IDataResult<Quiz> GetById(int quizId);
        IDataResult<List<Quiz>> GetAll();
        Task<IDataResult<List<int>>> CheckAnswer(List<AnswerDto> answers);
        public Task<int> CreateQuiz(int UserId);
        public Task<IDataResult<List<Quiz>>> GetAllQuiz();
    }
}
