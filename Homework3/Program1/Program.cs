using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入所需要的图形：");
            Console.WriteLine("1.三角形");
            Console.WriteLine("2.圆形");
            Console.WriteLine("3.正方形");
            Console.WriteLine("4.长方形");

            string str = Console.ReadLine();
            int x = int.Parse(str);

            switch (x)
            {
                case 1:
                    Console.WriteLine("请输入三条边的长度：");
                    Triangle t = new Triangle();
                    str = Console.ReadLine();
                    t.Length1 = int.Parse(str);
                    str = Console.ReadLine();
                    t.Length2 = int.Parse(str);
                    str = Console.ReadLine();
                    t.Length3 = int.Parse(str);
                    t.OutputArea();
                    break;
                case 2:
                    Console.WriteLine("请输入圆的半径：");
                    Circle c = new Circle();
                    str = Console.ReadLine();
                    c.Length1 = int.Parse(str);
                    c.OutputArea();
                    break;
                case 3:
                    Console.WriteLine("请输入正方形的边长：");
                    Square s = new Square();
                    str = Console.ReadLine();
                    s.Length1 = int.Parse(str);
                    s.OutputArea();
                    break;
                case 4:
                    Console.WriteLine("请输入正方形的边长：");
                    Rectangle r = new Rectangle();
                    str = Console.ReadLine();
                    r.Length1 = int.Parse(str);
                    str = Console.ReadLine();
                    r.Length2 = int.Parse(str);
                    r.OutputArea();
                    break;
                default:
                    Console.WriteLine("您的输入错误。");
                    break;
            }

            Console.ReadLine();
        }
    }
    class Graph
    {
        public double Length1           // 三角形正方形的边长或是圆的半径
        {
            set;
            get;
        }
        protected double Area;
        protected virtual void Calculate()
        {

        }
        public virtual void OutputArea()
        {
            Calculate();
            Console.WriteLine("The area of the graph is " + Area + ".");
        }
    }

    class Triangle : Graph
    {
        public double Length2
        {
            set;
            get;
        }
        public double Length3
        {
            set;
            get;
        }
        protected override void Calculate()
        {
            double p = (Length1 + Length2 + Length3) / 2;
            Area = Math.Sqrt(p * (p - Length1) * (p - Length2) * (p - Length3));
        }
        public override void OutputArea()
        {
            Calculate();
            Console.WriteLine("The area of the triangle is " + Area + ".");
        }
    }

    class Circle : Graph
    {
        protected override void Calculate()
        {
            Area = Math.PI * Length1 * Length1;
        }
        public override void OutputArea()
        {
            Calculate();
            Console.WriteLine("The area of the circle is " + Area + ".");
        }
    }

    class Square : Graph
    {
        protected override void Calculate()
        {
            Area = Length1 * Length1;
        }
        public override void OutputArea()
        {
            Calculate();
            Console.WriteLine("The area of the square is " + Area + ".");
        }
    }

    class Rectangle : Graph
    {
        public double Length2
        {
            set;
            get;
        }
        protected override void Calculate()
        {
            Area = Length1 * Length2;
        }
        public override void OutputArea()
        {
            Calculate();
            Console.WriteLine("The area of the rectangle is " + Area + ".");
        }
    }
}
