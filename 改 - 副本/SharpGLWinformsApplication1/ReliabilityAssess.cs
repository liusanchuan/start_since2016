using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace SharpGLWinformsApplication1
{
    public partial class ReliabilityAssess : Form
    {
        public static Decimal str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11;
        private HistoryList his = null;
        private string[] array = null;
        private string[] array1 = null;
        public ReliabilityAssess()
        {
            InitializeComponent();
            his = new HistoryList();
            InitTextBoxRemind();
        }

        void InitTextBoxRemind()
        {
            array = his.ReadLastHistory("../Debug/HistoryFile/RA_LastHistory.txt");
            array1 = his.ReadLastHistory("../Debug/HistoryFile/RA_LastHistory1.txt");
            YYDK.Text = array[0];
            AQXS.Text = array1[0];
            /*his.InitAutoCompleteCustomSource(YLZ);
            his.InitAutoCompleteCustomSource(ZDL);
            his.InitAutoCompleteCustomSource(XBL);
            his.InitAutoCompleteCustomSource(LWXW);
            his.InitAutoCompleteCustomSource(CLCS);
            his.InitAutoCompleteCustomSource(SSL);
            his.InitAutoCompleteCustomSource(CDZL);
            his.InitAutoCompleteCustomSource(DJNJ);
            his.InitAutoCompleteCustomSource(ZDLJ);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YLZ.Text = "";
            ZDL.Text = "";
            XBL.Text = "";
            LWXW.Text = "";
            CLCS.Text = "";
            SSL.Text = "";
            CLCS.Text = "";
            CDZL.Text = "";
            DJNJ.Text = "";
            ZDLJ.Text = "";
            /*YYDK.Text = "";
            AQXS.Text = "";*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JudgmentMatrix Judgmentmatrix = new JudgmentMatrix();
            Judgmentmatrix.DataChange += new JudgmentMatrix.DataChangeHandler(DataChanged);
            Judgmentmatrix.ShowDialog();
            Judgmentmatrix.Dispose();           
        }
        
        public void DataChanged(object sender, DataChangeEventArgs args)
        {
            // 更新窗体控件
            textBox1.Text = args.A;
            textBox2.Text = args.B;
            textBox3.Text = args.C;
            textBox4.Text = args.D;
            textBox5.Text = args.E;
            textBox6.Text = args.F;
            textBox7.Text = args.G;
            textBox8.Text = args.H;
            textBox9.Text = args.I;
            textBox10.Text = args.J; 
        }

        public string TextBox1Text
        {
            set { this.textBox11.Text = value; }
            get { return this.textBox11.Text; }                        
        }
        public string TextBox2Text
        {
            set { this.textBox12.Text = value; }
            get { return this.textBox12.Text; }
        }
        public string TextBox3Text
        {
            set { this.textBox13.Text = value; }
            get { return this.textBox13.Text; }
        }
        public string TextBox4Text
        {
            set { this.textBox14.Text = value; }
            get { return this.textBox14.Text; }
        }
        public string TextBox5Text
        {
            set { this.textBox15.Text = value; }
            get { return this.textBox15.Text; }
        }
        public string TextBox6Text
        {
            set { this.textBox16.Text = value; }
            get { return this.textBox16.Text; }
            }
        public string TextBox7Text
        {
            set { this.textBox17.Text = value; }
            get { return this.textBox17.Text; }
                 }
        public string TextBox8Text
        {
            set { this.textBox18.Text = value; }
            get { return this.textBox18.Text; }
        }
        public string TextBox9Text
        {
            set { this.textBox19.Text = value; }
            get { return this.textBox19.Text; }
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            IndexLimitValue Indexlimitvalue = new IndexLimitValue();
            Indexlimitvalue.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckAssessParameter())
                return;
            /*else
            {
                his.Remind(YLZ.Text.Trim());
                his.Remind(ZDL.Text.Trim());
                his.Remind(XBL.Text.Trim());
                his.Remind(LWXW.Text.Trim());
                his.Remind(CLCS.Text.Trim());
                his.Remind(SSL.Text.Trim());
                his.Remind(CDZL.Text.Trim());
                his.Remind(DJNJ.Text.Trim());
                his.Remind(ZDLJ.Text.Trim());
            }
            InitTextBoxRemind();*/
            str1 = Convert.ToDecimal(textBox1.Text);
            str2 = (Convert.ToDecimal(textBox11.Text) / Convert.ToDecimal(YLZ.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox2.Text));
            str3 = (Convert.ToDecimal(textBox12.Text) / Convert.ToDecimal(ZDL.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox3.Text));
            str4 = (Convert.ToDecimal(textBox13.Text) / Convert.ToDecimal(XBL.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox4.Text));
            str5 = (Convert.ToDecimal(textBox14.Text) / Convert.ToDecimal(LWXW.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox5.Text));
            str6= (Convert.ToDecimal(textBox15.Text) / Convert.ToDecimal(CLCS.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox6.Text));
            str7 = (Convert.ToDecimal(textBox16.Text) / Convert.ToDecimal(SSL.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox7.Text));
            str8 = (Convert.ToDecimal(textBox17.Text) / Convert.ToDecimal(CDZL.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox8.Text));
            str9 = (Convert.ToDecimal(textBox18.Text) / Convert.ToDecimal(DJNJ.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox9.Text));
            str10 = (Convert.ToDecimal(textBox19.Text) / Convert.ToDecimal(ZDLJ.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox10.Text));
            str11 =(Convert.ToDecimal(textBox11.Text) / Convert.ToDecimal(YLZ.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox2.Text) + Convert.ToDecimal(textBox12.Text) / Convert.ToDecimal(ZDL.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox3.Text) + Convert.ToDecimal(textBox13.Text) / Convert.ToDecimal(XBL.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox4.Text) + Convert.ToDecimal(textBox14.Text) / Convert.ToDecimal(LWXW.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox5.Text) + Convert.ToDecimal(textBox15.Text) / Convert.ToDecimal(CLCS.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox6.Text) + Convert.ToDecimal(textBox16.Text) / Convert.ToDecimal(SSL.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox7.Text) + Convert.ToDecimal(textBox17.Text) / Convert.ToDecimal(CDZL.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox8.Text) + Convert.ToDecimal(textBox18.Text) / Convert.ToDecimal(DJNJ.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox9.Text) + Convert.ToDecimal(textBox19.Text) / Convert.ToDecimal(ZDLJ.Text) / Convert.ToDecimal(AQXS.Text) * Convert.ToDecimal(textBox10.Text) + Convert.ToDecimal(YYDK.Text));
            ReliabilityAssessResult Reliabilityassessresult = new ReliabilityAssessResult();
            Reliabilityassessresult.ShowDialog();
            Reliabilityassessresult.Dispose();                
        }

        private bool CheckAssessParameter()
        {
            if (YLZ.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入应力值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(YLZ.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入应力值");
                    return false;
                }
            }

            if (ZDL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入振动量");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(ZDL.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入振动量");
                    return false;
                }
            }

            if (XBL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入形变量");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(XBL.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入形变量");
                    return false;
                }
            }

            if (LWXW.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入裂纹形位");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(LWXW.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入裂纹形位");
                    return false;
                }
            }

            if (CLCS.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入材料参数");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(CLCS.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入材料参数");
                    return false;
                }
            }

            if (SSL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入涂层烧蚀量");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(SSL.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入涂层烧蚀量");
                    return false;
                }
            }

            if (CDZL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入传动阻力");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(CDZL.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入传动阻力");
                    return false;
                }
            }

            if (DJNJ.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入电机扭矩");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(DJNJ.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入电机扭矩");
                    return false;
                }
            }

            if (ZDLJ.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入制动力矩");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(ZDLJ.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入制动力矩");
                    return false;
                }
            }

            if (YYDK.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入液压及电控可靠度");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(YYDK.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入液压及电控可靠度");
                    return false;
                }
            }

            if (AQXS.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入安全系数");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(AQXS.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入安全系数");
                    return false;
                }
            }

            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileStream fs = File.OpenWrite("../Debug/HistoryFile/Remind.txt");
            fs.SetLength(0);
            fs.Close();
            fs = null;
            /*his.InitAutoCompleteCustomSource(YLZ);
            his.InitAutoCompleteCustomSource(ZDL);
            his.InitAutoCompleteCustomSource(XBL);
            his.InitAutoCompleteCustomSource(LWXW);
            his.InitAutoCompleteCustomSource(CLCS);
            his.InitAutoCompleteCustomSource(SSL);
            his.InitAutoCompleteCustomSource(CDZL);
            his.InitAutoCompleteCustomSource(DJNJ);
            his.InitAutoCompleteCustomSource(ZDLJ);*/
        }

        private void ReliabilityAssess_Load(object sender, EventArgs e)
        {
            IndexLimitValue ILV = new IndexLimitValue();
            this.textBox11.Text = ILV.TextBox11Text;
            this.textBox12.Text = ILV.TextBox12Text;
            this.textBox13.Text = ILV.TextBox13Text;
            this.textBox14.Text = ILV.TextBox14Text;
            this.textBox15.Text = ILV.TextBox15Text;
            this.textBox16.Text = ILV.TextBox16Text;
            this.textBox17.Text = ILV.TextBox17Text;
            this.textBox18.Text = ILV.TextBox18Text;
            this.textBox19.Text = ILV.TextBox19Text;

            JudgmentMatrix JM = new JudgmentMatrix();
            this.textBox1.Text = JM.TextBox01Text;
            this.textBox2.Text = JM.TextBox02Text; 
            this.textBox3.Text = JM.TextBox03Text;
            this.textBox4.Text = JM.TextBox04Text;
            this.textBox5.Text = JM.TextBox05Text;
            this.textBox6.Text = JM.TextBox06Text;
            this.textBox7.Text = JM.TextBox07Text;
            this.textBox8.Text = JM.TextBox08Text;
            this.textBox9.Text = JM.TextBox09Text;
            this.textBox10.Text = JM.TextBox10Text;
        }

        private void YYDK_TextChanged(object sender, EventArgs e)
        {
            FileStream fs = File.OpenWrite("../Debug/HistoryFile/RA_LastHistory.txt");
            fs.SetLength(0);
            fs.Close();
            fs = null;
            his.ChangeLastHistory("../Debug/HistoryFile/RA_LastHistory.txt", YYDK.Text.Trim());
        }

        private void AQXS_TextChanged(object sender, EventArgs e)
        {
            FileStream fs = File.OpenWrite("../Debug/HistoryFile/RA_LastHistory1.txt");
            fs.SetLength(0);
            fs.Close();
            fs = null;
            his.ChangeLastHistory("../Debug/HistoryFile/RA_LastHistory1.txt", AQXS.Text.Trim());
        }
       
    }
}
