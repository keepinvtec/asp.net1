using System.ComponentModel.DataAnnotations;


namespace ServiceStationWeb.Entity
{
    public class Car
    {
        public string VINcode { get; set; } = null!;

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int YearOfProd { get; set; }

        public int Mileage { get; set; }

        public virtual List<Invoice> Invoices { get; } = new List<Invoice>();
    }
}
