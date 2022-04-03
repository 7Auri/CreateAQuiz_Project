using CreateAQuiz.Business.Abstract;
using CreateAQuiz.Business.Constants;
using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.DataAccess.Abstract;
using CreateAQuiz.Entities.Concrete;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CreateAQuiz.Business.Concrete
{
    public class QuizManager : IQuizService
    {
        IQuizDal _quizDal;
        HttpClient _http;

        public QuizManager(IQuizDal quizDal, HttpClient http)
        {
            _quizDal = quizDal;
            _http = http;
        }

        public IResult Add(Quiz quiz)
        {
            _quizDal.Add(quiz);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IDataResult<List<int>>> CheckAnswer(List<AnswerDto> answers)
        {
            var result = await _http.PostAsJsonAsync($"useranswer/check", answers);
            return await result.Content.ReadFromJsonAsync<IDataResult<List<int>>>();
        }



        public IResult Delete(Quiz quiz)
        {
            _quizDal.Delete(quiz);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Quiz>> GetAll()
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll(), Messages.SuccessListed);
        }


        public IDataResult<Quiz> GetById(int quizId)
        {
            return new SuccessDataResult<Quiz>(_quizDal.Get(x => x.Id == quizId), Messages.SuccessListed);
        }


        public IResult Update(Quiz quiz)
        {
            _quizDal.Update(quiz);
            return new SuccessResult(Messages.SuccessUpdate);
        }




    }
}
