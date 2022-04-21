using WebApi.Models.Db;

namespace WebApi.Base.IServices
{
    public interface IProductService
    {
        /// <summary>
        /// 取得一筆產品資料
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        Task<Product?> GetByIdAsync(int id);

        /// <summary>
        /// 取得所有產品資料
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// 新增一筆產品
        /// </summary>
        /// <param name="product">產品資料</param>
        /// <returns></returns>
        Task CreateAsync(Product product);

        /// <summary>
        /// 修改一筆產品
        /// </summary>
        /// <param name="id">編號</param>
        /// <param name="product">產品資料</param>
        /// <returns></returns>
        Task UpdateAsync(int id, Product product);

        /// <summary>
        /// 刪除一筆產品
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
