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
INSERT INTO airports (IATA, Name, City, Country)
VALUES
    ('MAD', 'Adolfo Suárez Madrid–Barajas Airport', 'Madrid', 'Spain'),
    ('BCN', 'Barcelona–El Prat Airport', 'Barcelona', 'Spain'),
    ('ALC', 'Alicante–Elche Airport', 'Alicante', 'Spain'),
    ('PMI', 'Palma de Mallorca Airport', 'Palma de Mallorca', 'Spain'),
    ('AGP', 'Málaga Airport', 'Málaga', 'Spain'),
    ('TFN', 'Tenerife North Airport', 'Tenerife', 'Spain'),
    ('LPA', 'Gran Canaria Airport', 'Gran Canaria', 'Spain'),
    ('SVQ', 'Seville Airport', 'Seville', 'Spain'),
    ('VLC', 'Valencia Airport', 'Valencia', 'Spain'),
    ('IBZ', 'Ibiza Airport', 'Ibiza', 'Spain'),
    -- Alemania (5 aeropuertos)
    ('FRA', 'Frankfurt Airport', 'Frankfurt', 'Germany'),
    ('MUC', 'Munich Airport', 'Munich', 'Germany'),
    ('TXL', 'Berlin Tegel Airport', 'Berlin', 'Germany'),
    ('HAM', 'Hamburg Airport', 'Hamburg', 'Germany'),
    ('DUS', 'Düsseldorf Airport', 'Düsseldorf', 'Germany'),
    -- Arabia Saudita (3 aeropuertos)
    ('JED', 'King Abdulaziz International Airport', 'Jeddah', 'Saudi Arabia'),
    ('RUH', 'King Khalid International Airport', 'Riyadh', 'Saudi Arabia'),
    ('DMM', 'King Fahd International Airport', 'Dammam', 'Saudi Arabia'),
    -- Argelia (1 aeropuerto)
    ('ALG', 'Algiers Houari Boumediene Airport', 'Algiers', 'Algeria'),
    -- Argentina (2 aeropuertos)
    ('EZE', 'Ministro Pistarini International Airport', 'Buenos Aires', 'Argentina'),
    ('AEP', 'Jorge Newbery Airfield', 'Buenos Aires', 'Argentina'),
    -- Australia (3 aeropuertos)
    ('SYD', 'Sydney Kingsford Smith Airport', 'Sydney', 'Australia'),
    ('MEL', 'Melbourne Airport', 'Melbourne', 'Australia'),
    ('BNE', 'Brisbane Airport', 'Brisbane', 'Australia'),
    -- Bélgica (2 aeropuertos)
    ('BRU', 'Brussels Airport', 'Brussels', 'Belgium'),
    ('CRL', 'Brussels South Charleroi Airport', 'Charleroi', 'Belgium'),
    -- Brasil (3 aeropuertos)
    ('GRU', 'São Paulo/Guarulhos–Governador André Franco Montoro International Airport', 'São Paulo', 'Brazil'),
    ('GIG', 'Rio de Janeiro/Galeão–Antonio Carlos Jobim International Airport', 'Rio de Janeiro', 'Brazil'),
    ('BSB', 'Brasília International Airport', 'Brasília', 'Brazil'),
    -- Canadá (4 aeropuertos)
    ('YYZ', 'Toronto Pearson International Airport', 'Toronto', 'Canada'),
    ('YVR', 'Vancouver International Airport', 'Vancouver', 'Canada'),
    ('YUL', 'Montréal-Pierre Elliott Trudeau International Airport', 'Montreal', 'Canada'),
    ('YYC', 'Calgary International Airport', 'Calgary', 'Canada'),
    -- Chile (2 aeropuertos)
    ('SCL', 'Comodoro Arturo Merino Benítez International Airport', 'Santiago', 'Chile'),
    ('IPC', 'Mataveri International Airport', 'Easter Island', 'Chile'),
    -- China (5 aeropuertos)
    ('PEK', 'Beijing Capital International Airport', 'Beijing', 'China'),
    ('PVG', 'Shanghai Pudong International Airport', 'Shanghai', 'China'),
    ('CAN', 'Guangzhou Baiyun International Airport', 'Guangzhou', 'China'),
    ('SHA', 'Shanghai Hongqiao International Airport', 'Shanghai', 'China'),
    ('SZX', 'Shenzhen Baoan International Airport', 'Shenzhen', 'China'),
    -- Colombia (3 aeropuertos)
    ('BOG', 'El Dorado International Airport', 'Bogotá', 'Colombia'),
    ('MDE', 'José María Córdova International Airport', 'Medellín', 'Colombia'),
    ('CTG', 'Rafael Núñez International Airport', 'Cartagena', 'Colombia'),
    -- Corea del Sur (2 aeropuertos)
    ('ICN', 'Incheon International Airport', 'Incheon', 'South Korea'),
    ('GMP', 'Gimpo International Airport', 'Seoul', 'South Korea'),
    -- Croacia (1 aeropuerto)
    ('ZAG', 'Zagreb Airport', 'Zagreb', 'Croatia'),
    -- Dinamarca (2 aeropuertos)
    ('CPH', 'Copenhagen Airport', 'Copenhagen', 'Denmark'),
    ('BLL', 'Billund Airport', 'Billund', 'Denmark'),
    -- Ecuador (1 aeropuerto)
    ('UIO', 'Mariscal Sucre International Airport', 'Quito', 'Ecuador'),
    -- Egipto (2 aeropuertos)
    ('CAI', 'Cairo International Airport', 'Cairo', 'Egypt'),
    ('HRG', 'Hurghada International Airport', 'Hurghada', 'Egypt'),
    -- Emiratos Árabes Unidos (3 aeropuertos)
    ('DXB', 'Dubai International Airport', 'Dubai', 'United Arab Emirates'),
    ('AUH', 'Abu Dhabi International Airport', 'Abu Dhabi', 'United Arab Emirates'),
    ('SHJ', 'Sharjah International Airport', 'Sharjah', 'United Arab Emirates'),
    -- Estados Unidos (6 aeropuertos)
    ('JFK', 'John F. Kennedy International Airport', 'New York City', 'United States of America'),
    ('LAX', 'Los Angeles International Airport', 'Los Angeles', 'United States of America'),
    ('ORD', 'OHare International Airport', 'Chicago', 'United States of America'),
    ('DFW', 'Dallas/Fort Worth International Airport', 'Dallas/Fort Worth', 'United States of America'),
    ('ATL', 'Hartsfield-Jackson Atlanta International Airport', 'Atlanta', 'United States of America'),
    ('DEN', 'Denver International Airport', 'Denver', 'United States of America'),
    -- Francia (5 aeropuertos)
    ('CDG', 'Charles de Gaulle Airport', 'Paris', 'France'),
    ('ORY', 'Orly Airport', 'Paris', 'France'),
    ('NCE', 'Nice Côte dAzur Airport', 'Nice', 'France'),
    ('MRS', 'Marseille Provence Airport', 'Marseille', 'France'),
    ('TLS', 'Toulouse–Blagnac Airport', 'Toulouse', 'France'),
    -- India (3 aeropuertos)
    ('DEL', 'Indira Gandhi International Airport', 'Delhi', 'India'),
    ('BOM', 'Chhatrapati Shivaji Maharaj International Airport', 'Mumbai', 'India'),
    ('BLR', 'Kempegowda International Airport', 'Bangalore', 'India'),
    -- Irlanda (2 aeropuertos)
    ('DUB', 'Dublin Airport', 'Dublin', 'Ireland'),
    ('SNN', 'Shannon Airport', 'Shannon', 'Ireland'),
    -- Italia (4 aeropuertos)
    ('FCO', 'Leonardo da Vinci–Fiumicino Airport', 'Rome', 'Italy'),
    ('MXP', 'Milan Malpensa Airport', 'Milan', 'Italy'),
    ('LIN', 'Milan Linate Airport', 'Milan', 'Italy'),
    ('VCE', 'Venice Marco Polo Airport', 'Venice', 'Italy'),
    -- México (2 aeropuertos)
    ('MEX', 'Mexico City International Airport', 'Mexico City', 'Mexico'),
    ('CUN', 'Cancún International Airport', 'Cancún', 'Mexico'),
    -- Morocco (4 aeropuertos)
    ('CMN', 'Mohammed V International Airport', 'Casablanca', 'Morocco'),
    ('RAK', 'Marrakesh Menara Airport', 'Marrakesh', 'Morocco'),
    ('AGA', 'Agadir–Al Massira Airport', 'Agadir', 'Morocco'),
    ('FEZ', 'Fès–Saïs Airport', 'Fes', 'Morocco'),
    -- Netherlands (2 aeropuertos)
    ('AMS', 'Amsterdam Airport Schiphol', 'Amsterdam', 'Netherlands'),
    ('RTM', 'Rotterdam The Hague Airport', 'Rotterdam', 'Netherlands'),
    -- Portugal (3 aeropuertos)
    ('LIS', 'Lisbon Airport', 'Lisbon', 'Portugal'),
    ('OPO', 'Francisco de Sá Carneiro Airport', 'Porto', 'Portugal'),
    ('FAO', 'Faro Airport', 'Faro', 'Portugal'),
    -- Qatar (2 aeropuertos)
    ('DOH', 'Hamad International Airport', 'Doha', 'Qatar'),
    ('DOH', 'Doha Airport', 'Doha', 'Qatar'), -- Duplicado intencional para Qatar
    -- Reino Unido (6 aeropuertos)
    ('LHR', 'London Heathrow Airport', 'London', 'United Kingdom'),
    ('LGW', 'London Gatwick Airport', 'London', 'United Kingdom'),
    ('STN', 'London Stansted Airport', 'London', 'United Kingdom'),
    ('MAN', 'Manchester Airport', 'Manchester', 'United Kingdom'),
    ('EDI', 'Edinburgh Airport', 'Edinburgh', 'United Kingdom'),
    ('BHX', 'Birmingham Airport', 'Birmingham', 'United Kingdom'),
    -- Rusia (3 aeropuertos)
    ('SVO', 'Sheremetyevo International Airport', 'Moscow', 'Russia'),
    ('DME', 'Domodedovo International Airport', 'Moscow', 'Russia'),
    ('LED', 'Pulkovo Airport', 'Saint Petersburg', 'Russia'),
    -- Turquía (4 aeropuertos)
    ('IST', 'Istanbul Airport', 'Istanbul', 'Turkey'),
    ('SAW', 'Sabiha Gökçen International Airport', 'Istanbul', 'Turkey'),
    ('AYT', 'Antalya Airport', 'Antalya', 'Turkey'),
    ('ESB', 'Esenboğa International Airport', 'Ankara', 'Turkey'),
    -- Suiza (1 aeropuerto)
    ('ZRH', 'Zürich Airport', 'Zürich', 'Switzerland'),
    -- Suecia (1 aeropuerto)
    ('ARN', 'Stockholm Arlanda Airport', 'Stockholm', 'Sweden');y
    
*/