using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//2、使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。在闹钟走时时或者响铃时，在控制台显示提示信息。
namespace Homework4_2
{
    public delegate void Tick_Alarm_Handler(object sender, EventArgs args);
    public class ClockEvent
    {
        public event Tick_Alarm_Handler OnTick;//定义tick事件
        public event Tick_Alarm_Handler OnAlarm;//定义alarm事件

        private DateTime currenttime;
        public DateTime Curenttime
        {
            get { return currenttime; }
            set
            {
                currenttime = value;
                if (currenttime.Second == 0 || currenttime.Second == 30)  //Clock设置每整分或半分时刻alarm
                    this.OnAlarm(this, new EventArgs());
                else this.OnTick(this, new EventArgs());                  //其他时刻tick
            }
        }
        public void TimeChanged(EventArgs args)
        {
            if (OnTick != null)
                this.OnTick(this, args);
        }
    }
    public class Clock
    {
        public ClockEvent clockevent = new ClockEvent();

        public Clock()                                                  //订阅事件
        {
            clockevent.OnTick += Clock_Tick;
            clockevent.OnAlarm += Clock_Alarm;
        }

        public void Clock_Tick(object sender, EventArgs args)           //Tick处理方法
        {
            Console.WriteLine($"{clockevent.Curenttime},Tick");
        }
        public void Clock_Alarm(object sender, EventArgs args)          //Alarm处理方法
        {
            Console.WriteLine($"{clockevent.Curenttime},Alarm!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock1 = new Homework4_2.Clock();
            while (true)
            { 
                clock1.clockevent.Curenttime = DateTime.Now;
                System.Threading.Thread.Sleep(1000);
            }


        }
    }
}
