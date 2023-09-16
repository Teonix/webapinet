using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapinet.Services.Interfaces
{
    public interface IFruitService
    {
        Task<List<Fruit>> GetList();
        Task<Fruit> GetFruitById(int id);
        Task<List<Fruit>> AddFruit(Fruit fruit);
        Task<List<Fruit>> UpdateFruit(Fruit requestFruit, int id);
        Task<List<Fruit>> DeleteFruit(Fruit fruit);    
    }
}