using CreateAQuiz.Business.Abstract;
using CreateAQuiz.Business.Constants;
using CreateAQuiz.Core.Utilities.Result;
using CreateAQuiz.DataAccess.Abstract;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public IResult Add(Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Question question)
        {
            _questionDal.Delete(question);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Question>> GetAll()
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<Question> GetById(int questionId)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(x => x.Id == questionId), Messages.SuccessListed);
        }

        public IResult Update(Question question)
        {
            _questionDal.Update(question);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
