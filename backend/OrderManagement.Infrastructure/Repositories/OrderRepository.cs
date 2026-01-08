using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using OrderManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
            => await _context.Orders.AddAsync(order);

        public async Task<IEnumerable<Order>> GetAllAsync()
            => await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();

        public async Task<Order?> GetByIdAsync(Guid id)
            => await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task UpdateAsync(Order order)
        {
            var orderFromDb = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == order.Id);


            if (orderFromDb == null)
                throw new ApplicationException($"Order {order.Id} not found");

        
            if (order.Status == OrderStatus.Completed && orderFromDb.Status != OrderStatus.Completed)
                orderFromDb.Complete();

            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }

}
