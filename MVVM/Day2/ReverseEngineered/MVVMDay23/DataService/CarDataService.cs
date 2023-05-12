using Microsoft.EntityFrameworkCore;
using MVVMDay23.DataAccess;
using MVVMDay23.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.DataService
{
    public class CarDataService : IDataService<Car>
    {
        public void Add(Car car)
        {
            using (CarDataBaseContext Context = new())
            {
                if(car !=null)
                Context.Cars.Add(car);
                Context.SaveChanges();
               
            }
        }

        public void Delete(int id)
        {
            using (CarDataBaseContext schoolDbContext = new ())
            {
                var Car = schoolDbContext.Cars.FirstOrDefault(s => s.Num == id);
                if(Car != null)
                    schoolDbContext.Cars.Remove(Car);
                schoolDbContext.SaveChanges();
            }
        }

        public Car Get(int id)
        {
            using (CarDataBaseContext Context = new())
            {
                return Context.Cars.FirstOrDefault(c => c.Num == id) ?? new Car();
            }
        }

        public IEnumerable<Car> GetAll()
        {
           using(CarDataBaseContext Context =new())
            {
                Context.Database.EnsureCreated();
                return Context.Cars.ToList();
            }
        }

        public void Update(Car car)
        {
            using (CarDataBaseContext Context = new())
            {

                if(Context.Cars.Any(c=>c.Num == car.Num))
                {
                    //Context.Entry(CarUpdate).State = EntityState.Deleted;
                    Context.Update(car);
                    Context.SaveChanges();
                }
                   
            }
            
        }
    }
}
