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
                //cfg.CreateMap<Models.DocumentType, DocumentType>();

                //.ForMember();
                //lots more maps...here!
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
