using StudentsList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();

            Students = new() {
                new Student(1, "student1", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(2, "student2", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(3, "student3", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(4, "student4", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(5, "student5", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(6, "student6", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(7, "student7", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(8, "student8", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(9, "student9", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(10, "student10", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(11, "student11", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(12, "student12", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(13, "student13", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(14, "student14", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(15, "student15", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(16, "student16", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(17, "student17", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(18, "student18", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(19, "student19", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(20, "student20", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(21, "student21", 24, 90, System.IO.Path.GetFullPath("img.jpg")),
                new Student(22, "student22", 24, 90, System.IO.Path.GetFullPath("img.jpg"))
            };

            StudentsList.ItemsSource = Students;
        }
    }

    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int grade { get; set; }
        public string image { get; set; }

        public Student(int _id, string _name, int _age, int _grade, string _image)
        {
            id = _id;
            name = _name;
            age = _age;
            grade = _grade;
            image = _image;
        }
    }
}