using System.ComponentModel.DataAnnotations;

namespace Departments.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Location { get; set; }
        
        public string Branches { get; set; }
        
        public string Description { get; set; }
    }
}
