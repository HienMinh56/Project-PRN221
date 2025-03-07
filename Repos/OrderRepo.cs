﻿using BOs.Entities;
using DAOs;
using Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly OrderDAO _orderDAO;

        public OrderRepo()
        {
            _orderDAO = new OrderDAO();
        }

        public async Task AddOrder(Order order)
        {
            await _orderDAO.AddOrder(order);
        }


        public async Task UpdateOrderStatus(string orderId, int status)
        {
            await _orderDAO.UpdateOrderStatus(orderId, status);
        }

        public async Task CancelOrder()
        {
            await _orderDAO.CancelOrder();
        }

        public List<Order> GetOrderbyUserId(string userId)
        {
            return OrderDAO.Instance.GetOrderbyUserId(userId);
        }

        public List<Order> GetOrders()
        {
            return _orderDAO.GetOrders();
        }

        public Order GetOrderById(string OrderId)
        {
            return _orderDAO.GetOrderById(OrderId);
        }

        public async Task<string> GenerateOrderId()
        {
            return await _orderDAO.GenerateOrderId();
        }
    }
}