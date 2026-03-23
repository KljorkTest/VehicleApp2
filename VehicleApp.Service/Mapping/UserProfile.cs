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
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserEntity>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<UserEntity, User>();
        }
    }
}
