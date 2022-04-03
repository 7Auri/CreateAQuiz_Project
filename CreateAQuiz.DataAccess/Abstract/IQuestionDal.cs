using CreateAQuiz.Core.DataAccess;
using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.DataAccess.Abstract
{
   public interface IQuestionDal : IEntityRepository<Question>
    {
    }
}
