using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpGLWinformsApplication1
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void 实时状态检测_Click(object sender, EventArgs e)
        {
            RealTimeMonitoring Realtimemonitoring = new RealTimeMonitoring();
            Realtimemonitoring.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReliabilityAssess Reliabilityassess = new ReliabilityAssess();
            Reliabilityassess.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FlawAssess Liewenpinggu = new FlawAssess();
            Liewenpinggu.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRearch Datasearch = new DataRearch();
            Datasearch.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataAdd Rearchresult = new DataAdd();
            Rearchresult.Show(); 
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
    }
}
