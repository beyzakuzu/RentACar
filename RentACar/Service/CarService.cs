using RentACar.Model;
using RentACar.Model.Dto;
using RentACar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service;

public class CarService
{
    private CarRepository carRepository = new CarRepository();


    public void Add(Car car) => carRepository.Add(car);

    public List<CarDetailDto> GetAllDetails() => carRepository.GetAllDetails();

    public List<CarDetailDto> GetAllDetailsByFuelId(int fuelId) => carRepository.GetAllDetailsByFuelId(fuelId);

    public List<CarDetailDto> GetAllDetailsByColorId(int colorId) => carRepository.GetAllDetailsByColorId(colorId);

    public List<CarDetailDto> GetAllDetailsByPriceRange(double min, double max) => carRepository.GetAllDetailsByPriceRange(min, max);

    public List<CarDetailDto> GetAllDetailsByBrandNameContains(string brandName) => carRepository.GetAllDetailsByBrandNameContains(brandName);

    public List<CarDetailDto> GetAllDetailsByModelNameContains(string modelName) => carRepository.GetAllDetailsByModelNameContains(modelName);

    public CarDetailDto? GetDetailById(int id) => carRepository.GetDetailById(id);

    public List<CarDetailDto> GetAllDetailsByKilometerRange(int min, int max) => carRepository.GetAllDetailsByKilometerRange(min, max);
}
