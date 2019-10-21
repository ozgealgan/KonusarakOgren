using KonusarakOgren.Models.Responses;
using System.Threading.Tasks;

namespace KonusarakOgren.Business.Proxies.Interfaces
{
    public interface IWiredApiProxy
    {
        Task<WiredApiResponse> GetWiredArticles();
    }
}
