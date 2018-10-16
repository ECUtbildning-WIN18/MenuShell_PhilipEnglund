using MenuShell.Domain;

namespace MenuShell.Interfaces
{
    public interface IAuthenticationService
    {
        User CollectUserData();
    }
}