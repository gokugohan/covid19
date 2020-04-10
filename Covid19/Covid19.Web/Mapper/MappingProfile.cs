using AutoMapper;
using Covid19.Entities.Models;
using Covid19.Web.Areas.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Web.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Quarantine, QuarantineViewModel>()
                .ForMember(m=>m.Obrigatorio,m=>m.MapFrom(m=>m.KuarentenaObrigatorio))
                .ForMember(m=>m.Auto,m=>m.MapFrom(m=>m.AutoKuarentena))
                .ForMember(m=>m.Passa,m=>m.MapFrom(m=>m.PassaQuarentena))
                .ForMember(m=>m.Data,m=>m.MapFrom(m=>m.CreatedAt));

            this.CreateMap<QuarantineGroupByDateModel, QuarantineGroupByDateViewModel>()
                .ForMember(m=>m.Data,m=>m.MapFrom(m=>m.Quarantines))
                .ForMember(m=>m.Key,m=>m.MapFrom(m=>m.Group));
            this.CreateMap<QuarantineGroupMunicipioteModel, QuarantineGroupMunicipioteViewModel>()
                .ForMember(m => m.Data, m => m.MapFrom(m => m.Quarantines))
                .ForMember(m => m.Key, m => m.MapFrom(m => m.Group));

            this.CreateMap<Graph, GraphViewModel>();
        }
    }
}
