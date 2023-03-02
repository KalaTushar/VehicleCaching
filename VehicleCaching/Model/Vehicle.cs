namespace VehicleCaching.Model
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public Types VehicleType { get; set; }
        public DateTime DateRegistered { get; set; }
    }
    public enum Types
    {
        electric,
        petrol,
        diesel,
    }
}
