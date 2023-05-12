using CarsData;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVMDay23.DataService
{
    public class CarDataService : IDataService<Car>
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://localhost:7199/api/Cars"; 

        public CarDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Add(Car car)
        {
            _httpClient.PostAsJsonAsync(_url, car).Wait();
        }

        public void Delete(int id)
        {
            _httpClient.DeleteAsync(_url+"/"+id).Wait();
        }

        public Car Get(int id)
        {
            return _httpClient.GetFromJsonAsync<Car>(_url+"/"+id).Result ?? new Car();
        }

        public IEnumerable<Car> GetAll()
        {
            return _httpClient.GetFromJsonAsync<Car[]>(_url).Result ?? Array.Empty<Car>();
        }

        public void Update(Car car)
        {
            _httpClient.PutAsJsonAsync(_url + "/" + car.Num, car).Wait();
        }
    }
}
