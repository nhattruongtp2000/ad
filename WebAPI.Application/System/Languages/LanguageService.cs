//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebAPI.Data.EF;
//using WebAPI.ViewModels.Common;
//using WebAPI.ViewModels.System.Languages;

//namespace WebAPI.Application.System.Languages
//{
//    public class LanguageService : ILanguageService
//    {
//        private readonly IConfiguration _config;
//        private readonly WebApiDbContext _context;

//        public LanguageService(WebApiDbContext context,
//            IConfiguration config)
//        {
//            _config = config;
//            _context = context;
//        }

//        public async Task<ApiResult<List<LanguageVm>>> GetAll()
//        {
//            var languages = await _context.Languages.Select(x => new LanguageVm()
//            {
//                Id = x.Id,
//                Name = x.Name
//            }).ToListAsync();
//            return new ApiSuccessResult<List<LanguageVm>>(languages);
//        }
//    }
//}

