using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model;

public class Fuel
{
    public int Id { get; set; }
    public string Name { get; set; }


    public Fuel(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

