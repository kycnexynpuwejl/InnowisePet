using System.Data;
using Dapper;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Storage.DAL.Repo.Interfaces;

namespace InnowisePet.Services.Storage.DAL.Repo.Implementations;

public class StorageRepository : IStorageRepository
{
    private readonly IDbConnection _dbConnection;

    public StorageRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<StorageModel>> GetStoragesAsync()
    {
        const string sql = @"
                            SELECT Id, Title
                            FROM [dbo].[Storages]
                            ";

        return await _dbConnection.QueryAsync<StorageModel>(sql);
    }

    public async Task<StorageModel> GetStorageByIdAsync(Guid id)
    {
        string sql = $@"
                        SELECT Id, Title
                        FROM [dbo].[Storages]
                        WHERE Id = '{id}'
                       ";

        return await _dbConnection.QueryFirstAsync<StorageModel>(sql);
    }

    public async Task<bool> CreateStorageAsync(StorageModel storageModel)
    {
        const string sql = @"
                            INSERT INTO [dbo].[Storages]
                                (Id, Title)
                            VALUES(@Id, @Title)
                            ";
        int result = await _dbConnection.ExecuteAsync(sql, storageModel);

        return result > 0;
    }

    public async Task<bool> UpdateStorageAsync(StorageModel storageModel)
    {
        const string sql = @"
                        UPDATE [dbo].[Storages]
                        SET
                            Title = @Title
                        WHERE Id = @Id
                        ";

        int result = await _dbConnection.ExecuteAsync(sql, storageModel);

        return result > 0;
    }

    public async Task<bool> DeleteStorageAsync(Guid id)
    {
        string sql = $@"
                        DELETE FROM [dbo].[Storages]
                        WHERE Id = '{id}'
                        ";
        int result = await _dbConnection.ExecuteAsync(sql);

        return result > 0;
    }
}