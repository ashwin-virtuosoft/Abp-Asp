using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AbpStudy.Models
{
    public class Client:AggregateRoot<Guid>
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set;}
        public int? Age {  get; set; }
    }
}
