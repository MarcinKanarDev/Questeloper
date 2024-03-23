namespace Questeloper.Application.Security;

public interface IPasswordService
{
    public string SecurePassword(string password);
    public bool Validate(string password, string hashedPassword);
}