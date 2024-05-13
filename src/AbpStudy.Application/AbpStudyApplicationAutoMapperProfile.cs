using AbpStudy.DTOs;
using AbpStudy.Models;
using AutoMapper;

namespace AbpStudy;

public class AbpStudyApplicationAutoMapperProfile : Profile
{
    public AbpStudyApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<ClientDto,Client>().ReverseMap();
    }
}
