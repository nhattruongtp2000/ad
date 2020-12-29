using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.System.Users;

namespace WebAPI.ApiIntegration
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);

        Task<ApiResult<bool>> UpdateUser(string id, UserUpdateRequest request);

        Task<ApiResult<UserVm>> GetById(string id);

        Task<ApiResult<bool>> Delete(string id);

        Task<ApiResult<bool>> RoleAssign(string id, RoleAssignRequest request);

    }
}
