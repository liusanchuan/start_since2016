using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace SharpGLWinformsApplication1
{
    public partial class JudgmentMatrix : Form
    {
        // 定义委托
        // public delegate void DataChangeHandler(string x); 一次可以传递一个string
        public delegate void DataChangeHandler(object sender, DataChangeEventArgs args);
        // 声明事件
        public event DataChangeHandler DataChange;

        // 调用事件函数
        public void OnDataChange(object sender, DataChangeEventArgs args)
        {
            if (DataChange != null)
            {
                DataChange(this, args);
            }
        }
        private HistoryList his = null;
        private string[] array = null;
        public JudgmentMatrix()
        {
            InitializeComponent();
            his = new HistoryList();
            InitTextBoxRemind();
        }

        public string TextBox01Text
        {
            set { this.textBox10.Text = value; }
            get { return this.textBox10.Text; }
        }
        public string TextBox02Text
        {
            set { this.textBox41.Text = value; }
            get { return this.textBox41.Text; }
        }
        public string TextBox03Text
        {
            set { this.textBox42.Text = value; }
            get { return this.textBox42.Text; }
        }
        public string TextBox04Text
        {
            set { this.textBox43.Text = value; }
            get { return this.textBox43.Text; }
        }
        public string TextBox05Text
        {
            set { this.textBox44.Text = value; }
            get { return this.textBox44.Text; }
        }
        public string TextBox06Text
        {
            set { this.textBox45.Text = value; }
            get { return this.textBox45.Text; }
        }
        public string TextBox07Text
        {
            set { this.textBox46.Text = value; }
            get { return this.textBox46.Text; }
        }
        public string TextBox08Text
        {
            set { this.textBox47.Text = value; }
            get { return this.textBox47.Text; }
        }
        public string TextBox09Text
        {
            set { this.textBox48.Text = value; }
            get { return this.textBox48.Text; }
        }
        public string TextBox10Text
        {
            set { this.textBox49.Text = value; }
            get { return this.textBox49.Text; }
        }

        void InitTextBoxRemind()
        {
            array = his.ReadLastHistory("../Debug/HistoryFile/JM_LastHistory.txt");
            textBox10.Text = array[0];
            textBox41.Text = array[1];
            textBox42.Text = array[2];
            textBox43.Text = array[3];
            textBox44.Text = array[4];
            textBox45.Text = array[5];
            textBox46.Text = array[6];
            textBox47.Text = array[7];
            textBox48.Text = array[8];
            textBox49.Text = array[9];
            array = his.ReadLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt");
            textBox2.Text = array[0];
            textBox3.Text = array[1];
            textBox6.Text = array[2];
            textBox11.Text = array[3];
            textBox13.Text = array[4];
            textBox16.Text = array[5];
            textBox21.Text = array[6];
            textBox24.Text = array[7];
            textBox26.Text = array[8];
            textBox29.Text = array[9];
            textBox35.Text = array[10];
            textBox39.Text = array[11];
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Name == "节点1")
                {
                    tabControl1.SelectedTab = tabPage1;
                }
                else if (e.Node.Name == "节点2")
                {
                    tabControl1.SelectedTab = tabPage2;
                }
                else if (e.Node.Name == "节点3")
                {
                    tabControl1.SelectedTab = tabPage3;
                }
                else if (e.Node.Name == "节点4")
                {
                    tabControl1.SelectedTab = tabPage4;
                }
                else if (e.Node.Name == "节点5")
                {
                    tabControl1.SelectedTab = tabPage5;
                }
                else if (e.Node.Name == "节点6")
                {
                    tabControl1.SelectedTab = tabPage6;
                }
            }

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox2, this.textBox4);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox3, this.textBox7);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox6, this.textBox8);
        }



        private void button1_Click(object sender, EventArgs e)

        {

      
            FileStream fs = File.OpenWrite("../Debug/HistoryFile/JM1_LastHistory.txt");
            fs.SetLength(0);
            fs.Close();
            fs = null;
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox2.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox3.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox6.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox11.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox13.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox16.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox21.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox24.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox26.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox29.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox35.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBox39.Text.Trim());
            if (!CheckMatrix())
                return;
            //计算A层判断矩阵
            double[][] a = new double[3][];
            a[0] = new double[] { 1, double.Parse(textBox2.Text.Trim()), double.Parse(textBox3.Text.Trim()) };
            a[1] = new double[] { double.Parse(textBox4.Text.Trim()), 1, double.Parse(textBox6.Text.Trim()) };
            a[2] = new double[] { double.Parse(textBox7.Text.Trim()), double.Parse(textBox8.Text.Trim()), 1 };

            double[] q = normalize(a);//求特征向量
            textBox10.Text = Convert.ToDouble(q[2]).ToString("0.000");

            //计算B1层判断矩阵
            double[][] b = new double[3][];
            b[0] = new double[] { 1, double.Parse(textBox11.Text.Trim()), double.Parse(textBox13.Text.Trim()) };
            b[1] = new double[] { double.Parse(textBox14.Text.Trim()), 1, double.Parse(textBox16.Text.Trim()) };
            b[2] = new double[] { double.Parse(textBox18.Text.Trim()), double.Parse(textBox19.Text.Trim()), 1 };

            double[] w = normalize(b);//求特征向量
            textBox43.Text = Convert.ToDouble(q[0] * w[1]).ToString("0.000");

            //计算C1层判断矩阵
            double[][] c = new double[2][];
            c[0] = new double[] { 1, double.Parse(textBox21.Text.Trim()) };
            c[1] = new double[] { double.Parse(textBox22.Text.Trim()), 1 };
            double[] r = normal(c);//求特征向量
            textBox41.Text = Convert.ToDouble(q[0] * w[0] * r[0]).ToString("0.000");
            textBox42.Text = Convert.ToDouble(q[0] * w[0] * r[1]).ToString("0.000");

            //计算C3层判断矩阵
            double[][] d = new double[3][];
            d[0] = new double[] { 1, double.Parse(textBox24.Text.Trim()), double.Parse(textBox26.Text.Trim()) };
            d[1] = new double[] { double.Parse(textBox27.Text.Trim()), 1, double.Parse(textBox29.Text.Trim()) };
            d[2] = new double[] { double.Parse(textBox31.Text.Trim()), double.Parse(textBox32.Text.Trim()), 1 };
            double[] t = normalize(d);//求特征向量
            textBox44.Text = Convert.ToDouble(q[0] * w[2] * t[0]).ToString("0.000");
            textBox45.Text = Convert.ToDouble(q[0] * w[2] * t[1]).ToString("0.000");
            textBox46.Text = Convert.ToDouble(q[0] * w[2] * t[2]).ToString("0.000");

            //计算B2层判断矩阵
            double[][] f = new double[2][];
            f[0] = new double[] { 1, double.Parse(textBox35.Text.Trim()) };
            f[1] = new double[] { double.Parse(textBox34.Text.Trim()), 1 };
            double[] y = normal(f);//求特征向量
            textBox49.Text = Convert.ToDouble(q[1] * y[1]).ToString("0.000");

            //计算C4层判断矩阵
            double[][] g = new double[2][];
            g[0] = new double[] { 1, double.Parse(textBox35.Text.Trim()) };
            g[1] = new double[] { double.Parse(textBox34.Text.Trim()), 1 };
            double[] u = normal(g);//求特征向量
            textBox47.Text = Convert.ToDouble(q[1] * y[0] * u[0]).ToString("0.000");
            textBox48.Text = Convert.ToDouble(q[1] * y[0] * u[1]).ToString("0.000");
           

        }

        private bool CheckMatrix()
        {
            if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查A层判断矩阵");
                return false;
            }
            if (textBox11.Text.Trim().Length == 0 || textBox13.Text.Trim().Length == 0 || textBox16.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查B1层判断矩阵");
                return false;
            }
            if (textBox21.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C1层判断矩阵");
                return false;
            }
            if (textBox24.Text.Trim().Length == 0 || textBox26.Text.Trim().Length == 0 || textBox29.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C3层判断矩阵");
                return false;
            }
            if (textBox35.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查B2层判断矩阵");
                return false;
            }
            if (textBox39.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C4层判断矩阵");
                return false;
            }
            return true;
        }

        private double[] normalize(double[][] m)
        {

            int row = m.Length;
            int column = m[2].Length;
            double[] Sum_column = new double[column];
            double[] w = new double[row];

            for (int i = 0; i < column; i++)
            {
                Sum_column[i] = 0;
                for (int j = 0; j < row; j++)
                {
                    Sum_column[i] += m[j][i];
                }
            }
            //进行归一化,计算特征向量W

            for (int i = 0; i < row; i++)
            {
                w[i] = 0;
                for (int j = 0; j < column; j++)
                {
                    w[i] += m[i][j] / Sum_column[j];
                }
                w[i] /= row;
            }
            return w;
        }
        private double[] normal(double[][] n)
        {

            int row = n.Length;
            int column = n[1].Length;
            double[] Sum_column = new double[column];
            double[] w = new double[row];

            for (int i = 0; i < column; i++)
            {
                Sum_column[i] = 0;
                for (int j = 0; j < row; j++)
                {
                    Sum_column[i] += n[j][i];
                }
            }
            //进行归一化,计算特征向量W

            for (int i = 0; i < row; i++)
            {
                w[i] = 0;
                for (int j = 0; j < column; j++)
                {
                    w[i] += n[i][j] / Sum_column[j];
                }
                w[i] /= row;
            }
            return w;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox11, this.textBox14);
        }



        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {
            check_Num(this.textBox13, this.textBox18);
        }



        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox16, this.textBox19);
        }



        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox21, this.textBox22);
        }
       
        //矩阵textbox限制输入  
        private void check_Num(TextBox inputText, TextBox outputText)
        {
            string pattern = @"^[0-9]*$";
            string param1 = null;
            Match m = Regex.Match(inputText.Text, pattern);   // 匹配正则表达式
            if (!m.Success || string.IsNullOrEmpty(inputText.Text))   // 输入的不是数字
            {
                inputText.Text = "";   // textBox内容不变

                // 将光标定位到文本框的最后
                inputText.SelectionStart = inputText.Text.Length;
            }
            else   // 输入的是数字
            {

                if (Convert.ToDecimal(inputText.Text) >= 1 && Convert.ToDecimal(inputText.Text) <= 9 )
                {
                    param1 = inputText.Text;   // 将现在textBox的值保存下来
                    outputText.Text = (1.0 / Convert.ToDouble(inputText.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("请输入1到9之间的整数！");
                    inputText.Text = "";
                }
            }
        }
        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox24, this.textBox27);
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox26, this.textBox31);
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox29, this.textBox32);
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox35, this.textBox34);
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBox39, this.textBox38);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs(textBox10.Text, textBox41.Text, textBox42.Text, textBox43.Text, textBox44.Text, textBox45.Text, textBox46.Text, textBox47.Text, textBox48.Text, textBox49.Text));
            FileStream fs = File.OpenWrite("../Debug/HistoryFile/JM_LastHistory.txt");
            fs.SetLength(0);
            fs.Close();
            fs = null;
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox10.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox41.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox42.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox43.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox44.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox45.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox46.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox47.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox48.Text.Trim());
            his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox49.Text.Trim());
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void JudgmentMatrix_Load(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// 自定义事件参数类型，根据需要可设定多种参数便于传递
    /// </summary>
    public class DataChangeEventArgs : EventArgs
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; } 
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
        public string G { get; set; }
        public string I { get; set; }
        public string J { get; set; }
        public string H { get; set; }
        
        public DataChangeEventArgs(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10)
        {
            A = s1;
            B = s2;
            C = s3;
            D = s4;
            E = s5;
            F = s6;
            G = s7;
            H = s8;
            I = s9;
            J = s10;

        }
    }

}
