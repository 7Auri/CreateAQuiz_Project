
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.Entities.Concrete
{
   public class Quiz : IEntity
    {
        public int Id { get; set; }
        public string Session { get; set; }

        public int ContentId { get; set; }
        public int UserId { get; set; }

        public Article Article { get; set; }
        public List<Question> questions { get; set; }
        public User User { get; set; }
    }
}
