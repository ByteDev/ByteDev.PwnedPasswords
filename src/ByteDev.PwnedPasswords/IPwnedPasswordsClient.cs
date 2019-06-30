using System.Threading;
using System.Threading.Tasks;

namespace ByteDev.PwnedPasswords
{
    public interface IPwnedPasswordsClient
    {
        Task<PwnedPasswordResponse> GetHasBeenPwnedAsync(string password);
        
        Task<PwnedPasswordResponse> GetHasBeenPwnedAsync(string password, CancellationToken cancellationToken);
    }
}