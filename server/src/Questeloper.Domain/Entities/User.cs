using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class User : EntityBase
{
    public EmailAddress EmailAddress { get; private set; } = null!;
    public Password HashedPassword { get; private set; } = null!;   
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public NickName NickName { get; private set; } = null!;
    public CreatedAt CreatedAt { get; private set; } = null!;
    
    private User()
    {
    }
    
    public User(string emailAddress, string hashedPassword, string firstName,
        string lastName, string nickName, DateTime createdAt)
    {
        EmailAddress = new EmailAddress(emailAddress);
        HashedPassword = new Password(hashedPassword);
        FirstName = new FirstName(firstName);
        LastName = new LastName(lastName);
        NickName = new NickName(nickName);
        CreatedAt = new CreatedAt(createdAt);
    }
}