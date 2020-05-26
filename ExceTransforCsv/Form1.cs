using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Reflection;

namespace ExceTransforCsv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
      
           label5.Text= Assembly.GetExecutingAssembly().GetName().Version.ToString();//Assembly.LoadFrom(assemblyPath).GetName().Version;

        }
        private bool ExcelFlag = false;
        private bool CsvFlag = false;
        //excel转换介质
        private DataTable detail = null;
        //csv转换介质
        private DataTable csvTable = null;
        //选择文件
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //选择文文件
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Excel文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            if (DialogResult.OK == o.ShowDialog())
            {
                if (string.IsNullOrWhiteSpace(o.FileName))
                {
                    MessageBox.Show("请选择文件");
                    return;
                }
                else
                {
                    this.ExcelFlag = true;
                    this.tbFilename.Text = o.FileName;
                }
            }
        }
        //导出csv
        private void btnCsv_Click(object sender, EventArgs e)
        {
            string fname = string.Empty;
            if (!string.IsNullOrWhiteSpace(this.tbFilename.Text))
            {
                fname = System.IO.Path.GetFileNameWithoutExtension(this.tbFilename.Text);
            }
            else
            {
                MessageBox.Show("请选择需要转换的文件");
                return;
            }
            string fp = ShowSaveFileDialog(fname);

            if (string.IsNullOrWhiteSpace(fp))
            {

            }
            else
            {
                if (detail.Rows.Count > 0)
                {

                    //1、清空
                    File.WriteAllText(fp, string.Empty);
                    //2、写入
                    StreamWriter sw = new StreamWriter(fp, true, Encoding.Default);
                    string line = string.Empty;
                    foreach (DataRow d in detail.Rows)
                    {
                        // line = s.Sno + ',' + s.Sname + ',' + s.Phone + ',' + s.Email + ',' + s.Sex + ',' + s.pathinfo;
                        line = null;
                        for (int i = 0; i < detail.Columns.Count; i++)
                        {
                            line += d[i.ToString()] + "\t,";
                        }
                        line = line.Substring(0, line.Length - 1);
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    //3、写入完成
                    MessageBox.Show("写入完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("没有数据");
                }
            }



        }
        //选择保存路径
        private string ShowSaveFileDialog(string name)
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "Excel表格（*.csv）|*.csv";
            sfd.FileName = name;
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                //给文件名前加上时间 
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt; 

                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 

                ////fs输出带文字或图片的文件，就看需求了 
            }

            return localFilePath;
        }

        //转换
        private void btnTransform_Click(object sender, EventArgs e)
        {
            if (ExcelFlag)
            {
                if (!string.IsNullOrWhiteSpace(this.tbFilename.Text.Trim()))
                {
                    ReadFromExcelFile(this.tbFilename.Text.Trim());
                }
                else
                {
                    MessageBox.Show("请选择要转换的文件");
                }
            }
        }

        private void ReadFromExcelFile(string filepath)
        {
            IWorkbook wk = null;
            string extension = System.IO.Path.GetExtension(filepath);
            try
            {
                FileStream fs = File.OpenRead(filepath);
                if (extension.Equals(".xls"))
                {
                    wk = new HSSFWorkbook(fs);
                }
                else
                {
                    wk = new XSSFWorkbook(fs);
                }
                fs.Close();
                detail = new DataTable();
                //获取当前表数据
                ISheet sheet = wk.GetSheetAt(0);
                IRow row = sheet.GetRow(0);
                IRow r = sheet.GetRow(9);
                //int offset = 0;
                int lastnum = row.LastCellNum;
                for (int f = 0; f < row.LastCellNum; f++)
                {
                    detail.Columns.Add(new DataColumn(f.ToString(), typeof(System.String)));

                }

                object temp = "";

                DataRow d = null;
                // MessageBox.Show("最后一行："+sheet.LastRowNum);
                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    row = sheet.GetRow(i);
                    d = detail.NewRow();
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        if (j < lastnum)
                        {
                            temp = GetCellValue(row.GetCell(j));
                            d[j.ToString()] = temp;
                        }
                    }
                    detail.Rows.Add(d);

                }
                MessageBox.Show("转换成功,请导出");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //转换成cell内容格式
        public object GetCellValue(ICell cell)
        {
            object value = null;
            try
            {
                if (cell != null && cell.CellType != CellType.BLANK)
                {
                    switch (cell.CellType)
                    {
                        case CellType.BLANK:
                            value = string.Empty;
                            break;
                        case CellType.BOOLEAN:
                            value = cell.BooleanCellValue;
                            break;
                        case CellType.NUMERIC:
                            if (DateUtil.IsCellDateFormatted(cell))//日期
                            {
                                value = cell.DateCellValue;
                            }
                            else
                            {
                                value = cell.NumericCellValue;
                            }
                            break;
                        case CellType.STRING:
                            value = cell.StringCellValue.Trim();
                            break;
                        case CellType.ERROR:
                            value = cell.ErrorCellValue;
                            break;
                        case CellType.FORMULA://公式
                            try
                            {
                                HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                                e.EvaluateInCell(cell);
                                value = cell.ToString();
                            }
                            catch
                            {
                                if (DateUtil.IsCellDateFormatted(cell))//日期
                                {
                                    value = cell.DateCellValue;
                                }
                                else
                                {
                                    value = cell.NumericCellValue;
                                }
                            }
                            break;
                        default:
                            value = cell.ToString();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return value;
        }
        //选择CSV文件
        private void btnchosecsv_Click(object sender, EventArgs e)
        {
            //选择文文件
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "CSV文件（*.csv）|*.csv|TXT文件（*.txt）|*.txt|所有文件(*.*)|*.*";
            if (DialogResult.OK == o.ShowDialog())
            {
                if (string.IsNullOrWhiteSpace(o.FileName))
                {
                    MessageBox.Show("请选择文件");
                    return;
                }
                else
                {
                    this.tbcsvpath.Text = o.FileName;
                    CsvFlag = true;
                }
            }
        }
        //csv转换csv
        private void btnCsvToCsv_Click(object sender, EventArgs e)
        {
            if (CsvFlag)
            {
                if (!string.IsNullOrWhiteSpace(this.tbcsvpath.Text))
                {
                    //读取文件
                    try
                    {
                        if (string.IsNullOrWhiteSpace(this.tbcsvpath.Text))
                        {
                            MessageBox.Show("请选择csv文件位置");
                        }
                        else
                        {
                            csvTable = ReadFile(this.tbcsvpath.Text.Trim());
                            if (csvTable.Rows.Count > 0)
                            {
                                MessageBox.Show("读取成功");
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("读取数据失败" + ex.Message, "数据读取", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("请选择文件");
                }
            }
        }
        /// <summary>
        /// 
        /// 从文件中读取学生信息
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DataTable ReadFile(string fileName)
        {

            string sr = string.Empty;
            csvTable = new DataTable();
            try
            {
                StreamReader sreader = new StreamReader(fileName, Encoding.Default);
                sr = sreader.ReadLine();
                string[] temp = sr.Split(',');

                for (int f = 0; f < temp.Length; f++)
                {
                    csvTable.Columns.Add(new DataColumn(f.ToString(), typeof(System.String)));
                }
                int lastnum = temp.Length;
                while (sr != null)
                {
                    string[] stu = sr.Split(',');
                    DataRow d = csvTable.NewRow();
                    for (int i = 0; i < stu.Length; i++)
                    {
                        if (i < lastnum)
                        {
                            d[i.ToString()] = stu[i].Replace("'", "");
                        }
                    }
                    csvTable.Rows.Add(d);
                    sr = sreader.ReadLine();
                }
                sreader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return csvTable;
        }
        //csc导出csv
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            string fname = string.Empty;
            if (!string.IsNullOrWhiteSpace(this.tbcsvpath.Text))
            {
                fname = System.IO.Path.GetFileNameWithoutExtension(this.tbcsvpath.Text);
            }
            else
            {
                MessageBox.Show("请选择需要转换的文件");
                return;
            }
            string fp = ShowSaveFileDialog(fname);

            if (string.IsNullOrWhiteSpace(fp))
            {

            }
            else
            {
                if (csvTable.Rows.Count > 0)
                {
                    //1、清空
                    File.WriteAllText(fp, string.Empty);
                    //2、写入
                    StreamWriter sw = new StreamWriter(fp, true, Encoding.Default);
                    string line = string.Empty;
                    foreach (DataRow d in csvTable.Rows)
                    {
                        // line = s.Sno + ',' + s.Sname + ',' + s.Phone + ',' + s.Email + ',' + s.Sex + ',' + s.pathinfo;
                        line = null;
                        for (int i = 0; i < csvTable.Columns.Count; i++)
                        {
                            line += d[i.ToString()] + "\t,";
                        }
                        line = line.Substring(0, line.Length - 1);
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    //3、写入完成
                    MessageBox.Show("写入完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("没有数据");
                }
            }
        }
        //加载数据
        private void Form1_Load(object sender, EventArgs e)
        {
            //不需要加载 因为是处理数据
        }

    }
}
