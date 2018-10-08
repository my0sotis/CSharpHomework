using System;

namespace Program1
{
    public class ClockEventArgs:EventArgs
    {
        public TimeSpan span;
    }

    public delegate void ClockEventHandler(object sender, ClockEventArgs e);

    public class Clock
    {
        public event ClockEventHandler Alarm;
        public int AlarmHour;
        public int AlarmMinute;
        public int AlarmSecond;
        DateTime AlarmTime = new DateTime();
        DateTime CurrentTime = new DateTime();

        public void SetAlarm()
        {
            Console.WriteLine("开始设定闹钟。");
            SetHour();
            SetMinute();
            SetSecond();
            AlarmTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, AlarmHour, AlarmMinute, AlarmSecond);
        }
        public void SetHour()
        {
            Console.Write("输入时：");
            AlarmHour = int.Parse(Console.ReadLine());
            if(!(AlarmHour>=0&&AlarmHour<=23))
            {
                Console.Write("输入错误，请重新");
                AlarmHour = 0;
            }
        }
        public void SetMinute()
        {
            Console.Write("输入分：");
            AlarmMinute = int.Parse(Console.ReadLine());
            if (!(AlarmMinute >= 0 && AlarmMinute <= 59))
            {
                Console.Write("输入错误，请重新");
                AlarmMinute = 0;
            }
        }
        public void SetSecond()
        {
            Console.Write("请输入秒：");
            AlarmSecond = int.Parse(Console.ReadLine());
            if (!(AlarmSecond >= 0 && AlarmSecond <= 59))
            {
                Console.Write("输入错误，请重新");
                AlarmSecond = 0;
            }
        }
        public void StartAlarm()
        {
            SetAlarm();
            CurrentTime = DateTime.Now;
            ClockEventArgs args = new ClockEventArgs();
            args.span = AlarmTime - CurrentTime;
            Alarm(this, args);
            while (CurrentTime<AlarmTime)
            {
                System.Threading.Thread.Sleep(500);
                CurrentTime = DateTime.Now;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var clock = new Clock();
            clock.Alarm += ShowSpan;
            clock.StartAlarm();
            clock.StartAlarm();

            Console.ReadLine();
        }
        static void ShowSpan(object sender, ClockEventArgs e)
        {
            Console.WriteLine($"还剩{e.span}");
        }
    }
}
