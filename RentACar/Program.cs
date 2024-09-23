using RentACar.Model;
using RentACar.Model.Dto;
using RentACar.Service;

CarService carService = new CarService();

while (true)
{
    Console.WriteLine("1. Tüm Araçları Listele");
    Console.WriteLine("2. Araç Rengine Göre Filtrele");
    Console.WriteLine("3. Araç Fiyat Aralığına Göre Filtrele");
    Console.WriteLine("4. Araç Markasına Göre Ara");
    Console.WriteLine("5. Araç Modeline Göre Ara");
    Console.WriteLine("6. Araç Detayını Getir");
    Console.WriteLine("7. Araç Ekle");
    Console.WriteLine("8. Çıkış");
    Console.Write("Seçiminizi yapınız: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            List<CarDetailDto> cars = carService.GetAllDetails();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}: {car.BrandName} {car.ModelName} - {car.DailyPrice} TL");
            }
            break;
        case 2:
            Console.Write("Renk Id giriniz: ");
            int colorId = Convert.ToInt32(Console.ReadLine());
            var carsByColor = carService.GetAllDetailsByColorId(colorId);
            foreach (var car in carsByColor)
            {
                Console.WriteLine($"{car.Id}: {car.BrandName} {car.ModelName} - {car.DailyPrice} TL");
            }
            break;
        case 3:
            Console.Write("Min fiyat giriniz: ");
            double minPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Max fiyat giriniz: ");
            double maxPrice = Convert.ToDouble(Console.ReadLine());
            var carsByPriceRange = carService.GetAllDetailsByPriceRange(minPrice, maxPrice);
            foreach (var car in carsByPriceRange)
            {
                Console.WriteLine($"{car.Id}: {car.BrandName} {car.ModelName} - {car.DailyPrice} TL");
            }
            break;
        case 4:
            Console.Write("Marka adını giriniz: ");
            string brandName = Console.ReadLine();
            var carsByBrand = carService.GetAllDetailsByBrandNameContains(brandName);
            foreach (var car in carsByBrand)
            {
                Console.WriteLine($"{car.Id}: {car.BrandName} {car.ModelName} - {car.DailyPrice} TL");
            }
            break;
        case 5:
            Console.Write("Model adını giriniz: ");
            string modelName = Console.ReadLine();
            var carsByModel = carService.GetAllDetailsByModelNameContains(modelName);
            foreach (var car in carsByModel)
            {
                Console.WriteLine($"{car.Id}: {car.BrandName} {car.ModelName} - {car.DailyPrice} TL");
            }
            break;
        case 6:
            Console.Write("Araç Id'sini giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var carDetail = carService.GetDetailById(id);
            if (carDetail != null)
            {
                Console.WriteLine($"{carDetail.Id}: {carDetail.BrandName} {carDetail.ModelName} - {carDetail.DailyPrice} TL");
            }
            else
            {
                Console.WriteLine("Araç bulunamadı.");
            }
            break;
        case 7:
            Car newCar = GetCarInputs();
            carService.Add(newCar);
            Console.WriteLine("Araç eklendi.");
            break;
        case 8:
            return;
        default:
            Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
            break;
    }
}


static Car GetCarInputs()
{
    Console.WriteLine("Araç bilgilerini giriniz:");

    Console.Write("Araç ID: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.Write("Marka: ");
    string brandName = Console.ReadLine();

    Console.Write("Model: ");
    string modelName = Console.ReadLine();

    Console.Write("Günlük Fiyat: ");
    double dailyPrice = Convert.ToDouble(Console.ReadLine());

    Console.Write("Renk ID: ");
    int colorId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Yakıt ID: ");
    int fuelId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Şanzıman ID: ");
    int transmissionId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Araç Durumu: ");
    string carState = Console.ReadLine();

    Console.Write("Kilometre: ");
    int kilometer = Convert.ToInt32(Console.ReadLine());

    Console.Write("Model Yılı: ");
    short modelYear = Convert.ToInt16(Console.ReadLine());

    Console.Write("Plaka: ");
    string plate = Console.ReadLine();

    return new Car(id, colorId, fuelId, transmissionId, carState, kilometer, modelYear, plate, brandName, modelName, dailyPrice);
}