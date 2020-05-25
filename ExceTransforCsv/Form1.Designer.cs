namespace ExceTransforCsv
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.btnCsvToCsv = new System.Windows.Forms.Button();
            this.btnchosecsv = new System.Windows.Forms.Button();
            this.tbcsvpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnTransform = new System.Windows.Forms.Button();
            this.btnCsv = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(114, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "注意：转换之前请务必将原表关闭";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(162, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "转换小工具";
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportCsv.ForeColor = System.Drawing.Color.Black;
            this.btnExportCsv.Location = new System.Drawing.Point(300, 256);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(75, 23);
            this.btnExportCsv.TabIndex = 21;
            this.btnExportCsv.Text = "导出CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            // 
            // btnCsvToCsv
            // 
            this.btnCsvToCsv.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCsvToCsv.ForeColor = System.Drawing.Color.Black;
            this.btnCsvToCsv.Location = new System.Drawing.Point(139, 256);
            this.btnCsvToCsv.Name = "btnCsvToCsv";
            this.btnCsvToCsv.Size = new System.Drawing.Size(138, 23);
            this.btnCsvToCsv.TabIndex = 20;
            this.btnCsvToCsv.Text = "Csv数据转换Csv";
            this.btnCsvToCsv.UseVisualStyleBackColor = true;
            // 
            // btnchosecsv
            // 
            this.btnchosecsv.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnchosecsv.ForeColor = System.Drawing.Color.Black;
            this.btnchosecsv.Location = new System.Drawing.Point(41, 256);
            this.btnchosecsv.Name = "btnchosecsv";
            this.btnchosecsv.Size = new System.Drawing.Size(75, 23);
            this.btnchosecsv.TabIndex = 19;
            this.btnchosecsv.Text = "选择csv";
            this.btnchosecsv.UseVisualStyleBackColor = true;
            // 
            // tbcsvpath
            // 
            this.tbcsvpath.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbcsvpath.ForeColor = System.Drawing.Color.Black;
            this.tbcsvpath.Location = new System.Drawing.Point(117, 195);
            this.tbcsvpath.Name = "tbcsvpath";
            this.tbcsvpath.Size = new System.Drawing.Size(274, 22);
            this.tbcsvpath.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(40, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "导入CSV：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnTransform
            // 
            this.btnTransform.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTransform.ForeColor = System.Drawing.Color.Black;
            this.btnTransform.Location = new System.Drawing.Point(139, 118);
            this.btnTransform.Name = "btnTransform";
            this.btnTransform.Size = new System.Drawing.Size(138, 23);
            this.btnTransform.TabIndex = 16;
            this.btnTransform.Text = "Excel数据转换Csv";
            this.btnTransform.UseVisualStyleBackColor = true;
            // 
            // btnCsv
            // 
            this.btnCsv.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCsv.ForeColor = System.Drawing.Color.Black;
            this.btnCsv.Location = new System.Drawing.Point(300, 118);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(75, 23);
            this.btnCsv.TabIndex = 15;
            this.btnCsv.Text = "导出CSV";
            this.btnCsv.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExcel.Location = new System.Drawing.Point(41, 118);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 14;
            this.btnExcel.Text = "选择Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // tbFilename
            // 
            this.tbFilename.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFilename.ForeColor = System.Drawing.Color.Black;
            this.tbFilename.Location = new System.Drawing.Point(117, 58);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(274, 22);
            this.tbFilename.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "导入Excel：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 398);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.btnCsvToCsv);
            this.Controls.Add(this.btnchosecsv);
            this.Controls.Add(this.tbcsvpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTransform);
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnCsvToCsv;
        private System.Windows.Forms.Button btnchosecsv;
        private System.Windows.Forms.TextBox tbcsvpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnTransform;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}

