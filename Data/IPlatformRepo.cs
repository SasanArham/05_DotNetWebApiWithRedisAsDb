using RediAPI.Models;

namespace RediAPI.Data
{
    public interface IPlatformRepo
    {
        Task<Platform?> createPlatform(Platform platform) ;
        Task<Platform?>  GetById(string Id) ;
        Task<IEnumerable<Platform?>?> GetAll() ;

    }
}