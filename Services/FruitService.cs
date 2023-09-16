using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapinet.Services.Interfaces;

namespace webapinet.Services
{
    public class FruitService : IFruitService
    {
        private readonly DataContext _context;

        public FruitService(DataContext context){
            _context = context;
        }

        public async Task<List<Fruit>> GetList()
        {
            return await _context.Fruits.ToListAsync();
        }

        public async Task<Fruit> GetFruitById(int id)
        {
            return await _context.Fruits.FindAsync(id);
        }

        public async Task<List<Fruit>> AddFruit(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();
            return await _context.Fruits.ToListAsync();
        }

        public async Task<List<Fruit>> UpdateFruit(Fruit requestFruit, int id)
        {
                var fruit = await _context.Fruits.FindAsync(id);
                fruit.Name = requestFruit.Name;
                fruit.Color = requestFruit.Color;
                await _context.SaveChangesAsync();
                return await _context.Fruits.ToListAsync();
        }

        public async Task<List<Fruit>> DeleteFruit(Fruit fruit)
        {
                _context.Fruits.Remove(fruit);
                await _context.SaveChangesAsync();
                return await _context.Fruits.ToListAsync();
        }
    }
}