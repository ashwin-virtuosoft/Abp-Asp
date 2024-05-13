using AbpStudy.BackGroundJobs;
using AbpStudy.DTOs;
using AbpStudy.Interfaces;
using AbpStudy.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.BackgroundJobs;


namespace AbpStudy.Services
{
    public class ClientService : ApplicationService, IClientService, ITransientDependency
    {
        private readonly IRepository<Client, Guid> _clientRepository;
        private readonly IBackgroundJobManager _backgroundJobManager;

        public ClientService(IRepository<Client, Guid> clientRepository, IBackgroundJobManager backgroundJobManager)
        {
            _clientRepository = clientRepository;
            _backgroundJobManager = backgroundJobManager;
           
        }

        // Background Job Console
        //public async Task EnqueueBackgroundJob()
        //{
        //    var jobArgs = new MyBackgroundJob.MyJobArgs { Argument = "Hello from background job!" };
        //    await _backgroundJobManager.EnqueueAsync<MyBackgroundJob.MyJobArgs>(jobArgs, priority: BackgroundJobPriority.Normal, delay: null);
        //}



        public async Task<List<ClientDto>> GetListAsync()
        {
            var clients = await _clientRepository.GetListAsync();
            return ObjectMapper.Map<List<Client>, List<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetByIdAsync(Guid id)
        {
            var client = await _clientRepository.GetAsync(id);
            return ObjectMapper.Map<Client, ClientDto>(client);
        }

        public async Task<ClientDto> CreateAsync(ClientDto clientDto)
        {
            var client = ObjectMapper.Map<ClientDto, Client>(clientDto);
            client = await _clientRepository.InsertAsync(client);
            return ObjectMapper.Map<Client, ClientDto>(client);
        }

        public async Task<ClientDto> UpdateAsync(ClientDto clientDto)
        {
            var existingClient = await _clientRepository.GetAsync(clientDto.Id);
            ObjectMapper.Map(clientDto, existingClient);
            existingClient = await _clientRepository.UpdateAsync(existingClient);
            return ObjectMapper.Map<Client, ClientDto>(existingClient);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _clientRepository.DeleteAsync(id);
            return true; 
        }

        


    }
}
