using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VehicleApp.DAL;
using VehicleApp.Model;

namespace VehicleApp.Service.Mapping
{
    public class UserVehicleProfile : Profile
    {
        public UserVehicleProfile()
        {
            CreateMap<UserVehicle, UserVehicleEntity>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.UserId, opt => opt.Ignore())
                .ForMember(d => d.VehicleModel, opt => opt.Ignore())
                .ForMember(d => d.User, opt => opt.Ignore());

            CreateMap<UserVehicleEntity, UserVehicle>();

        }
    }
}
