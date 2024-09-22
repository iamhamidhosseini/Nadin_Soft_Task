using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace task.Controllers
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel model);
    }

}
