using TestProject.Models;

namespace TestProject.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// 查詢所有員工資訊
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EmployeeModel>> GetAllAsync();

        /// <summary>
        /// 查詢單一員工資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmployeeModel> GetByIdAsync(int id);

        /// <summary>
        /// 新增員工資訊
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<int> AddAsync(EmployeeModel employee);

        /// <summary>
        /// 修改員工資訊
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(EmployeeModel employee);

        /// <summary>
        /// 刪除員工資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(int id);
    }
}
