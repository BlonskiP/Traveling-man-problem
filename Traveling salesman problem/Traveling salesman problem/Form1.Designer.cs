using System.Windows.Forms;

namespace Traveling_salesman_problem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RunTsp_btn = new System.Windows.Forms.Button();
            this.NewMatrix_Btn = new System.Windows.Forms.Button();
            this.RunCalc_Btn = new System.Windows.Forms.Button();
            this.Method_CB = new System.Windows.Forms.ComboBox();
            this.cost_label = new System.Windows.Forms.Label();
            this.UploadFile_btn = new System.Windows.Forms.Button();
            this.ShowMatrix_btn = new System.Windows.Forms.Button();
            this.path_list = new System.Windows.Forms.ListBox();
            this.vertexCount_tb = new System.Windows.Forms.TextBox();
            this.time_lb = new System.Windows.Forms.Label();
            this.Xml_upload_btn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TemperatureBox = new System.Windows.Forms.TextBox();
            this.CoolingBox = new System.Windows.Forms.TextBox();
            this.TemperatureText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CadenceText = new System.Windows.Forms.Label();
            this.cadenceBox = new System.Windows.Forms.TextBox();
            this.bBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RunTsp_btn
            // 
            this.RunTsp_btn.Location = new System.Drawing.Point(23, 12);
            this.RunTsp_btn.Name = "RunTsp_btn";
            this.RunTsp_btn.Size = new System.Drawing.Size(101, 23);
            this.RunTsp_btn.TabIndex = 0;
            this.RunTsp_btn.Text = " Run TSP";
            this.RunTsp_btn.UseVisualStyleBackColor = true;
            this.RunTsp_btn.Click += new System.EventHandler(this.RunTsp_btn_Click);
            // 
            // NewMatrix_Btn
            // 
            this.NewMatrix_Btn.Location = new System.Drawing.Point(23, 41);
            this.NewMatrix_Btn.Name = "NewMatrix_Btn";
            this.NewMatrix_Btn.Size = new System.Drawing.Size(101, 23);
            this.NewMatrix_Btn.TabIndex = 1;
            this.NewMatrix_Btn.Text = "New Matrix";
            this.NewMatrix_Btn.UseVisualStyleBackColor = true;
            this.NewMatrix_Btn.Click += new System.EventHandler(this.NewMatrix_Btn_Click);
            // 
            // RunCalc_Btn
            // 
            this.RunCalc_Btn.Location = new System.Drawing.Point(23, 70);
            this.RunCalc_Btn.Name = "RunCalc_Btn";
            this.RunCalc_Btn.Size = new System.Drawing.Size(101, 23);
            this.RunCalc_Btn.TabIndex = 2;
            this.RunCalc_Btn.Text = "Run Calc";
            this.RunCalc_Btn.UseVisualStyleBackColor = true;
            this.RunCalc_Btn.Click += new System.EventHandler(this.RunCalc_Btn_Click);
            // 
            // Method_CB
            // 
            this.Method_CB.FormattingEnabled = true;
            this.Method_CB.Items.AddRange(new object[] {
            "Dynamic Programming",
            "Brute Force",
            "Branch and Bound"});
            this.Method_CB.Location = new System.Drawing.Point(130, 12);
            this.Method_CB.Name = "Method_CB";
            this.Method_CB.Size = new System.Drawing.Size(182, 21);
            this.Method_CB.TabIndex = 3;
            // 
            // cost_label
            // 
            this.cost_label.AutoSize = true;
            this.cost_label.Location = new System.Drawing.Point(139, 81);
            this.cost_label.Name = "cost_label";
            this.cost_label.Size = new System.Drawing.Size(31, 13);
            this.cost_label.TabIndex = 5;
            this.cost_label.Text = "Cost:";
            // 
            // UploadFile_btn
            // 
            this.UploadFile_btn.Location = new System.Drawing.Point(23, 99);
            this.UploadFile_btn.Name = "UploadFile_btn";
            this.UploadFile_btn.Size = new System.Drawing.Size(101, 23);
            this.UploadFile_btn.TabIndex = 6;
            this.UploadFile_btn.Text = "Upload txt File";
            this.UploadFile_btn.UseVisualStyleBackColor = true;
            this.UploadFile_btn.Click += new System.EventHandler(this.UploadFile_btn_Click);
            // 
            // ShowMatrix_btn
            // 
            this.ShowMatrix_btn.Location = new System.Drawing.Point(23, 157);
            this.ShowMatrix_btn.Name = "ShowMatrix_btn";
            this.ShowMatrix_btn.Size = new System.Drawing.Size(293, 23);
            this.ShowMatrix_btn.TabIndex = 7;
            this.ShowMatrix_btn.Text = "Show Matrix in console";
            this.ShowMatrix_btn.UseVisualStyleBackColor = true;
            this.ShowMatrix_btn.Click += new System.EventHandler(this.ShowMatrix_btn_Click);
            // 
            // path_list
            // 
            this.path_list.FormattingEnabled = true;
            this.path_list.Location = new System.Drawing.Point(318, 12);
            this.path_list.Name = "path_list";
            this.path_list.Size = new System.Drawing.Size(120, 134);
            this.path_list.TabIndex = 8;
            // 
            // vertexCount_tb
            // 
            this.vertexCount_tb.Location = new System.Drawing.Point(130, 41);
            this.vertexCount_tb.MaxLength = 2;
            this.vertexCount_tb.Name = "vertexCount_tb";
            this.vertexCount_tb.Size = new System.Drawing.Size(100, 20);
            this.vertexCount_tb.TabIndex = 9;
            this.vertexCount_tb.Text = "5";
            this.vertexCount_tb.TextChanged += new System.EventHandler(this.vertexCount_tb_TextChanged);
            this.vertexCount_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vertexCount_tb_KeyPressed);
            // 
            // time_lb
            // 
            this.time_lb.AutoSize = true;
            this.time_lb.Location = new System.Drawing.Point(139, 94);
            this.time_lb.Name = "time_lb";
            this.time_lb.Size = new System.Drawing.Size(52, 13);
            this.time_lb.TabIndex = 10;
            this.time_lb.Text = "Time[ms]:";
            // 
            // Xml_upload_btn
            // 
            this.Xml_upload_btn.Location = new System.Drawing.Point(23, 382);
            this.Xml_upload_btn.Name = "Xml_upload_btn";
            this.Xml_upload_btn.Size = new System.Drawing.Size(101, 23);
            this.Xml_upload_btn.TabIndex = 11;
            this.Xml_upload_btn.Text = "Upload XML file";
            this.Xml_upload_btn.UseVisualStyleBackColor = true;
            this.Xml_upload_btn.Click += new System.EventHandler(this.Xml_upload_btn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Simulated annealing",
            "Tabu"});
            this.comboBox1.Location = new System.Drawing.Point(130, 325);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Number of iterations";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 326);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TemperatureBox
            // 
            this.TemperatureBox.Location = new System.Drawing.Point(406, 278);
            this.TemperatureBox.Name = "TemperatureBox";
            this.TemperatureBox.Size = new System.Drawing.Size(100, 20);
            this.TemperatureBox.TabIndex = 17;
            this.TemperatureBox.Text = "5";
            this.TemperatureBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vertexCount_tb_KeyPressed);
            // 
            // CoolingBox
            // 
            this.CoolingBox.Location = new System.Drawing.Point(406, 312);
            this.CoolingBox.Name = "CoolingBox";
            this.CoolingBox.Size = new System.Drawing.Size(100, 20);
            this.CoolingBox.TabIndex = 18;
            this.CoolingBox.Text = "9997";
            this.CoolingBox.TextChanged += new System.EventHandler(this.CoolingBox_TextChanged);
            this.CoolingBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vertexCount_tb_KeyPressed);
            // 
            // TemperatureText
            // 
            this.TemperatureText.AutoSize = true;
            this.TemperatureText.Location = new System.Drawing.Point(333, 281);
            this.TemperatureText.Name = "TemperatureText";
            this.TemperatureText.Size = new System.Drawing.Size(67, 13);
            this.TemperatureText.TabIndex = 19;
            this.TemperatureText.Text = "Temperature";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cooling/1000";
            // 
            // CadenceText
            // 
            this.CadenceText.AutoSize = true;
            this.CadenceText.Location = new System.Drawing.Point(356, 433);
            this.CadenceText.Name = "CadenceText";
            this.CadenceText.Size = new System.Drawing.Size(50, 13);
            this.CadenceText.TabIndex = 21;
            this.CadenceText.Text = "Cadence";
            // 
            // cadenceBox
            // 
            this.cadenceBox.Location = new System.Drawing.Point(412, 430);
            this.cadenceBox.Name = "cadenceBox";
            this.cadenceBox.Size = new System.Drawing.Size(100, 20);
            this.cadenceBox.TabIndex = 22;
            this.cadenceBox.Text = "3";
            this.cadenceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vertexCount_tb_KeyPressed);
            // 
            // bBox
            // 
            this.bBox.Location = new System.Drawing.Point(409, 347);
            this.bBox.Name = "bBox";
            this.bBox.Size = new System.Drawing.Size(100, 20);
            this.bBox.TabIndex = 23;
            this.bBox.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "minTemp/10";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.tabuAndSaMeasure);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 529);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bBox);
            this.Controls.Add(this.cadenceBox);
            this.Controls.Add(this.CadenceText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TemperatureText);
            this.Controls.Add(this.CoolingBox);
            this.Controls.Add(this.TemperatureBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Xml_upload_btn);
            this.Controls.Add(this.time_lb);
            this.Controls.Add(this.vertexCount_tb);
            this.Controls.Add(this.path_list);
            this.Controls.Add(this.ShowMatrix_btn);
            this.Controls.Add(this.UploadFile_btn);
            this.Controls.Add(this.cost_label);
            this.Controls.Add(this.Method_CB);
            this.Controls.Add(this.RunCalc_Btn);
            this.Controls.Add(this.NewMatrix_Btn);
            this.Controls.Add(this.RunTsp_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunTsp_btn;
        private System.Windows.Forms.Button NewMatrix_Btn;
        private System.Windows.Forms.Button RunCalc_Btn;
        private System.Windows.Forms.ComboBox Method_CB;
        private System.Windows.Forms.Label cost_label;
        private System.Windows.Forms.Button UploadFile_btn;
        private System.Windows.Forms.Button ShowMatrix_btn;
        private System.Windows.Forms.ListBox path_list;
        private System.Windows.Forms.TextBox vertexCount_tb;
        private Label time_lb;
        private Button Xml_upload_btn;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox comboBox1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private TextBox TemperatureBox;
        private TextBox CoolingBox;
        private Label TemperatureText;
        private Label label2;
        private Label CadenceText;
        private TextBox cadenceBox;
        private TextBox bBox;
        private Label label3;
        private Button button2;
    }
}

