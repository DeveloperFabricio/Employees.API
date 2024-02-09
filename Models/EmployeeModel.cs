using Employees.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Employees.API.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DepartamentEnum Departament { get; set; }
        public bool Active { get; set; }
        public ShiftEnum Shift { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime ChangeDate { get; set; } = DateTime.Now.ToLocalTime();
    }
}
