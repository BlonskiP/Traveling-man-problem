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
            this.Method_CB.SelectedIndexChanged += new System.EventHandler(this.Method_CB_SelectedIndexChanged);
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
            this.UploadFile_btn.Text = "Upload File";
            this.UploadFile_btn.UseVisualStyleBackColor = true;
            this.UploadFile_btn.Click += new System.EventHandler(this.UploadFile_btn_Click);
            // 
            // ShowMatrix_btn
            // 
            this.ShowMatrix_btn.Location = new System.Drawing.Point(23, 129);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 164);
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
    }
}

