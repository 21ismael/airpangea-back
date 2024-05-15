using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace airpangea_back.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string? Seats { get; set; }
        public float? Price { get; set; }
        public string Status { get; set; } = string.Empty; 

        /*Estado del vuelo -  [Programado, En ruta, Retrasado, Cancelado, Finalizado]*/
        /*Flight Status -  [Scheduled, En route, Delayed, Cancelled, Completed]*/

        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

        public int AirportDepartureId { get; set; }
        [ForeignKey("AirportDepartureId")]
        public Airport? AirportDeparture { get; set; }

        public int AirportArrivalId { get; set; }
        [ForeignKey("AirportArrivalId")]
        public Airport? AirportArrival { get; set; }

        [JsonIgnore]
        public List<Booking> Bookings { get; set; } = new List<Booking>();

    }
}