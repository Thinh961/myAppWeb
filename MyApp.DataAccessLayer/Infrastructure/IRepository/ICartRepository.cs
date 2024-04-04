﻿using MyApp.Models;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        int IncrementCartItem(Cart cart, int count);
    }
}