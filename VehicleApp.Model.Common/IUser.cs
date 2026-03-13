using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Common/Paging.cs
namespace Common
{
    public class Paging
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
========
namespace VehicleApp.Model.Common
{
    public interface IUser
    {
        Guid Id { get; set; }
        string UserName { get; set; }
>>>>>>>> feature/project-setup:VehicleApp.Model.Common/IUser.cs
    }
}
