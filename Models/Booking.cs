using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace airpangea_back.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string? Fare { get; set; } //[Basic, Regular, Plus]
        public string? Seat { get; set; }

        public int PassengerId { get; set; }
        [ForeignKey("PassengerId")]

        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight? Flight { get; set; }
        
        [JsonIgnore]
        public Passenger? Passenger { get; set; }
    }
}