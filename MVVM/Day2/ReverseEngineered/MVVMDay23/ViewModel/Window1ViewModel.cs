using MVVMDay23.Command;
using MVVMDay23.DataService;
using MVVMDay23.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMDay23.ViewModel
{
    public class Window1ViewModel : ViewModelBase
    {
        public ObservableCollection<Car> CarList { get; set; }
        public Car SelectedCar { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        ObservableCar carData;
        public ObservableCar CarData
        {
            get { return carData; }
            set
            {
                carData = value;
                OnPropertyChanged();
            }
        }

        IDataService<Car> dataService;
        public Window1ViewModel(IDataService<Car> _dataService)
        {
            this.dataService = _dataService;
            CarList = new();
            CarData = new();
            SelectedCar = new();
            SaveCommand = new RelayCommand(SaveData, null);
            SelectCommand = new RelayCommand(EditeCar, null);
            DeleteCommand = new RelayCommand(DeleteCar, null);
            ResetCommand = new RelayCommand(RestData, null);
        }

        private void SaveData(object obj)
        {
            if(CarData !=null)
            {
            SelectedCar.Color = carData.Color;
            SelectedCar.Manufacture = carData.Manufacture;
            SelectedCar.Model = carData.Model;

             try
                {

                if(CarData.Num<=0)
                {
                    dataService.Add(CarData.Car);
                    MessageBox.Show("Record Added");

                }
                else
                {

                    SelectedCar.Num = carData.Num;

                    dataService.Update(SelectedCar);
                    MessageBox.Show("Record Is Updated");

                }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    Load();
                    RestData(null);

                }




            }


        }


        public void RestData( object obj)
        {
            carData.Color = String.Empty;
            carData.Model = String.Empty;
            carData.Manufacture = string.Empty;
            carData.Num = 0;
        }

        private void EditeCar(object obj)
        {
            var car = (Car)obj;
            CarData.Num =car.Num;
            CarData.Manufacture = car.Manufacture;
            CarData.Color = car.Color;
            CarData.Model = car.Model;


        }

        private void DeleteCar(object obj)
        {
            if (MessageBox.Show("Delete Record", "Are You Sure", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {

                    dataService.Delete((int)obj);
                    MessageBox.Show("Record Deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Load();
                }

            }
        }

        public void Load()
        {
            var cars = dataService.GetAll();
            CarList.Clear();
            foreach (var car in cars)
                CarList.Add(car);
        }
    }
}
