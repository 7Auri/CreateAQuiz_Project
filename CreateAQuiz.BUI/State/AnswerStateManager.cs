using CreateAQuiz.Entities.Concrete;
using System.Collections.Generic;


namespace CreateAQuiz.UI.State
{
  public class AnswerStateManager
  {
    public List<AnswerDto> answers = new List<AnswerDto>();
    public List<int> questionResult = new List<int>();

  }
}