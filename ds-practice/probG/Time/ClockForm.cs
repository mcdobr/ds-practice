using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time
{
    public partial class ClockForm : Form
    {
        private Timer timer; 

        public ClockForm()
        {
            InitializeComponent();
        }

        private void ClockForm_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += ShowTime;
            timer.Start();

        }

        private void ShowTime(object sender, EventArgs e)
        {
            SystemTime sysTime = new SystemTime();
            LibWrap.GetSystemTime(sysTime);

            timeLabel.Text = string.Format("{0}:{1}:{2}",
                formatTimeNumber(sysTime.hour),
                formatTimeNumber(sysTime.minute),
                formatTimeNumber(sysTime.second)
                );
        }

        private string formatTimeNumber(ushort no)
        {
            return (no < 10) ? "0" + no : no.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SystemTime
    {
        public ushort year;
        public ushort month;
        public ushort weekday;
        public ushort day;
        public ushort hour;
        public ushort minute;
        public ushort second;
        public ushort millisecond;
    }

    public class LibWrap
    {
        // Declares a managed prototype for the unmanaged function using Platform Invoke.
        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime([In, Out] SystemTime st);
    }
}
