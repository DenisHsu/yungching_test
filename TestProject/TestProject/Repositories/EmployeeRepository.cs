using Dapper;
using System.Data;
using TestProject.Models;

namespace TestProject.Repositories
{
    public class EmployeeRepository
    {
        private readonly IDbConnection _dbConnection;

        public EmployeeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// 查詢所有員工資訊
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
        {

            var vSql = "SELECT LastName, FirstName, Title, Address, City, Country, HomePhone FROM Employees";
            var result = await _dbConnection.QueryAsync<EmployeeModel>(vSql);

            return result.ToList();
        }

        /// <summary>
        /// 查詢單一員工資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            var vSql = "SELECT LastName, FirstName, Title, Address, City, Country, HomePhone FROM Employees WHERE EmployeeID = @Id";
            var result = await _dbConnection.QueryFirstOrDefaultAsync<EmployeeModel>(vSql, new { Id = id });

            return result;
        }

        /// <summary>
        /// 新增員工資訊
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(EmployeeModel employee)
        {
            var vSql = @"INSERT INTO Employees (LastName, FirstName, Title, Address, City, Country, HomePhone)
            VALUES (@LastName, @FirstName, @Title, @Address, @City, @Country, @HomePhone);";
            var result = await _dbConnection.ExecuteScalarAsync<int>(vSql, employee);

            return result;
        }

        /// <summary>
        /// 修改員工資訊
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(EmployeeModel employee)
        {
            var sql = @"UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title, 
                Address = @Address, City = @City, Country = @Country, HomePhone = @HomePhone
            WHERE EmployeeID = @EmployeeID";
            var result = await _dbConnection.ExecuteAsync(sql, employee);

            return result;
        }

        /// <summary>
        /// 刪除員工資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Employees WHERE EmployeeID = @Id";
            var result = await _dbConnection.ExecuteAsync(sql, new { Id = id });

            return result;
        }
    }
}
