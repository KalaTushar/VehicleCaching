using EasyCaching.Core;
using Microsoft.AspNetCore.Mvc;
using VehicleCaching.Model;
namespace VehicleCaching.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IEasyCachingProvider _cachingProvider; 
        public VehicleController(IEasyCachingProviderFactory cachingProvider)
        {
            _cachingProvider = cachingProvider.GetCachingProvider("DefaultRedis");
        }
        [HttpGet]
        public ActionResult<Vehicle> Get()
        {
            var inCache = _cachingProvider.Exists("Vehicle_IN_CACHE");

            if (inCache)
            {
                return Ok(_cachingProvider.Get<Vehicle>("Vehicle_IN_CACHE").Value);
            }
            else
            {
                Thread.Sleep(4000);
                var v = new Vehicle
                {
                    VehicleId = 1,
                    VehicleName= "Mustang",
                    VehicleType = Types.petrol,
                    DateRegistered= DateTime.Now,
                };
                _cachingProvider.TrySet("Vehicle_IN_CACHE", v, TimeSpan.FromMinutes(1));
                return Ok(v);
            }
        }
    }
}
