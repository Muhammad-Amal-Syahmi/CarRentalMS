using CarRentalMS.DataAcess;
using CarRentalMS.ViewModels;

namespace CarRentalMS.Infrastructure
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Car, CarViewModel>();
            CreateMap<CarViewModel, Car>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomapperWebProfile>();
            });
        }
    }
}