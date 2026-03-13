using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Model.Common
{
    public interface IUser
    {
        Guid Id { get; set; }
        string UserName { get; set; }
    }
}
