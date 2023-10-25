using ServiceStationWeb.Entity;

namespace ServiceStationWeb
{
    public class Ticket
    {
        public Invoice invoice { get; set; } = new Invoice();
        public Car car { get; set; } = new Car();
    }
}
