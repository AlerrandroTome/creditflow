using AutoMapper;
using creditflow.services.client.application.ViewModels;
using creditflow.services.client.core.Entities;

namespace creditflow.services.client.application.AutoMapper
{
    internal class Profile : global::AutoMapper.Profile
    {
        protected Profile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
