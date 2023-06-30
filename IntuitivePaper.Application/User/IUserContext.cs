namespace IntuitivePaper.Application.User
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}