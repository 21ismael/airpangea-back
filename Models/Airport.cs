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
-- Airports españoles
('MAD', 'Adolfo Suárez Madrid–Barajas Airport', 'Madrid', 'Spain'),
('BCN', 'Barcelona–El Prat Airport', 'Barcelona', 'Spain'),
('PMI', 'Palma de Mallorca Airport', 'Palma de Mallorca', 'Spain'),
('AGP', 'Málaga Airport', 'Málaga', 'Spain'),
('TFS', 'Tenerife South Airport', 'Tenerife', 'Spain'),
-- Airports franceses
('CDG', 'Charles de Gaulle Airport', 'Paris', 'France'),
('ORY', 'Orly Airport', 'Paris', 'France'),
('MRS', 'Marseille Provence Airport', 'Marseille', 'France'),
('LYS', 'Lyon–Saint-Exupéry Airport', 'Lyon', 'France'),
-- Airports alemanes
('FRA', 'Frankfurt Airport', 'Frankfurt', 'Germany'),
('MUC', 'Munich Airport', 'Munich', 'Germany'),
('TXL', 'Berlin Tegel Airport', 'Berlin', 'Germany'),
('DUS', 'Düsseldorf Airport', 'Düsseldorf', 'Germany'),
('HAM', 'Hamburg Airport', 'Hamburg', 'Germany'),
-- Airports de Marruecos
('CMN', 'Mohammed V International Airport', 'Casablanca', 'Morocco'),
('RAK', 'Marrakesh Menara Airport', 'Marrakesh', 'Morocco'),
-- Airports de Portugal
('LIS', 'Lisbon Portela Airport', 'Lisbon', 'Portugal'),
('OPO', 'Porto Airport', 'Porto', 'Portugal');

INSERT INTO Airports (IATA, Name, City, Country)
VALUES 
-- Airports en el Reino Unido
('LHR', 'London Heathrow Airport', 'London', 'United Kingdom'),
('LGW', 'London Gatwick Airport', 'London', 'United Kingdom'),
('MAN', 'Manchester Airport', 'Manchester', 'United Kingdom'),
('EDI', 'Edinburgh Airport', 'Edinburgh', 'United Kingdom'),
('BHX', 'Birmingham Airport', 'Birmingham', 'United Kingdom'),
-- Airports en Noruega
('OSL', 'Oslo Gardermoen Airport', 'Oslo', 'Norway'),
('SVG', 'Stavanger Airport', 'Stavanger', 'Norway'),
-- Airports en Estados Unidos
('JFK', 'John F. Kennedy International Airport', 'New York City', 'United States'),
('LAX', 'Los Angeles International Airport', 'Los Angeles', 'United States'),
('ORD', 'O\'Hare International Airport', 'Chicago', 'United States'),
('DFW', 'Dallas/Fort Worth International Airport', 'Dallas/Fort Worth', 'United States'),
('DEN', 'Denver International Airport', 'Denver', 'United States'),
('SEA', 'Seattle–Tacoma International Airport', 'Seattle', 'United States'),
-- Airports en Canadá
('YYZ', 'Toronto Pearson International Airport', 'Toronto', 'Canada'),
('YUL', 'Montréal-Pierre Elliott Trudeau International Airport', 'Montréal', 'Canada');

*/