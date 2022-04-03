using CreateAQuiz.Core.DataAccess;
using CreateAQuiz.DataAccess.Abstract;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.DataAccess.Concrete
{
   public class EfQuestionDal : EfEntityRepositoryBase<Question, QuizDbContext>, IQuestionDal
    {
    }
}
