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
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Repository.Document, Models.Document>()
                                        .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.Account))
                                        .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(src => src.Account1))
                                        .ForMember(d => d.Created, opt => opt.MapFrom(src => ((DateTime)src.Created).ToString("yyyy-MM-dd")))
                                        .ForMember(d => d.LastModified, opt => opt.MapFrom(src => ((DateTime)src.LastModified).ToString("yyyy-MM-dd")))
                                        .ForMember(d => d.DocumentDescription, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.DocumentDescription)))
                                        .ForMember(d => d.DocumentName, opt => opt.MapFrom(src => src.DocumentType.Contains("folder")? src.DocumentName: src.DocumentName + "." + src.DocumentType))
                                        .ForMember(d => d.DocumentContent, opt => opt.Ignore())
                                        .ForMember(d => d.Tags, opt => opt.MapFrom(src => src.DocumentTags.Select(dt => new Models.Tag() { Id = dt.Tag.Id, TagName = dt.Tag.TagName })));
                                        
                cfg.CreateMap<Repository.Document, Models.DocumentContent>()
                                        .ForMember(d => d.Id, opt => opt.MapFrom(src => src.DocumentContent.Id))
                                        .ForMember(d => d.Content, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.DocumentContent.Content)));

                cfg.CreateMap<Repository.Document, Models.DocumentTreeView>();

                cfg.CreateMap<Models.Document, Repository.Document>()
                                        .ForMember(repo => repo.CreateBy, model => model.MapFrom(src => src.CreateByID))
                                        .ForMember(repo => repo.LastModifiedBy, model => model.MapFrom(src => src.LastModifiedByID))
                                        .ForMember(repo => repo.DocumentName, model => model.MapFrom(src => src.DocumentName))
                                        .ForMember(repo => repo.DocumentType, model => model.MapFrom(src => src.DocumentType))
                                        .ForMember(repo => repo.DocumentSize, model => model.MapFrom(src => src.DocumentSize))
                                        .ForMember(repo => repo.DocumentDescription, model => model.MapFrom(src => src.DocumentDescription))
                                        .ForMember(repo => repo.DocumentContentId, model => model.MapFrom(src => src.DocumentContentId))
                                        .ForMember(repo => repo.ParentId, model => model.MapFrom(src => src.ParentId))
                                        .ForMember(repo => repo.DocumentTermsID, model => model.MapFrom(src => src.TermId))
                                        .ForMember(repo => repo.Id, model => model.Ignore())
                                        .ForMember(repo => repo.DocumentContent, model => model.Ignore());
                                        //.ForMember(repo => repo.Account, model => model.Ignore())
                                        //.ForMember(repo => repo.Account1, model => model.Ignore());
                cfg.CreateMap<Models.DocumentContent, Repository.DocumentContent>();
                cfg.CreateMap<Repository.DocumentTerm, Repository.DocumentTerm>();
                //.ForMember();
                //lots more maps...here!
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
