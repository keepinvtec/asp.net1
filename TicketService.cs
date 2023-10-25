using ServiceStationWeb.Entity;

namespace ServiceStationWeb
{
    public class TicketService : ITicketService
    {
        readonly CarServiceContext dbContext;

        public TicketService(CarServiceContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateTicket(Ticket ticket)
        {
            dbContext.Add(ticket.car);
            dbContext.Add(ticket.invoice);
            dbContext.SaveChanges();
        }

        public IEnumerable<Ticket> GetTicketList()
        {
            IEnumerable<Ticket> _Tickets = from _Invoice in dbContext.Set<Invoice>()
                                           from _Car in dbContext.Set<Car>().Where(car => car.VINcode == _Invoice.CarVINcode)
                                           select new Ticket
                                           {
                                               invoice = _Invoice,
                                               car = _Car,
                                           };
            return _Tickets;
        }
    }
}
