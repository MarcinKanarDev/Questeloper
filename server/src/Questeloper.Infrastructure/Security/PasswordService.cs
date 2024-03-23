using Microsoft.AspNetCore.Identity;
using Questeloper.Application.Security;
using Questeloper.Domain.Entities;

namespace Questeloper.Infrastructure.Security;

internal sealed class PasswordService(IPasswordHasher<User> passwordHasher) : IPasswordService
{
    public string SecurePassword(string password) =>
        passwordHasher.HashPassword(default, password);

    public bool Validate(string password, string hashedPassword) =>
        passwordHasher.VerifyHashedPassword(default, hashedPassword, password)
            is PasswordVerificationResult.Success;
}