using System;
using System.Collections.Generic;
using System.Text;

namespace AbpStudy.DTOs
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int Age { get; set; }
        public int BatchId { get; set; }
    }
}
