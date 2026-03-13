using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Model.Common;

namespace VehicleApp.Model
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
