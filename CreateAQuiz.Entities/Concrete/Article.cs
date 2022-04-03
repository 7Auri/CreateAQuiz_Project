
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.Entities.Concrete
{
   public class Article : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public DateTime PublishArticleDate { get; set; }
        public DateTime PublishRssDate { get; set; }
    }
}
