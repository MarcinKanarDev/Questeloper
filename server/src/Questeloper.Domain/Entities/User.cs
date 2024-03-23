using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class User : EntityBase
{
    public EmailAddress EmailAddress { get; private set; }
    public Password HashedPassword { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public NickName NickName { get; private set; }
    public CreatedAt CreatedAt { get; private set; }
    
    public User()
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