using RentACar.Model.Dto;
using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace RentACar.Repository;

public class CarRepository
{
    private List<Car> cars = new List<Car>
    {
        new Car(1, 1, 1, 1, "Yeni", 10000, 2021, "34ABC123", "Toyota", "Corolla", 300),
        new Car(2, 2, 2, 2, "Kullanılmış", 50000, 2019, "34DEF456", "Ford", "Focus", 250),
        new Car(3, 1, 1, 2, "Yeni", 15000, 2022, "34GHI789", "Volkswagen", "Golf", 350)
    };
    private FuelRepository fuelRepository = new FuelRepository();
    private TransmissionRepository transmissionRepository = new TransmissionRepository();

    
    public List<Car> GetAll() => cars;

    public Car? GetById(int id) => cars.FirstOrDefault(car => car.Id == id);

    public void Add(Car car)
    {
        
        if (cars.Any(existingCar => existingCar.Id == car.Id || existingCar.Plate == car.Plate))
        {
            throw new InvalidOperationException("Aynı ID veya plaka numarasına sahip bir araç zaten mevcut.");
        }

        cars.Add(car);
    }

    public void Update(Car car)
    {
        var existingCar = GetById(car.Id);
        if (existingCar != null)
        {
            existingCar.ColorId = car.ColorId;
            existingCar.FuelId = car.FuelId;
            existingCar.TransmissionId = car.TransmissionId;
            existingCar.CarState = car.CarState;
            existingCar.KiloMeter = car.KiloMeter;
            existingCar.ModelYear = car.ModelYear;
            existingCar.Plate = car.Plate;
            existingCar.BrandName = car.BrandName;
            existingCar.ModelName = car.ModelName;
            existingCar.DailyPrice = car.DailyPrice;
        }
    }



    private List<Color> colors = new List<Color>
{
    new Color(1, "Kırmızı"),
    new Color(2, "Mavi")
};

    public void Delete(int id)
    {
        var car = GetById(id);
        if (car != null) cars.Remove(car);
    }

    public List<CarDetailDto> GetAllDetails()
    {
        var result =
            from car in cars
            join fuel in fuelRepository.GetAll()
            on car.FuelId equals fuel.Id
            join color in colors
            on car.ColorId equals color.Id
            join transmission in transmissionRepository.GetAll() 
            on car.TransmissionId equals transmission.Id
            select new CarDetailDto
            {
                Id = car.Id,
                FuelName = fuel.Name,
                TransmissionName = transmission.Name,
                ColorName = color.Name,
                CarState = car.CarState,
                KiloMeter = car.KiloMeter,
                ModelYear = car.ModelYear,
                Plate = car.Plate,
                BrandName = car.BrandName,
                ModelName = car.ModelName,
                DailyPrice = car.DailyPrice
            };

        return result.ToList();
    }

    public List<CarDetailDto> GetAllDetailsByFuelId(int fuelId)
    {
        return GetAllDetails().Where(car => car.FuelName == GetFuelNameById(fuelId)).ToList();
    }

    public List<CarDetailDto> GetAllDetailsByColorId(int colorId)
    {
        return GetAllDetails().Where(car => car.ColorName == GetColorNameById(colorId)).ToList();
    }

    public List<CarDetailDto> GetAllDetailsByPriceRange(double min, double max)
    {
        return GetAllDetails().Where(car => car.DailyPrice >= min && car.DailyPrice <= max).ToList();
    }

    public List<CarDetailDto> GetAllDetailsByBrandNameContains(string brandName)
    {
        return GetAllDetails().Where(car => car.BrandName?.Contains(brandName) == true).ToList();
    }

    public List<CarDetailDto> GetAllDetailsByModelNameContains(string modelName)
    {
        return GetAllDetails().Where(car => car.ModelName?.Contains(modelName) == true).ToList();
    }

    public CarDetailDto? GetDetailById(int id)
    {
        return GetAllDetails().FirstOrDefault(car => car.Id == id);
    }

    public List<CarDetailDto> GetAllDetailsByKilometerRange(int min, int max)
    {
        return GetAllDetails().Where(car => car.KiloMeter >= min && car.KiloMeter <= max).ToList();
    }

    private string GetFuelNameById(int fuelId)
    {
        return fuelRepository.GetById(fuelId)?.Name ?? "Bilinmiyor";
    }
    private string GetColorNameById(int colorId)
    {
        return colors.FirstOrDefault(c => c.Id == colorId)?.Name ?? "Bilinmiyor";
    }
}
