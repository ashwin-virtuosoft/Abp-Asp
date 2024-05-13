using System;
using System.Collections.Generic;
using System.Text;

namespace AbpStudy.DTOs
{
    public class JobPortalDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public string DesiredPosition { get; set; }
        public decimal DesiredSalary { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
