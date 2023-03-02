using VehicleCaching.Model;

namespace VehicleCaching.View_Model
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public Types VehicleType { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
