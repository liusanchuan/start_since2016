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
    public partial class ReliabilityAssessResult : Form
    {
        
        public ReliabilityAssessResult()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(ReliabilityAssess.str1.ToString("0.000"));
            textBox2.Text = Convert.ToString(ReliabilityAssess.str2.ToString("0.000"));
            textBox3.Text = Convert.ToString(ReliabilityAssess.str3.ToString("0.000"));
            textBox4.Text = Convert.ToString(ReliabilityAssess.str4.ToString("0.000"));
            textBox5.Text = Convert.ToString(ReliabilityAssess.str5.ToString("0.000"));
            textBox6.Text = Convert.ToString(ReliabilityAssess.str6.ToString("0.000"));
            textBox7.Text = Convert.ToString(ReliabilityAssess.str7.ToString("0.000"));
            textBox8.Text = Convert.ToString(ReliabilityAssess.str8.ToString("0.000"));
            textBox9.Text = Convert.ToString(ReliabilityAssess.str9.ToString("0.000"));
            textBox10.Text = Convert.ToString(ReliabilityAssess.str10.ToString("0.000"));
            textBox11.Text = Convert.ToString(ReliabilityAssess.str11.ToString("0.000"));

          if (Convert.ToDecimal(textBox10.Text) >= 1)
          {
                textBox12.Text ="是";

          }
          else
          {
                textBox12.Text = "否";

           } 
         }
    }
}
