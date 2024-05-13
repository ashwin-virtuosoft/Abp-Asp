using AbpStudy.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AbpStudy.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetListAsync();
        Task<ClientDto> GetByIdAsync(Guid id);
        Task<ClientDto> CreateAsync(ClientDto dto);
        Task<ClientDto> UpdateAsync(ClientDto dto);
        Task<bool> DeleteAsync(Guid id);

        
    }
}
