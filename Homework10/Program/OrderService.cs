using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Order
{
    public class OrderService
    {
        public void Add(OrderList order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
        }

        public void Delete(string orderId)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("ListOfDetails").SingleOrDefault(o => o.OrderId == orderId);
                //db.DetailsList.RemoveRange(order.ListOfDetails);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }

        public void Update(OrderList order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.ListOfDetails.ForEach(detail => db.Entry(detail).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public OrderList GetOrder(string Id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("ListOfDetails").
                  SingleOrDefault(o => o.OrderId == Id);
            }
        }

        public List<OrderList> GetAllOrders()
        {
            using (var db = new OrderDB())
                return db.Order.Include("ListOfDetails").ToList();
        }

        public List<OrderList> QueryByOrderId(string id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("ListOfDetails")
                  .Where(o => o.OrderId.Equals(id)).ToList();
            }
        }

        public List<OrderList> QueryByClientName(string name)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("ListOfDetails")
                  .Where(o => o.ClientName.Equals(name)).ToList();
            }
        }

        public List<OrderList> QueryByProductName(string name)
        {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("ListOfDetails")
                  .Where(o => o.ListOfDetails.Where(
                    detail => detail.ProductName.Equals(name)).Count() > 0);
                return query.ToList();
            }
        }

        public List<OrderList> QueryByTotalPriceOver(long num)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("ListOfDetails")
                  .Where(o => o.TotalPrice >= num).ToList();
            }
        }

        // 序列化
        public void Import(string xmlFileName)
        {
            using (var db = new OrderDB())
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<OrderList>));
                FileStream fs = new FileStream(xmlFileName, FileMode.Open);
                //db.OrderList = (List<Order>)xmlser.Deserialize(fs);
                foreach (OrderList order in (List<OrderList>)xmlser.Deserialize(fs))
                    Add(order);
                fs.Close();
            }
        }

        public void Export(string xmlFileName)
        {
            using (var db = new OrderDB())
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<OrderList>));
                FileStream fs = new FileStream(xmlFileName, FileMode.OpenOrCreate);
                xmlser.Serialize(fs, db.Order);
                fs.Close();
            }
        }
    }
}
