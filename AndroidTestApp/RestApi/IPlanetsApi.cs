using AndroidTestApp.Models;
using Refit;
using System.Threading.Tasks;

namespace AndroidTestApp.RestApi
{
    public interface IPlanetsApi
    {
        [Get("/planets")]
        Task<PlanetsResponse> GetPlanets();
    }
}