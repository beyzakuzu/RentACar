using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RentACar.Repository;

public class TransmissionRepository
{
    private List<Transmission> transmissions = new List<Transmission>();

    public List<Transmission> GetAll() => transmissions;

    public Transmission? GetById(int id) => transmissions.FirstOrDefault(trans => trans.Id == id);

    public void Add(Transmission transmission) => transmissions.Add(transmission);

    public void Update(Transmission transmission)
    {
        var existingTrans = GetById(transmission.Id);
        if (existingTrans != null)
        {
            existingTrans.Name = transmission.Name;
        }
    }

    public void Delete(int id)
    {
        var transmission = GetById(id);
        if (transmission != null) transmissions.Remove(transmission);
    }
}

