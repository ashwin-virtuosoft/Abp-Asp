using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpStudy.DTOs
{
    public class ClientDto:EntityDto<Guid>
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set;}
        public int? Age { get; set; }   
    }
}
