//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using WebAPI.Data.EF;
//using WebAPI.ViewModels.Utilities.Slides;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;

//namespace WebAPI.Application.Utilities.Slides
//{
//    public class SlideService : ISlideService
//    {
//        private readonly WebApiDbContext _context;

//        public SlideService(WebApiDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<SlideVm>> GetAll()
//        {
//            var slides = await _context.Slides.OrderBy(x => x.SortOrder)
//                .Select(x => new SlideVm()
//                {
//                    Id = x.Id,
//                    Name = x.Name,
//                    Description = x.Description,
//                    Url = x.Url,
//                    Image = x.Image
//                }).ToListAsync();

//            return slides;
//        }
//    }
//}
