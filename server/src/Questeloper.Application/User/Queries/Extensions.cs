namespace Questeloper.Application.User.Queries;

public static class Extensions
{
    public static GetUserResponse ToResponse(this Domain.Entities.User user) =>
        new GetUserResponse(
            user.NickName.Value,
            user.EmailAddress.Value);
}