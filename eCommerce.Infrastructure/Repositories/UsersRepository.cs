using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;
internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();


        //string query = "INSERT INTO public.\"Users\"(\"UserId\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES(@UserId, @Email, @PersonName, @Gender, @Password) ";
        string query = @"
                        INSERT INTO public.""Users""(""UserId"",""Email"",""PersonName"",""Gender"",""Password"") 
                        VALUES(@UserId, @Email, @PersonName, @Gender, @Password) ";

        var rowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if (rowsAffected > 0)
        {
            return user;
        }

        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = " SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password ";
        var parameters = new { Email = email, Password = password };

        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
    }
}

