using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airpangea_back.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public List<Passenger> Passengers { get; set; } = [];
    }
}

/*
INSERT INTO Users (Email, Password, Name, LastName)
VALUES
    ('juanperez@example.com', 'clave123', 'Juan', 'Perez'),
    ('lauragonzalez@example.com', 'password456', 'Laura', 'González'),
    ('carlosrodriguez@example.com', 'abc123', 'Carlos', 'Rodríguez'),
    ('anamartinez@example.com', 'contraseña789', 'Ana', 'Martínez'),
    ('davidlopez@example.com', 'qwerty', 'David', 'López');
*/