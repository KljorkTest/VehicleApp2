using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VehicleApp.Model;
using VehicleApp.DAL;

namespace VehicleApp.Service.Mapping
{
    public class VehicleModelProfile : Profile
    {
        public VehicleModelProfile()
        {
            CreateMap<VehicleModel, VehicleModelEntity>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.VehicleMake, opt => opt.Ignore());

            CreateMap<VehicleModelEntity, VehicleModel>();
                
        }
    }
}
