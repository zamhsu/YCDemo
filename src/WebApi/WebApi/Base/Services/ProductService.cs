using Microsoft.EntityFrameworkCore;
using WebApi.Base.IRepositories;
using WebApi.Base.IServices;
using WebApi.Models;
using WebApi.Models.Db;

namespace WebApi.Base.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product> productRepo,
            IUnitOfWork unitOfWork)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 取得一筆產品資料
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        public async Task<Product?> GetByIdAsync(int id)
        {
            Product? product = await _productRepo.GetAsync(q => q.Id == id && 
                q.Status == (int)ProductStatusEnum.Ok);

            return product;
        }

        /// <summary>
        /// 取得所有產品資料
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IQueryable<Product> query = _productRepo.GetAllNoTracking()
                .Where(q => q.Status == (int)ProductStatusEnum.Ok);

            return await query.ToListAsync();
        }

        /// <summary>
        /// 新增一筆產品
        /// </summary>
        /// <param name="product">產品資料</param>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task CreateAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.Guid = Guid.NewGuid();
            product.CreateDate = DateTime.Now;

            await _productRepo.CreateAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 修改一筆產品
        /// </summary>
        /// <param name="id">編號</param>
        /// <param name="product">產品資料</param>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task UpdateAsync(int id, Product product)
        {
            Product? entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("無此資料", nameof(id));
            }

            entity.Title = product.Title;
            entity.Price = product.Price;
            entity.Description = product.Description;
            entity.UpdateDate = DateTime.Now;

            _productRepo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 刪除一筆產品
        /// </summary>
        /// <param name="id">編號</param>
        /// <exception cref="ArgumentException"></exception>
        public async Task DeleteAsync(int id)
        {
            Product? entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("無此資料", nameof(id));
            }

            entity.Status = (int)ProductStatusEnum.Delete;

            _productRepo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
