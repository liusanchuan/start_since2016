﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SharpGLWinformsApplication1
{
    public partial class DataRearch : Form
    {
        private string ConnectionString = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
        private SqlConnection conn = null;
        //private SqlCommand cmd = null;
        private string sql = null;
        private DataSet ds = null;
        private SqlDataAdapter da = null;

        public DataRearch()
        {
            InitializeComponent();
        }

        private void DataRearch_Load(object sender, EventArgs e)
        {
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Increment = 0.1M;
            numericUpDown2.DecimalPlaces = 1;
            numericUpDown2.Increment = 0.1M;
           
            //ConnectionString = "Data Source=MS-20160121SCPS;Initial Catalog=PlatformFlawBase;"
                 //+ "Persist Security Info=True;User ID=sa;Password=zf19891014";
            ds = new DataSet();
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            sql = "SELECT * FROM LData";
            // 创建数据适配器
            da = new SqlDataAdapter(sql, conn);
            // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
           

           int i, j;
           i = 0;
           j = 3;
           for (i = 0; i < dataGridView1.RowCount - 1 ; i++)
           {
               
               for (j = 3; j < 23; j++)
               {
                   if (j >= 3 && j <= 12)
                   {
                       string str = dataGridView1.Rows[i].Cells[j].Value.ToString();
                       if (Convert.ToDouble(str) > 20)
                           dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                   }
                   if (j >= 13 && j <= 23)
                   {
                       string str = dataGridView1.Rows[i].Cells[j].Value.ToString();
                       if (Convert.ToDouble(str) > 10)
                           dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Blue;
                   }
               }
           }



        }

        //查找数据
        private void button1_Click(object sender, EventArgs e)
        {
           //ConnectionString = "Data Source=MS-20160121SCPS;Initial Catalog=PlatformFlawBase;"
           //     + "Persist Security Info=True;User ID=sa;Password=zf19891014";
            try
            {
                ds = new DataSet();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                sql = "SELECT * FROM LData ";
                string condition = "";

                if (dateTimePicker1.Text != "" && dateTimePicker2.Text != "")
                {
                    condition = " LaunchTime BETWEEN " +"'"+ dateTimePicker1.Value.Date.ToString("yyyy/MM/dd")+ "'" + "AND" +"'"+ dateTimePicker2.Value.Date.ToString("yyyy/MM/dd")+ "'";
                }

                if (numericUpDown2.Value != 0)
                {
                    if (condition.Length > 0)
                    {
                        condition += " AND AssessedValue BETWEEN " + numericUpDown1.Value + " AND " + numericUpDown2.Value;
                    }
                    else
                    {
                        condition = " AssessedValue BETWEEN " + numericUpDown1.Value + " AND " + numericUpDown2.Value;
                    }
                }

              if (comboBox1.Text != "" )
                {
                    if (condition.Length > 0)
                    {

                        condition += " AND YesOrNo = " + "'" + comboBox1.Text + "'";
                    }
                    else
                    {
                        condition = " YesOrNo = " + "'" + comboBox1.Text + "'";
                    }
                }
 
                if (condition != "")
                    sql += " where " + condition;
                
                da = new SqlDataAdapter(sql, conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();
                
                int i, j;
                i = 0;
                j = 3;
                for (i = 0; i < dataGridView1.RowCount - 1; i++)
                {

                    for (j = 3; j < 23; j++)
                    {
                        if (j >= 3 && j <= 12)
                        {
                            string str = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            if (Convert.ToDouble(str) > 20)
                                dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                        if (j >= 13 && j <= 23)
                        {
                            string str = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            if (Convert.ToDouble(str) > 10)
                                dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Blue;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("查找数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Rwrite_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
           
            int m;
            for (m = 3; m < 23; m++)
            {
                dataGridView1.Columns[m].Visible = true;
            }
            //ConnectionString = "Data Source=MS-20160121SCPS;Initial Catalog=PlatformFlawBase;"
            //                + "Persist Security Info=True;User ID=sa;Password=zf19891014";
            
            ds = new DataSet();
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            sql = "SELECT * FROM LData";
            // 创建数据适配器
            da = new SqlDataAdapter(sql, conn);
            // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
           
            int i, j;
            i = 0;
            j = 3;
            for (i = 0; i < dataGridView1.RowCount - 1; i++)
            {

                for (j = 3; j < 23; j++)
                {
                    if (j >= 3 && j <= 12)
                    {
                        string str = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        if (Convert.ToDouble(str) > 20)
                            dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                    }
                    if (j >= 13 && j <= 23)
                    {
                        string str = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        if (Convert.ToDouble(str) > 10)
                            dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 3; i < 23; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            
            string mystr = comboBox2.Text;
            if (mystr=="测点01")
            {
             dataGridView1.Columns[3].Visible =true;
             dataGridView1.Columns[13].Visible = true;
            }
            if (mystr == "测点02")
            {
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[14].Visible = true;
            }
            if (mystr == "测点03")
            {
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[15].Visible = true;
            }
            if (mystr == "测点04")
            {
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.Columns[16].Visible = true;
            }
            if (mystr == "测点05")
            {
                dataGridView1.Columns[7].Visible = true;
                dataGridView1.Columns[17].Visible = true;
            }
            if (mystr == "测点06")
            {
                dataGridView1.Columns[8].Visible = true;
                dataGridView1.Columns[18].Visible = true;
            }
            if (mystr == "测点07")
            {
                dataGridView1.Columns[9].Visible = true;
                dataGridView1.Columns[19].Visible = true;
            }
            if (mystr == "测点08")
            {
                dataGridView1.Columns[10].Visible = true;
                dataGridView1.Columns[20].Visible = true;
            }
            if (mystr == "测点09")
            {
                dataGridView1.Columns[11].Visible = true;
                dataGridView1.Columns[21].Visible = true;
            }
            if (mystr == "测点10")
            {
                dataGridView1.Columns[12].Visible = true;
                dataGridView1.Columns[22].Visible = true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
    }


      
    
}
