using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace airpangea_back.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Seat { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]

        [JsonIgnore]
        public User? User { get; set; }
        
        
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

/*
INSERT INTO Passengers (Name, LastName, IdentityNumber, Seat, UserId)
VALUES
    ('María', 'García', '123456789A', 'A1', 1),
    ('Pedro', 'Martínez', '987654321B', 'B3', 2),
    ('Ana', 'López', '456123789C', 'C2', 3),
    ('David', 'Sánchez', '789123456D', 'D4', 4),
    ('Laura', 'Fernández', '321654987E', 'E5', 5);

*/