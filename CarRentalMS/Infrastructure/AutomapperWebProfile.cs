using CarRentalMS.DataAccess;
using CarRentalMS.ViewModels;

namespace CarRentalMS.Infrastructure
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Car, CarViewModel>();
            CreateMap<CarViewModel, Car>();

            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Company>();

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