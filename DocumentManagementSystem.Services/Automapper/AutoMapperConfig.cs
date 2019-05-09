using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DocumentManagementSystem.Services.Automapper
{
    public class AutoMapperConfig : IAutoMapperConfig
    {
        IMapper IAutoMapperConfig.GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Repository.Document, Models.Document>()
                                        .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.Account))
                                        .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(src => src.Account1))
                                        .ForMember(d => d.Created, opt => opt.MapFrom(src => ((DateTime)src.Created).ToString("yyyy-MM-dd")))
                                        .ForMember(d => d.LastModified, opt => opt.MapFrom(src => ((DateTime)src.LastModified).ToString("yyyy-MM-dd")))
                                        .ForMember(d => d.DocumentDescription, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.DocumentDescription)));
                //lots more maps...?
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
