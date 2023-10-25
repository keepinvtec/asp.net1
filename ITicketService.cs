namespace ServiceStationWeb
{
    public interface ITicketService
    {
        void CreateTicket(Ticket ticket);
        IEnumerable<Ticket> GetTicketList();
    }
}
