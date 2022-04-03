

using CreateAQuiz.Business.Constants;
using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.DataAccess.Abstract;
using CreateAQuiz.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CreateAQuiz.UI.State
{
    public class QuizManagerUI : IQuizServiceUI
    {
        IQuizDal _quizDal;
        HttpClient _http;
        AppStateManager _state;
        public QuizManagerUI(IQuizDal quizDal, HttpClient http, AppStateManager state)
        {
            _quizDal = quizDal;
            _http = http;
            _state = state;
        }

        public IResult Add(Quiz quiz)
        {
             _quizDal.Add(quiz);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public async Task<IDataResult<List<int>>> CheckAnswer(List<AnswerDto> answers)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:5000/api/useranswer/check", answers);
            return await result.Content.ReadFromJsonAsync<IDataResult<List<int>>>();
        }

        public async Task<int> CreateQuiz(int userId)
        {

            try
            {
                CheckStateQuestionValidation();
                var quiz = await AddQuiz(userId);

                QuestionMapping(quiz.Id, userId);
                return Convert.ToInt16(OperationResponse.Success);

            }

            catch (System.Exception)
            {

                return Convert.ToInt16(OperationResponse.Fail);
            }

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
        async Task<IDataResult<List<Quiz>>> IQuizServiceUI.GetAllQuiz()
        {
            return await _http.GetFromJsonAsync<IDataResult<List<Quiz>>>($"http://localhost:5000/api/quiz");
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
        private async void QuestionMapping(int quizId, int userId)
        {

            try
            {
                for (int i = 0; i < _state.questions.Count; i++)
                {

                    _state.questions[i].QuizId = quizId;
                    _state.questions[i].ContentId = _state.Article.Id;
                    _state.questions[i].Order = i;
                    _state.questions[i].UserId = userId;
                    HttpResponseMessage addedQuestionResponse = await _http.PostAsJsonAsync($"http://localhost:5000/api/question", _state.questions[i]);
                    DataResult<Question> addedQuestion = await addedQuestionResponse.Content.ReadFromJsonAsync<DataResult<Question>>();


                    for (int k = 0; k < _state.questions[i].Options.Count; k++)
                    {


                        _state.questions[i].Options[k].Order = k;
                        _state.questions[i].Options[k].QuestionId = addedQuestion.Data.Id;
                        await _http.PostAsJsonAsync($"http://localhost:5000/api/option", _state.questions[i].Options[k]);


                    }
                }
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }


        }
        private async Task<Quiz> AddQuiz(int userId)
        {


            Quiz quiz = new Quiz()
            {
                ContentId = _state.Article.Id,
                UserId = userId
            };

            HttpResponseMessage quizResponse = await _http.PostAsJsonAsync($"quiz", quiz);
            var result = JsonConvert.DeserializeObject<DataResult<Quiz>>(await quizResponse.Content.ReadAsStringAsync());
            return result.Data;
        }
        private void CheckStateQuestionValidation()
        {

            foreach (var item in _state.questions)
            {
                if (!string.IsNullOrWhiteSpace(item.QuestionText))
                {
                    var isSelectedCorrectAnswerForQuestion = item.Options.Where(item => item.isCorrect == true).First();

                    if (isSelectedCorrectAnswerForQuestion == null)
                    {
                        throw new Exception();

                    }
                    foreach (var option in item.Options)
                    {
                        if (!string.IsNullOrWhiteSpace(option.Value))
                        {


                        }
                        else
                        {
                            throw new Exception();
                        }

                    }
                }
                else
                {
                    throw new Exception();
                }

            }

        }
    }
}
