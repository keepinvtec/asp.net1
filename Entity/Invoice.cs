using System.ComponentModel.DataAnnotations.Schema;


namespace ServiceStationWeb.Entity
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public string CarVINcode { get; set; } = null!;

        public virtual Car Car { get; set; } = null!;
    }
}
