namespace Questeloper.Domain.Entities;

public class TextAnswerQuestion : Question
{
    public string CorrectAnswer { get; private set; } = string.Empty;
}