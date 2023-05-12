using CommunityToolkit.Mvvm.ComponentModel;
using MVVMDay23.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.Model
{
    public partial class Student:ObservableObject
    {
        [ObservableProperty]
        int id;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string address;
        [ObservableProperty]
        int age;
    }
}
