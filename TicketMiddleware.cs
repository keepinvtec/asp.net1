using System.Text;

namespace ServiceStationWeb
{
    public class TicketMiddleware
    {
        RequestDelegate next;

        public TicketMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ITicketService ticketService)
        {
            if (httpContext.Request.Path == "/get")
            {
                httpContext.Response.ContentType = "text/html; charset=utf-8";
                var stringBuilder = new StringBuilder("<h1>Tickets</h1><table>");
                stringBuilder.Append("<td><h3>#</h3></td> <td><h3>InvoiceID</h3></td> <td><h3>VINCode</h3></td> <td><h3><Mileage</h3></td>");
                int i = 1;
                foreach (var ticket in ticketService.GetTicketList())
                {
                    stringBuilder.Append($"<tr><td>{i}</td> <td>{ticket.invoice.InvoiceId}</td> <td>{ticket.car.VINcode}</td> <td>{ticket.car.Mileage}</td></tr>");
                    i++;
                }
                stringBuilder.Append("</table>");
                await httpContext.Response.WriteAsync(stringBuilder.ToString());
            }
            else if (httpContext.Request.Path == "/ticket" && httpContext.Request.Method == "GET")
            {
                httpContext.Response.ContentType = "text/html; charset=utf-8";
                await httpContext.Response.SendFileAsync("createticket.html");
            }
            else if (httpContext.Request.Path == "/ticket" && httpContext.Request.Method == "POST")
            {
                Ticket ticket = new Ticket();
                ticket.invoice.CarVINcode = httpContext.Request.Form["vincode"].ToString();
                ticket.car.VINcode = httpContext.Request.Form["vincode"].ToString();
                ticket.car.Brand = httpContext.Request.Form["brand"].ToString();
                ticket.car.Model = httpContext.Request.Form["model"].ToString();
                ticket.car.YearOfProd = int.Parse(httpContext.Request.Form["mnfc"].ToString());
                ticket.car.Mileage = int.Parse(httpContext.Request.Form["mileage"].ToString());

                ticketService.CreateTicket(ticket);

                httpContext.Response.Redirect("/get");
            }
            else
            {
                await next.Invoke(httpContext);
            }
        }
    }
}
