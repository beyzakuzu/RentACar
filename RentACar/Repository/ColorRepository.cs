using System;
using RentACar.Model;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RentACar.Repository;

public class ColorRepository
{
    public List<Color> colors = new List<Color>
{
    new Color(1, "Kırmızı"),
    new Color(2, "Mavi")
};

    public List<Color> GetAll() => colors;

    public Color? GetById(int id) => colors.FirstOrDefault(color => color.Id == id);

    public void Add(Color color) => colors.Add(color);

    public void Update(Color color)
    {
        var existingColor = GetById(color.Id);
        if (existingColor != null)
        {
            existingColor.Name = color.Name;
        }
    }

    public void Delete(int id)
    {
        var color = GetById(id);
        if (color != null) colors.Remove(color);
    }
}

