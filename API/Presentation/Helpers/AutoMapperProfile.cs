using AppCore.Entities;
using AppCore.Model.Montadora;

using AutoMapper;

namespace Presentation
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AutomovelEntity, Automovel>()
                .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id.ToString()))
                .ForMember(des => des.Creat, opt => opt.MapFrom(s => s.Created))
                .ForMember(des => des.Update, opt => opt.MapFrom(s => s.Updated));
            CreateMap<Automovel, AutomovelEntity>();

            CreateMap<AutomovelEntity, CreatAutomo>();
            CreateMap<CreatAutomo, AutomovelEntity>();

            /**/////////////////////////////////////////////////////





        }
    }
}
