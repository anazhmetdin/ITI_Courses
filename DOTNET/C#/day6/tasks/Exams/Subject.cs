using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    internal class Subject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Subject(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
