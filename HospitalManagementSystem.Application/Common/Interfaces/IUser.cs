using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Common.Interfaces
{
    public interface IUser
    {
        string? Id { get; }
        List<string> Roles { get; }
    }
}
