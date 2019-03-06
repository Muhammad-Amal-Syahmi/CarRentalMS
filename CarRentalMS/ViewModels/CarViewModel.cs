using System;

namespace CarRentalMS.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public string Location { get; set; }
        public Nullable<double> PricePerDay { get; set; }
    }
}