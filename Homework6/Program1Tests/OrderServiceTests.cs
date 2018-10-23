using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void CheckNumTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);
            Assert.IsTrue(o.CheckNum(o.ListOfOrder[0].OrderNum));
        }

        [TestMethod()]
        public void CheckRepeatTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            Order o2 = new Order();
            o2.OrderNum = "1";

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);
            o.ListOfOrder.Add(o2);
            Assert.IsFalse(o.CheckRepeat(o.ListOfOrder[0].OrderNum));
        }

        [TestMethod()]
        public void SearchByOrderNumTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);

            List<Order> list = new List<Order>();
            list = o.SearchByOrderNum(1);
            Assert.IsTrue(list[0].OrderNum == "1");
        }

        [TestMethod()]
        public void SearchByClientNameTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);

            List<Order> list = new List<Order>();
            list = o.SearchByClientName("快乐");
            Assert.IsTrue(list[0].ClientName == "快乐");
        }

        [TestMethod()]
        public void SearchByProductNameTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);

            List<Order> list = new List<Order>();
            list = o.SearchByProductName("qw");
            Assert.IsTrue(list[0].ListOfDetails[0].ProductName == "qw");
        }

        [TestMethod()]
        public void SearchByPriceOfProductTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);

            List<Order> list = new List<Order>();
            list = o.SearchByPriceOfProduct(100);
            Assert.IsTrue(list[0].ListOfDetails[0].PriceOfProduct == 100);
        }

        [TestMethod()]
        public void SearchByNumOfProductTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);

            List<Order> list = new List<Order>();
            list = o.SearchByNumOfProduct(1);
            Assert.IsTrue(list[0].ListOfDetails[0].NumOfProduct == 1);
        }

        [TestMethod()]
        public void SearchByWhichTotalPriceOverTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);

            List<Order> list = new List<Order>();
            list = o.SearchByWhichTotalPriceOver(50);
            Assert.IsTrue(list[0].TotalPrice >= 50);
        }

        [TestMethod()]
        public void DelOrderByOrderNumTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);

            o.DelOrderByOrderNum(1);
            Assert.IsFalse(o.ListOfOrder.Any());
        }

        [TestMethod()]
        public void DelOrderByTagTest()
        {
            Order o1 = new Order();
            o1.OrderNum = "1";
            o1.ClientName = "快乐";
            o1.ProductCategory = 1;
            o1.TotalPrice = 100;
            OrderDetails od = new OrderDetails();
            od.ProductName = "qw";
            od.PriceOfProduct = 100;
            od.NumOfProduct = 1;
            o1.ListOfDetails.Add(od);

            OrderService o = new OrderService();
            o.ListOfOrder.Add(o1);

            o.DelOrderByOrderNum(1);
            Assert.IsFalse(o.ListOfOrder.Any());
        }
    }
}