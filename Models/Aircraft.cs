using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airpangea_back.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string? Model { get; set; }
    }
}

/*
INSERT INTO Aircrafts (Model)
VALUES
    ('Boeing 737'),
    ('Airbus A320'),
    ('Embraer E190'),
    ('Boeing 777'),
    ('Airbus A350');
*/