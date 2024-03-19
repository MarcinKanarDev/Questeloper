using Questeloper.Domain.ValueObjects;

namespace Questeloper.Domain.Entities;

public class User : EntityBase
{
    public EmailAddress EmailAddress { get; private set; }
    public Password HashedPassword { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public NickName NickName { get; private set; }
    
    public User()
    {
    }
    
    public User(EmailAddress emailAddress, Password hashedPassword, FirstName firstName,
        LastName lastName, NickName nickName)
    {
        EmailAddress = emailAddress;
        HashedPassword = hashedPassword;
        FirstName = firstName;
        LastName = lastName;
        NickName = nickName;
    }
}