namespace fragenkatalog;

public class Assesment
{
    public List<QandA> AssessmentQuestions { get; private set; }
    
    public Assesment(List<QandA> questions, int size = 10)
    {
        foreach (var question in questions)
        {
            question.Order = question.Points + Random.Shared.Next(questions.Count); 
        }

        AssessmentQuestions = questions.OrderBy(q => q.Order).Take(size).ToList();
    }
}