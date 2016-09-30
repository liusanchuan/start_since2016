using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpGLWinformsApplication1
{
    public partial class MyMainPage : Form
    {
        int[,] Position = new int[,]{
                {0,70},
                {130,-85},
                {-65,-150},
                {135,165}
                
            };
        int[] pencolor=new int[]{0,0,0,0};
        public MyMainPage()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(str);
            string sqlqury = "select S1,S2,S3 from SanChuan;";
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sqlqury, conn);
            DataSet ds = new DataSet();   //dataset相当于临时的数据库，里面可以存放很多的table，
            sdr.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;    //默认存放于table【0】中
            //button1.Text = Convert.ToString(da[0]);     //显示类型转换，
            Double[] series1 = new Double[100];
            int[] X = new int[100];
            for (int i = 0; i < 100; i++)
            {
                DataRow da = ds.Tables[0].Rows[i];          //可以按照行row[0],列colum[0],第二列第一行colum[2][1]来取，所取得为一个datarow数组，然后再取此数组中的某一行            
                series1[i] = Convert.ToDouble(da[0]);

                X[i] = i;
            }
            //chart1.ChartAreas[0].AxisY.Minimum = 28.35;
            chart1.ChartAreas[0].AxisX.Maximum = 30;

            chart1.Series[0].Points.DataBindXY(X, series1);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] linX ={
                             new Point(0,225),
                             new Point(450,225)
                         };
            Point[] LinY ={
                             new Point(225,0),
                             new Point(225,450)
                         };
            Pen P = new Pen(Color.Red, 3);
            g.DrawLine(Pens.Red, linX[0], linX[1]);
            g.DrawLine(Pens.Red, LinY[0], LinY[1]);

            for (int x = 0; x < 50; x++)
            {
                g.DrawLine(Pens.Red, new Point(225, x* 10), new Point(220, x * 10));
                g.DrawLine(Pens.Red, new Point( x * 10,225), new Point(x * 10,220));

            }
                //Rectangle ellipseRec=new Rectangle(-5,-5,5,5);

                //g.DrawEllipse(P, ellipseRec);
                //Random random=new Random();
                draw_4_circle(g);
        }
        private void draw_4_circle(Graphics g)
        {
            for (int i = 0; i < 4; i++)
            {
                DrawCircle(g, Position[i, 0], Position[i, 1], Convert.ToString(i + 1), pencolor[i]);
            }
        }
        private void DrawCircle(Graphics g, int x, int y,string s,int pencolor)
        {
            x+=225;
            y=-y+225;
            g.TranslateTransform(x, y);
            Pen IPen = new Pen(Color.Blue, 3);
            if (pencolor == 0)
            {
                IPen.Color = Color.Blue;
                g.DrawEllipse(IPen, -20, -20, 20, 20);
                //pictureBox1.Refresh();
                g.DrawString(s, new Font("微软雅黑", 18), Brushes.Blue, 0, -20);

            }
            else
            {
                IPen.Color = Color.Red;

                g.DrawEllipse(IPen, -25, -25, 25, 25);
                //pictureBox1.Refresh();
                g.DrawString(s, new Font("微软雅黑", 18), Brushes.Red, 0, -20);
            }

            //pictureBox1.Refresh();
            g.ResetTransform();
        }

        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MyMainPage_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Liewen");
            dt.Columns.Add("ID");
            dt.Columns.Add("X(坐标)");
            dt.Columns.Add("Y(坐标)");
            int i = 0;
            for (; i <4;i++)
            {
                DataRow dr1 = dt.NewRow();
                dr1[0] = 1+i;
                dr1[1] = Position[i, 0];
                dr1[2] = Position[i, 1];
                dt.Rows.Add(dr1);
            }
            //for (int i = 0; i < 4; i++)
            //{

            //    dr1[0] = i+1;
            //    dr1[1] = Position[i, 0];
            //    dr1[2] = Position[i, 1];
            //    dt.Rows.Add(dr1);
            //}
            dataGridView2.DataSource = dt.DefaultView;
            //dataGridView2.Refresh();

            string str = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(str);
            string sqlqury = "select S1,S2,S3 from SanChuan;";
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sqlqury, conn);
            DataSet ds = new DataSet();   //dataset相当于临时的数据库，里面可以存放很多的table，
            sdr.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;    //默认存放于table【0】中
            //button1.Text = Convert.ToString(da[0]);     //显示类型转换，
            Double[] series1 = new Double[100];
            int[] X = new int[100];
            for (int F = 0; F < 100; F++)
            {
                DataRow da = ds.Tables[0].Rows[F];          //可以按照行row[0],列colum[0],第二列第一行colum[2][1]来取，所取得为一个datarow数组，然后再取此数组中的某一行            
                series1[F] = Convert.ToDouble(da[0]);

                X[F] = F;
            }
            //chart1.ChartAreas[0].AxisY.Minimum = 28.35;
            chart1.ChartAreas[0].AxisX.Maximum = 30;

            chart1.Series[0].Points.DataBindXY(X, series1);
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            object i=dataGridView2.CurrentCell.Value;
            object j = dataGridView2.CurrentRow.Cells["ID"].Value;  //获取当前行的ID值

            label1.Text = Convert.ToString(j);
            int id = Convert.ToInt32(j)-1;
            for (int c = 0; c < 4; c++)
            {
                if (c == id)
                {
                    pencolor[c] = 1;
                }
                else
                {
                    pencolor[c] = 0;
                }
            }
            pictureBox1.Refresh();
            //Label la=new Label();
            //la.Text=Convert.ToString(i);
            //la.Show();
        }
    }
}

