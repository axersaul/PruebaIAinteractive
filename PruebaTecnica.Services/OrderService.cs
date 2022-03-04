using PruebaTecnica.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnica.Services
{
    public static class OrderService
    {
        public static string CreateOrder(List<OrderDetail> details)
        {
            try
            {
                Stock productToOrder;
                int maxID = AppCache.OrderInstance.Count == 0 ? 1 : AppCache.OrderInstance.Max(x => x.Id) + 1;
                Order order = new() { Id = maxID, Status = StatusOrder.Pending};
                int count;
                OrderDetail orderDetail;
                string messageToReturn = "Se ha realizado el pedido";
                var groupDetails = from detail in details
                                   group detail by detail.Product.Sku;

                foreach(var group in groupDetails)
                {
                    count = 0;
                    orderDetail = new();
                    foreach(var product in group)
                    {
                        count += product.Quantity;
                    }
                    productToOrder = AppCache.StockInstance.Find(stock => stock.Product.Sku == group.Key);
                    if(productToOrder is null)
                    {
                        messageToReturn = $"No hay ese producto -> {group.Key} en stock";
                        if (order.Status != StatusOrder.Canceled)
                            order.Status = StatusOrder.Canceled;
                        break;
                    }
                    //set values to orderDetail
                    orderDetail.Product.Name = productToOrder.Product.Name;
                    orderDetail.Product.Sku = productToOrder.Product.Sku;
                    orderDetail.Quantity = count;
                    if (productToOrder.StockQuantity >= count)
                    {
                        productToOrder.StockQuantity -= count;
                    }
                    else
                    {
                        messageToReturn = $"No hay existencias para -> {group.Key}";
                        if (order.Status != StatusOrder.Canceled)
                            order.Status = StatusOrder.Canceled;
                    }
                    order.Details.Add(orderDetail);
                }
                AppCache.OrderInstance.Add(order);
                return messageToReturn;
            }
            catch (Exception ex)
            {

                return "ERROR";
            }
        }

        public static int ChangeStatusOrder(int idOrder, StatusOrder statusToChange)
        {
            try
            {
                AppCache.OrderInstance.Find(or => or.Id == idOrder).Status = statusToChange;
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}
