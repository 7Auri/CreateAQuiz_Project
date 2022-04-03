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
   public class EfArticleDal : EfEntityRepositoryBase<Article, QuizDbContext>, IArticleDal
    {
        public DateTime LastUpdateDate()
        {
            using (var context = new QuizDbContext())
            {

                return context.Articles.OrderByDescending(item => item.PublishRssDate).Select(c => c.PublishRssDate).FirstOrDefault();
            }
        }
    }
}
