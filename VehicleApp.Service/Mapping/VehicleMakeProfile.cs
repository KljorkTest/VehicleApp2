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
    public class VehicleMakeProfile : Profile
    {
        public VehicleMakeProfile()
        {
            CreateMap<VehicleMake, VehicleMakeEntity>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Models, opt => opt.Ignore());

            CreateMap<VehicleMakeEntity, VehicleMake>();
        }
    }
}
