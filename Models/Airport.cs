using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airpangea_back.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string? IATA { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}

/*
INSERT INTO Airports (IATA, Name, City, Country)
VALUES
    ('MAD', 'Adolfo Suárez Madrid-Barajas Airport', 'Madrid', 'Spain'),
    ('BCN', 'Barcelona-El Prat Airport', 'Barcelona', 'Spain');
*/