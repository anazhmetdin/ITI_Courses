using CarsData;
using MVVMDay23.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.Model
{
    public class ObservableCar: ViewModelBase
    {
        public Car Car = new();

        public int Num

        {
            get { return Car.Num; }
            set { Car.Num = value; OnPropertyChanged(); }
        }

        public string Color

        {
            get { return Car.Color; }
            set { Car.Color = value; OnPropertyChanged(); }
        }

        public string Manufacture

        {
            get { return Car.Manufacture; }
            set { Car.Manufacture = value; OnPropertyChanged(); }
        }

        public string Model

        {
            get { return Car.Model; }
            set { Car.Model = value; OnPropertyChanged(); }
        }
    }
}
