using Microsoft.Data.SqlClient.DataClassification;
using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.DtoModels.DtoBasket;
using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsBasket
{
    public interface ICartService
    {
        public Task<List<DtoCartResponce>> GetCartItemsByUsers(Guid userId);
    }
}
