using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpStudy.Models
{
    public class JobDetails
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Department { get; set; }
        public string Desired_Position { get; set; }
        public decimal Desired_Salary { get; set; }
        public DateTime Join_Date { get; set; }
    }
    
}
