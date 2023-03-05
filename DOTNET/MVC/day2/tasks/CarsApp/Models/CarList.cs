using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsApp.Models
{
    public class CarList: List<Car>
    {
        public static CarList instance = new CarList()
        {
            new Car {Num = 1, Color = "Red", Manufacture = "man1", Model = "model1"},
            new Car {Num = 2, Color = "Black", Manufacture = "man2", Model = "model2"},
            new Car {Num = 3, Color = "Orange", Manufacture = "man3", Model = "model3"},
            new Car {Num = 4, Color = "White", Manufacture = "man4", Model = "model4"},
            new Car {Num = 5, Color = "Red", Manufacture = "man5", Model = "model5"},
        };
    }
}