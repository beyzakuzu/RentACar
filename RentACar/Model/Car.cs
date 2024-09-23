using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RentACar.Model.Dto;
namespace RentACar.Model;

public class Car
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public string CarState { get; set; }
    public int KiloMeter { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public double DailyPrice { get; set; }

    public Car(int id, int colorId, int fuelId, int transmissionId, string carState,
               int kiloMeter, short modelYear, string plate, string brandName, string modelName, double dailyPrice)
    {
        Id = id;
        ColorId = colorId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        CarState = carState;
        KiloMeter = kiloMeter;
        ModelYear = modelYear;
        Plate = plate;
        BrandName = brandName;
        ModelName = modelName;
        DailyPrice = dailyPrice;
    }
}
