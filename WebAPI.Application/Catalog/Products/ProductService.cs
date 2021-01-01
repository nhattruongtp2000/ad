using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.Data.Entities;
using WebAPI.Utilities.Exceptions;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using WebAPI.ViewModels.Catalog.ProductImages;
using WebAPI.Utilities.Constants;

namespace WebAPI.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly WebApiDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public ProductService(WebApiDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<string> AddImage(string productId, ProductImageCreateRequest request)
        {
            var productImage = new productPhotos()
            {
                IdPhoto=request.idImage,
                idProduct=request.idProduct,
                uploadedTime=DateTime.Now,       
                
            };

            if (request.ImageFile != null)
            {
                productImage.link = new string("https://localhost:5001" + await this.SaveFile(request.ImageFile));
            }
            _context.productPhotos.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.IdPhoto;
        }


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        public async Task<string> Create(ProductCreateRequest request)
        {
            var product = new products()
            {
                idProduct=request.idProduct,
                productName=request.productName,
                expiredSalingDate=request.expiredSalingDate,
                idSize = request.idSize,
                idBrand = request.idBrand,
                idColor = request.idColor,
                idType = request.idType,
                idCategory = request.idCategory,
                isSaling=request.isSaling,
                price = request.price,
                salePrice = request.salePrice,
                detail=request.detail,
                dateAdded=DateTime.Now,
                photoReview= new string("https://localhost:5001"+ await this.SaveFile(request.ThumbnailImage))
            };

            //Save image
            if (request.ThumbnailImage != null)
            {
                product.productPhotos = new List<productPhotos>()
                {
                    new productPhotos()
                    {
                        IdPhoto=RandomString(4),
                        uploadedTime = DateTime.Now,
                        link = new string("https://localhost:5001"+ await this.SaveFile(request.ThumbnailImage)),
                        idProduct=request.idProduct
                    }
                };
            }
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return product.idProduct;
        }

        public async Task<int> Delete(string idProduct)
        {
            var product = await _context.products.FindAsync(idProduct);
            if (product == null) throw new WebAPIException($"Cannot find a product: {idProduct}");

            var images = _context.productPhotos.Where(i => i.idProduct == idProduct);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.link);
            }

            _context.products.Remove(product);
            return await _context.SaveChangesAsync();
        }

      

        

        public async Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.products
                        join pic in _context.productCategories on p.idCategory equals pic.idCategory into ppic
                        from pic in ppic.DefaultIfEmpty()

                        select new { p,  pic};
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.productName.Contains(request.Keyword));

            if (request.CategoryId != null && request.CategoryId != null)
            {
                query = query.Where(p => p.pic.idCategory == request.CategoryId);
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    idProduct = x.p.idProduct,
                    productName=x.p.productName,
                    idSize = x.p.idSize,
                    idBrand = x.p.idBrand,
                    idColor = x.p.idColor,
                    idType = x.p.idType,
                    idCategory = x.p.idCategory,
                    price = x.p.price,
                    salePrice = x.p.salePrice,
                    detail = x.p.detail,
                    dateAdded = DateTime.Now,
                    photoReview = x.p.photoReview.Substring(22)
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    
        public async Task<ProductVm> GetById(string productId)
        {
            var product = await _context.products.FindAsync(productId);


            var categories = await (from c in _context.products
                                    join ct in _context.productCategories on c.idCategory equals ct.idCategory
                                    where c.idCategory == productId 
                                    select ct.categoryName).ToListAsync();


            var image = await _context.productPhotos.Where(x => x.idProduct == productId ).FirstOrDefaultAsync();
            var productViewModel = new ProductVm()
            {
                idProduct = product.idProduct,
                idSize = product.idSize,
                idBrand = product.idBrand,
                idColor = product.idColor,
                idType = product.idType,
                idCategory = product.idCategory,
                price = product.price,
                salePrice = product.salePrice,
                detail = product.detail,
                dateAdded = DateTime.Now,
                photoReview = "a",
                ThumbnailImage = image!=null?image.link:"no-image.jpg"
            };
            return productViewModel;
        }


        public async Task<ProductImageViewModel> GetImageById(string imageId)
        {
            var image = await _context.productPhotos.FindAsync(imageId);
            if (image == null)
                throw new WebAPIException($"Cannot find an image with id {imageId}");

            var viewModel = new ProductImageViewModel()
            {
                uploadedTime = DateTime.Now,
                link = image.link,
                idProduct = image.idProduct,
            };
            return viewModel;
        }

        //public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        //{
        //    return await _context.productPhotos.Where(x => x.idProduct == productId)
        //        .Select(i => new ProductImageViewModel()
        //        {
        //            Caption = i.Caption,
        //            uploadedTime = i.uploadedTime,
        //            FileSize = i.FileSize,
        //            Id = i.Id,
        //            ImagePath = i.ImagePath,
        //            IsDefault = i.IsDefault,
        //            IdProduct = i.idProduct,
        //            SortOrder = i.SortOrder
        //        }).ToListAsync();
        //}

        public async Task<int> RemoveImage(string imageId)
        {
            var productImage = await _context.productPhotos.FindAsync(imageId);
            if (productImage == null)
                throw new WebAPIException($"Cannot find an image with id {imageId}");
            _context.productPhotos.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.products.FindAsync(request.idProduct);
           

            if (product == null) throw new WebAPIException($"Cannot find a product with id: {request.idProduct}");

            product.photoReview = request.photoReview;
            product.productName = request.productName;
            product.idCategory = request.idCategory;
            product.price = request.price;
            product.salePrice = request.salePrice;
            product.detail = request.detail;
            product.idBrand = request.idBrand;
            product.idType = request.idType;
            product.idSize = request.idSize;
            product.idColor = request.idColor;
            


            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.productPhotos.FirstOrDefaultAsync(i=> i.idProduct == request.idProduct);
                if (thumbnailImage != null)
                {
                    thumbnailImage.link = await this.SaveFile(request.ThumbnailImage);
                    _context.productPhotos.Update(thumbnailImage);
                }
            }


            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(string imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.productPhotos.FindAsync(imageId);
            if (productImage == null)
                throw new WebAPIException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.link = await this.SaveFile(request.ImageFile);
            }
            _context.productPhotos.Update(productImage);
            return await _context.SaveChangesAsync();

        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<PagedResult<ProductVm>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            var query = from p in _context.products
                        join pt in _context.productCategories on p.idCategory equals pt.idCategory
                        select new { p, pt };
            //2. filter
            if (request.idCategory!=null)
                query = query.Where(p => p.pt.idCategory == request.idCategory);

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    idProduct = x.p.idProduct,
                    productName=x.p.productName,
                    idSize = x.p.idSize,
                    idBrand = x.p.idBrand,
                    idColor = x.p.idColor,
                    idType = x.p.idType,
                    idCategory = x.p.idCategory,
                    price = x.p.price,
                    salePrice = x.p.salePrice,
                    detail = x.p.detail,
                    dateAdded = DateTime.Now,
                    photoReview = "a",

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        //public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        //{
        //    var user = await _context.products.FindAsync(id);
        //    if (user == null)
        //    {
        //        return new ApiErrorResult<bool>($"Sản phẩm với id {id} không tồn tại");
        //    }
        //    foreach (var category in request.Categories)
        //    {
        //        var productInCategory = await _context.ProductInCategories
        //            .FirstOrDefaultAsync(x => x.idCategory == int.Parse(category.Id)
        //            && x.ProductId == id);
        //        if (productInCategory != null && category.Selected == false)
        //        {
        //            _context.ProductInCategories.Remove(productInCategory);
        //        }
        //        else if (productInCategory == null && category.Selected)
        //        {
        //            await _context.ProductInCategories.AddAsync(new ProductInCategory()
        //            {
        //                idCategory = int.Parse(category.Id),
        //                ProductId = id
        //            });
        //        }
        //    }
        //    await _context.SaveChangesAsync();
        //    return new ApiSuccessResult<bool>();
        //}

        public Task AddViewcount(int idProduct)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take)
        //{
        //    //1. Select join
        //    var query = from p in _context.products
        //                join pt in _context.productDetails on p.ProductId equals pt.ProductId
        //                join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId into ppic
        //                //join pi in _context.ProductImages.Where(x => x.IsDefault == true) on p.Id equals pi.ProductId
        //                from pic in ppic.DefaultIfEmpty()
        //                join pi in _context.productPhotos on p.ProductId equals pi.idProduct into ppi
        //                from pi in ppi.DefaultIfEmpty()
        //                join c in _context.Categories on pic.idCategory equals c.idCategory into picc
        //                from c in picc.DefaultIfEmpty()
        //                where pt.LanguageId == languageId && (pi == null || pi.IsDefault == true)
        //                select new { p, pt, pic,pi};

        //    var data = await query.OrderByDescending(x => x.pt.dateAdded).Take(take)
        //        .Select(x => new ProductVm()
        //        {
        //            Id = x.p.ProductId,
        //            ProductName = x.pt.ProductName,
        //            dateAdded = x.pt.dateAdded,
                    
        //            detail = x.pt.detail,
        //            LanguageId = x.pt.LanguageId,
        //            price = x.pt.price,
        //            salePrice = x.pt.salePrice,
        //            idBrand = x.p.idBrand,
        //            idColor = x.p.idColor,
        //            idSize=x.p.idSize,
        //            idType=x.p.idType,
        //            ViewCount = x.p.ViewCount,
        //            ThumbnailImage = x.pi.ImagePath
        //        }).ToListAsync();

        //    return data;
        //}

        //public async Task<List<ProductVm>> GetLatestProducts(string languageId, int take)
        //{
        //    //1. Select join
        //    var query = from p in _context.products
        //                join pt in _context.productDetails on p.ProductId equals pt.ProductId
        //                join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId into ppic
        //                //join pi in _context.ProductImages.Where(x => x.IsDefault == true) on p.Id equals pi.ProductId
        //                from pic in ppic.DefaultIfEmpty()
        //                join pi in _context.productPhotos on p.ProductId equals pi.idProduct into ppi
        //                from pi in ppi.DefaultIfEmpty()
        //                join c in _context.Categories on pic.idCategory equals c.idCategory into picc
        //                from c in picc.DefaultIfEmpty()
        //                where pt.LanguageId == languageId && (pi == null || pi.IsDefault == true)
        //                select new { p, pt, pic, pi };

        //    var data = await query.OrderByDescending(x => x.pt.dateAdded).Take(take)
        //        .Select(x => new ProductVm()
        //        {
        //            Id = x.p.ProductId,
        //            ProductName = x.pt.ProductName,
        //            dateAdded = x.pt.dateAdded,

        //            detail = x.pt.detail,
        //            LanguageId = x.pt.LanguageId,
        //            price = x.pt.price,
        //            salePrice = x.pt.salePrice,
        //            idBrand = x.p.idBrand,
        //            idColor = x.p.idColor,
        //            idSize = x.p.idSize,
        //            idType = x.p.idType,
        //            ViewCount = x.p.ViewCount,
        //            ThumbnailImage = x.pi.ImagePath
        //        }).ToListAsync();

        //    return data;
        //}
    }
}
