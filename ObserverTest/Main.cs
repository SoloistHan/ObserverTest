using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ObserverTest.InterfaceWay;

namespace ObserverTest
{
    public partial class Main : Form
    {
        double targetTemp = 10;
        public Main()
        {
            InitializeComponent();
           
        }

        private void buttonOBinterface_Click(object sender, EventArgs e)
        {
            TempatureMonitorSubject mainOB = new TempatureMonitorSubject();
            MobileApp mobileApp = new MobileApp();
            DesktopApp desktopApp = new DesktopApp();
            mainOB.RegisterObserver(mobileApp);
            mainOB.RegisterObserver(desktopApp);

            richTextBox1.Clear();
            targetTemp += 1.1;
            mainOB.Tempature = targetTemp;
            richTextBox1.AppendText(mobileApp.OnTempatureChanged(targetTemp) + "\r");
            richTextBox1.AppendText(desktopApp.OnTempatureChanged(targetTemp) + "\r");
        }
    }
}
