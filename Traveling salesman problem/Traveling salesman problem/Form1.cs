using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traveling_salesman_problem
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Method_CB.SelectedIndex = 0;

        }

        private void RunTsp_btn_Click(object sender, EventArgs e)
        {
            if (!Manager.isSolving)
            {
                path_list.Items.Clear();
                if (Manager._matrix == null)
                    Manager.MatrixGenerator(Int32.Parse(vertexCount_tb.Text));
                if (vertexCount_tb.Text.Length != 0 && Method_CB.SelectedIndex != -1)
                {
                    switch (Method_CB.SelectedIndex)
                    {
                        case 0:
                        {

                            Manager.RunDynamic();
                            break;
                        }
                        case 1:
                        {
                            Manager.RunBruteForce();
                            break;
                        }
                        case 2:
                        {//TO DO
                            break;
                        }


                    }

                    time_lb.Text = "Time[ms]:" + Manager.timeCounter.Elapsed;
                    cost_label.Text = "cost:" + Manager.cost.ToString();
                    foreach (var vertex in Manager.path)
                    {
                        path_list.Items.Add(vertex);
                    }

                    Manager._matrix.print();
                    Console.WriteLine("");
                }
            }
        }

        private void Method_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewMatrix_Btn_Click(object sender, EventArgs e)
        {
            if(vertexCount_tb.Text.Length>0)
            {
                Manager.MatrixGenerator(Int32.Parse(vertexCount_tb.Text));
            }
        }

        private void RunCalc_Btn_Click(object sender, EventArgs e)
        {

        }

        private void UploadFile_btn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMatrix_btn_Click(object sender, EventArgs e)
        {
            if(Manager._matrix!=null)
            {
                Manager._matrix.print();
            }
        }

        private void vertexCount_tb_TextChanged(object sender, EventArgs e)
        {

        }
        private void vertexCount_tb_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) )
            {
                e.Handled = true;
            }
            
            
        }
    }
}
