using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DocumentManagementSystem.Repository.Automapper
{
    public class AutoMapperConfig : IAutoMapperConfig
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DocumentType, Models.DocumentType>();
                cfg.CreateMap<Models.DocumentType, DocumentType>();

                cfg.CreateMap<Document, Models.DocumentContent>()
                                        .ForMember(d => d.Id, opt => opt.MapFrom(src => src.DocumentContent.Id))
                                        .ForMember(d => d.Content, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.DocumentContent.Content)));

                //.ForMember();
                //lots more maps...here!
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
