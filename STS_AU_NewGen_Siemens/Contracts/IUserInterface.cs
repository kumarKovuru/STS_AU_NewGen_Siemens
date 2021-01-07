using System.Threading.Tasks;

namespace STS_AU_NewGen_Siemens
{
    public interface IUserInterface
    {
        Task<object> LoginAsync(User user);
        Task<decimal> GetEstimationAsync(Gold gold);
    }
}
