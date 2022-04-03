namespace CreateAQuiz.Entities.Concrete
{
  public class AnswerDto:IDto
  {
    public int QuizId { get; set; }
    public int QuestionId { get; set; }
    public int SelectedOptionId { get; set; }
    public int UserId { get; set; }

  }

}