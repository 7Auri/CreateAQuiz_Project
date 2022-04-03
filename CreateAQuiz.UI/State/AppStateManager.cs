using CreateAQuiz.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace CreateAQuiz.UI.State
{
  public class AppStateManager{

    public List<Question> questions=new List<Question>();
    public User user { get; set; }
    public Article Article { get; set; }
    public AppStateManager()
    {
      questions.Add(new Question(){Options=new List<Option>(){new Option(),new Option(),new Option(),new Option()}});
      questions.Add(new Question(){Options=new List<Option>(){new Option(),new Option(),new Option(),new Option()}});
      questions.Add(new Question(){Options=new List<Option>(){new Option(),new Option(),new Option(),new Option()}});
      questions.Add(new Question(){Options=new List<Option>(){new Option(),new Option(),new Option(),new Option()}});
        
    }



  public void UpdateQuestion(Question question,int index){
    
    if(questions.Capacity<=index){
      questions.Add(new Question(){});
    }
    questions[index]=question;
  }
  public void UpdateQuestionOption(int QuestionIndex,int OptionIndex,string value){
  
    questions[QuestionIndex].Options[OptionIndex].Value=value;
  }




  }
    
}
