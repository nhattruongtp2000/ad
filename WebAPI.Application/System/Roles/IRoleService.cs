using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.System.Roles;

namespace WebAPI.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();

    }
}
