using MahApps.Metro.Controls.Dialogs;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;
using System.Windows.Input;
using TableExportExcle.Framework;
using TableExportExcle.Model;
using TableExportExcle.Toolkit;

namespace TableExportExcle.ViewModel
{
    internal class MainViewModel : NotifyBase
    {
        public MainModel MainModel { get; set; } = new MainModel();

        private string _sql;

        public string Sql
        {
            get { return _sql; }
            set { SetProperty(ref _sql, value, Sql); }
        }

        public RelayCommand ExportToExcel { get; private set; }

        public MainViewModel()
        {
            ExportToExcel = new RelayCommand()
            {
                DoExecute = obj =>
                {
                    TableToExcel(Sql);
                }
            };
        }

        private void TableToExcel(string sql)
        {

            IWorkbook workbook = new HSSFWorkbook();
            ////string fileExt = sfd.FileName.Substring(sfd.FileName.LastIndexOf('.')).ToLower();
            //switch (fileExt)
            //{
            //    case ".xlsx":
            //        workbook = new XSSFWorkbook();
            //        break;
            //    case ".xls":
            //        workbook = new HSSFWorkbook();
            //        break;
            //    default:
            //        return;
            //}

            //try
            //{
            // 从sql读取datatable
            var dt = DBhelper.ExecuteTable(sql.Trim());

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

            WriteStream(workbook, MainModel.FileName);

            //}
            //catch (Exception ex)
            //{
            //    ShowMessageAsync("Error", ex.Message, MessageDialogStyle.Affirmative);
            //}
        }

        private void WriteStream(IWorkbook workbook, string fileName)
        {
            // 转换成字节数组
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buffer = stream.ToArray();

            // 将字节数组写入文件
            using FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            fs.Write(buffer, 0, buffer.Length);
            fs.Flush();
        }

    }

    class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            DoExecute?.Invoke(parameter);
        }

        public Action<object?>? DoExecute { set; get; }

    }
}
