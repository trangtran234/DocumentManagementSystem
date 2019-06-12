using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocumentManagementSystem.Models.Common;

namespace DocumentManagementSystem.Services.Automapper
{
    //public class AutoMapperConfig : IAutoMapperConfig
    //{
    //    public IMapper GetMapper()
    //    {
    //        var config = new MapperConfiguration(cfg => {
    //            cfg.CreateMap<Repository.Document, Models.Document>()
    //                                    .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.Account))
    //                                    .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(src => src.Account1))
    //                                    .ForMember(d => d.DocumentDescription, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.DocumentDescription)))
    //                                    .ForMember(d => d.DocumentName, opt => opt.MapFrom(src => src.DocumentType.Contains("folder") ? src.DocumentName : src.DocumentName + "." + src.DocumentType))
    //                                    .ForMember(d => d.DocumentContent, opt => opt.Ignore())
    //                                    .ForMember(d => d.Tags, opt => opt.MapFrom(src => src.DocumentTags.Select(dt => new Models.Tag() { Id = dt.Tag.Id, TagName = dt.Tag.TagName })))
    //                                    .ForMember(d => d.DocumentTypes, opt => opt.MapFrom(src => src.DocumentTypes.Select(dt => new Models.DocumentType() { Id = dt.Id, Type = dt.Type })));

    //            cfg.CreateMap<Repository.Document, Models.DocumentContent>()
    //                                    .ForMember(d => d.Id, opt => opt.MapFrom(src => src.DocumentContent.Id))
    //                                    .ForMember(d => d.Content, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.DocumentContent.Content)));

    //            cfg.CreateMap<Repository.Document, Models.DocumentTreeView>();

    //            cfg.CreateMap<Models.Document, Repository.Document>()
    //                                    .ForMember(repo => repo.CreateBy, model => model.MapFrom(src => src.CreateByID))
    //                                    .ForMember(repo => repo.LastModifiedBy, model => model.MapFrom(src => src.LastModifiedByID))
    //                                    .ForMember(repo => repo.DocumentContent, model => model.Ignore());

    //            cfg.CreateMap<Models.DocumentContent, Repository.DocumentContent>();
    //            cfg.CreateMap<Repository.DocumentType, Models.DocumentType>();
    //            cfg.CreateMap<Models.DocumentType, Repository.DocumentType>();
    //            cfg.CreateMap<Repository.DocumentHistory, Models.DocumentHistory>()
    //                                    .ForMember(model => model.ActionEvent, opt => opt.MapFrom(repo => (Helper.HistoryAction)Enum.ToObject(typeof(Helper.HistoryAction), repo.ActionId)));
    //            //.ForMember();
    //            //lots more maps...here!
    //        });

    //        IMapper mapper = config.CreateMapper();
    //        return mapper;
    //    }
    //}
}
