using System.Windows;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace TableExportExcle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void TableToExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog
            { 
                Filter = "Excel file (*.xls)|*.xlsx|All files (*.*)|*.*",
                FilterIndex = 0,
                RestoreDirectory = true,
                Title = "Export Excel File"
            };

            sfd.ShowDialog();
          
            IWorkbook workbook;

            string fileExt = sfd.FileName.Substring(sfd.FileName.LastIndexOf('.')).ToLower();
            //string fileExt = System.IO.Path.GetExtension(file).ToLower();
            switch (fileExt)
            {
                case ".xlsx":
                    workbook = new XSSFWorkbook();
                    break;
                case ".xls":
                    workbook = new HSSFWorkbook();
                    break;
                default:
                    workbook = null;
                    return;
            }

            // 从sql读取datatable
            var dt = DBhelper.ExecuteTable(TbxSql.Text.Trim());

            // 创建sheet页签
            ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

            // 创建表头
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            // 创建数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            // 转换成字节数组
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buffer = stream.ToArray();

            // 将字节数组写入文件
            using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
            }
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.PsbProcess.Value = 0;
            TableToExcel();
            this.PsbProcess.Value = 100;
        }
    }
}
