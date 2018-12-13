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
        private string fileName;
        private OpenFileDialog ofd=new OpenFileDialog();
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
                        {   Manager.RunBranchBound();
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

        

        private void NewMatrix_Btn_Click(object sender, EventArgs e)
        {
            if(vertexCount_tb.Text.Length>0)
            {
                Manager.MatrixGenerator(Int32.Parse(vertexCount_tb.Text));
            }
        }

        private void RunCalc_Btn_Click(object sender, EventArgs e)
        {
            Manager.runMeasures();
        }

        private void UploadFile_btn_Click(object sender, EventArgs e)
        {
            ofd.Filter = "txt| *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
            }

            Manager.CreateMatrixFromFile(fileName);

        }

        private void ShowMatrix_btn_Click(object sender, EventArgs e)
        {
            if(Manager._matrix!=null)
            {
                Manager._matrix.print();
                Console.WriteLine("");
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

        private void Xml_upload_btn_Click(object sender, EventArgs e)
        {
            ofd.Filter = "xml| *.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
            }

            Manager.CreateMatrixFromXMLFile(fileName);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Manager.isSolving)
            {
                path_list.Items.Clear();
                if (Manager._matrix == null)
                    Manager.MatrixGenerator(Int32.Parse(vertexCount_tb.Text));
                if (TemperatureBox.Text.Length != 0 && comboBox1.SelectedIndex != -1 && CoolingBox.Text.Length !=0 && cadenceBox.Text.Length!=0)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            {

                                Manager.RunSimulatedAnnealing(Int32.Parse(TemperatureBox.Text),  float.Parse(CoolingBox.Text), Int32.Parse(textBox1.Text),float.Parse(bBox.Text));
                                break;
                            }
                        case 1:
                            {
                                Manager.RunTabu(Int32.Parse(cadenceBox.Text), Int32.Parse(textBox1.Text), neigBox.Text, diversificationBox.Checked);
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

        private void tabuAndSaMeasure(object sender, EventArgs e) // run measur
        {
            Manager.runMeasuresTsSA();
        }

        private void CoolingBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
