using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RentACar.Repository;

public class FuelRepository
{

    public List<Fuel> fuels = new List<Fuel>
{
    new Fuel(1, "Benzin"),
    new Fuel(2, "Dizel")
};
    public List<Fuel> GetAll() => fuels;

    public Fuel? GetById(int id) => fuels.FirstOrDefault(fuel => fuel.Id == id);

    public void Add(Fuel fuel) => fuels.Add(fuel);

    public void Update(Fuel fuel)
    {
        var existingFuel = GetById(fuel.Id);
        if (existingFuel != null)
        {
            existingFuel.Name = fuel.Name;
        }
    }



    public void Delete(int id)
    {
        var fuel = GetById(id);
        if (fuel != null) fuels.Remove(fuel);
    }
}
