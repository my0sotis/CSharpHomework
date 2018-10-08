using System;
using System.Collections.Generic;

namespace Program2
{
    public class Order
    {
        public string OrderNum { set; get; }
        public string ClientName { set; get; }
        public List<OrderDetails> ListOfDetails = new List<OrderDetails>();
    }
    public class OrderDetails
    {
        public string ProductName { set; get; }
        public int NumOfProduct { set; get; }
        public int PriceOfProduct { set; get; }
    }
    public class OrderService
    {
        public List<Order> ListOfOrder = new List<Order>();
        public int num = 0;
        public void DisplayOrder(Order order)
        {
            Console.Write($"订单号:{order.OrderNum}  ");
            Console.WriteLine($"用户名:{order.ClientName}");
            foreach (OrderDetails o in order.ListOfDetails)
            {
                Console.Write($"产品名:{o.ProductName}  ");
                Console.Write($"产品单价:{o.PriceOfProduct}  ");
                Console.WriteLine($"产品数量:{o.NumOfProduct}");
            }
        }
        public void DisplayAll()
        {
            int i = 1;
            foreach (Order o in ListOfOrder)
            {
                Console.WriteLine($"{i}.");
                DisplayOrder(o);
                i++;
            }
        }
        public void AddOrder()
        {
            OrderDetails o = new OrderDetails();
            Order newOrder = new Order();
            Console.Write("请输入订单号:");
            string s = Console.ReadLine();
            while(CheckNum(s) != true)
            {
                Console.Write("请重新输入订单号:");
                s = Console.ReadLine();
            }
            newOrder.OrderNum = s;
            Console.Write("请输入用户名:");
            newOrder.ClientName = Console.ReadLine();
            Console.Write("请输入产品名:");
            o.ProductName = Console.ReadLine();
            Console.Write("请输入产品单价:");
            s = Console.ReadLine();
            while (CheckNum(s) != true)
            {
                Console.Write("请重新输入产品单价:");
                s = Console.ReadLine();
            }
            o.PriceOfProduct = int.Parse(s);
            Console.Write("请输入产品数目:");
            s = Console.ReadLine();
            while (CheckNum(s) != true)
            {
                Console.Write("请重新输入产品数目:");
                s = Console.ReadLine();
            }
            o.NumOfProduct = int.Parse(s);
            newOrder.ListOfDetails.Add(o);
            ListOfOrder.Add(newOrder);
            num++;
        }
        public bool CheckNum(string s)
        {
            try
            {
                int t = int.Parse(s);
            }catch(Exception e)
            {
                Console.WriteLine("输入错误！");
                return false;
            }
            return true;
        }
        public Order SearchByOrderNum(int num)
        {
            foreach (Order o in ListOfOrder)
            {
                int n = int.Parse(o.OrderNum);
                if (num == n)
                    return o;
            }
            return null;
        }
        public Order SearchByClientName(string name)
        {
            foreach(Order o in ListOfOrder)
            {
                if (name == o.ClientName)
                    return o;
            }
            return null;
        }
        public Order SearchByProductName(string name)
        {
            foreach (Order o in ListOfOrder)
            {
                if (name == o.ListOfDetails[0].ProductName)
                    return o;
            }
            return null;
        }
        public Order SearchByPriceOfProduct(int num)
        {
            foreach (Order o in ListOfOrder)
            {
                if (num == o.ListOfDetails[0].PriceOfProduct)
                    return o;
            }
            return null;
        }
        public Order SearchByNumOfProduct(int num)
        {
            foreach (Order o in ListOfOrder)
            {
                if (num == o.ListOfDetails[0].NumOfProduct)
                    return o;
            }
            return null;
        }
        public int InputSearchFlag()
        {
            int tag = 0;
            Console.WriteLine("请输入要查找的项目:1.订单号 2.用户名 3.产品名 4.产品单价 5.产品数目");
            try
            {
                tag = int.Parse(Console.ReadLine());
                if (!(tag >= 1 && tag <= 6))
                {
                    Console.WriteLine("输入错误！");
                    InputSearchFlag();
                }
                return tag;
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误！");
                InputSearchFlag();
            }
            return 0;
        }
        public Order Search()
        {
            Order o = new Order();
            int Flag = InputSearchFlag();
            switch (Flag)
            {
                case 1:
                    Console.Write("请输入订单号:");
                    string s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入订单号:");
                        s = Console.ReadLine();
                    }
                    o = SearchByOrderNum(int.Parse(s));
                    break;
                case 2:
                    Console.Write("请输入用户名:");
                    o = SearchByClientName(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("请输入产品名:");
                    o = SearchByProductName(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("请输入产品单价:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入产品单价:");
                        s = Console.ReadLine();
                    }
                    o = SearchByPriceOfProduct(int.Parse(s));
                    break;
                case 5:
                    Console.Write("请输入产品数目:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入产品数目:");
                        s = Console.ReadLine();
                    }
                    o = SearchByNumOfProduct(int.Parse(s));
                    break;
            }
            return o;
        }
        public int InputTag()
        {
            int temp;
            try
            {
                Console.WriteLine("请输入所需的订单序号:");
                temp = int.Parse(Console.ReadLine());
                if (!(temp >= 1 && temp <= num))
                {
                    Console.WriteLine("输入错误！");
                    InputTag();
                }
                return temp;
            }catch(Exception e)
            {
                Console.WriteLine("输入错误！");
                InputTag();
            }
            return 0;
        }
        public Order SearchByTag()
        {
            int tag = InputTag();
            try
            {
                return ListOfOrder[tag - 1];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("所请求的订单不存在！");
                SearchByTag();
            }
            return null;
        }
        public void DelOrderByOrderNum(int num)
        {
            Console.Write("请输入要删除的订单的订单号:");
            Order o = SearchByOrderNum(num);
            ListOfOrder.Remove(o);
            num--;
        }
        public void DelOrderByTag(int n)
        {
            ListOfOrder.Remove(ListOfOrder[n - 1]);
            num--;
        }
        public int InputChangeFlag()
        {
            int tag = 0;
            Console.WriteLine("请输入要修改的项目:1.订单号 2.用户名 3.产品名 4.产品单价 5.产品数目");
            try
            {
                tag = int.Parse(Console.ReadLine());
                if (!(tag >= 1 && tag <= 5))
                {
                    Console.WriteLine("输入错误！");
                    InputChangeFlag();
                }
                return tag;
            }catch(Exception e)
            {
                Console.WriteLine("输入错误！");
                InputChangeFlag();
            }
            return 0;
        }
        public void Change()
        {
            Order o = SearchByTag();
            int Flag = InputChangeFlag();
            switch(Flag)
            {
                case 1:
                    Console.Write("请输入订单号:");
                    string s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入订单号:");
                        s = Console.ReadLine();
                    }
                    o.OrderNum = s;
                    break;
                case 2:
                    Console.Write("请输入用户名:");
                    o.ClientName = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("请输入产品名:");
                    o.ListOfDetails[0].ProductName = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("请输入产品单价:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入产品单价:");
                        s = Console.ReadLine();
                    }
                    o.ListOfDetails[0].PriceOfProduct = int.Parse(s);
                    break;
                case 5:
                    Console.Write("请输入产品数目:");
                    s = Console.ReadLine();
                    while (CheckNum(s) != true)
                    {
                        Console.Write("请重新输入产品数目:");
                        s = Console.ReadLine();
                    }
                    o.ListOfDetails[0].NumOfProduct = int.Parse(s);
                    break;
            }
        }
        public int InputControlFlag()
        {
            int tag = 0;
            Console.WriteLine("请选择你的操作:1.添加订单 2.删除订单 3.修改订单 4.查询订单 5.显示所有订单");
            try
            {
                tag = int.Parse(Console.ReadLine());
                if(! ( tag >= 1 && tag <= 5))
                {
                    Console.WriteLine("输入错误！");
                    InputControlFlag();
                }
                return tag;
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误！");
                InputControlFlag();
            }
            return 0;
        }
        public void init()
        {
            int Flag = InputControlFlag();
            switch (Flag)
            {
                case 1:
                    AddOrder();
                    break;
                case 2:
                    ListOfOrder.Remove(Search());
                    break;
                case 3:
                    Change();
                    break;
                case 4:
                    DisplayOrder(Search());
                    break;
                case 5:
                    DisplayAll();
                    break;
            }
            init();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService o = new OrderService();
            o.init();
            Console.ReadLine();
        }
    }
}
