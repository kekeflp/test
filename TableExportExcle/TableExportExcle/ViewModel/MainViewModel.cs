using NPOI.SS.UserModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using TableExportExcle.Framework;
using TableExportExcle.Model;

namespace TableExportExcle.ViewModel
{
    internal class MainViewModel : NotifyBase
    {
        public MainModel MainModel { get; set; } = new MainModel();

        private string _sqlText;

        public string SqlText
        {
            get { return _sqlText; }
            set { SetProperty(ref _sqlText, value); }
        }

        public ObservableCollection<MainModel> ListData { get; set; } = new ObservableCollection<MainModel>();

        public ICommand ExportToExcel { get; private set; }
        public ICommand BtnRemove { get; private set; }
        public ICommand BtnShowDialog { get; private set; }

        public MainViewModel()
        {
            ExportToExcel = new RelayCommand()
            {
                DoExecute = obj =>
                {
                    TableToExcel(SqlText);
                }
            };
            ListData.Add(new MainModel { FileName = "AAAAAA" });
            ListData.Add(new MainModel { FileName = "BBBBBB" });
            ListData.Add(new MainModel { FileName = "CCCCCC" });
            ListData.Add(new MainModel { FileName = "DDDDDD" });
            ListData.Add(new MainModel { FileName = "EEEEEE" });

            BtnRemove = new RelayCommand()
            {
                DoExecute = obj =>
                {
                    ListData.Remove(obj as MainModel);
                }
            };

            BtnShowDialog = new RelayCommand()
            {
                // 点击后执行显示窗口，通过字符串为桥梁标识
                DoExecute = obj =>
                {
                    if (ActionStack.Execute("dialog", obj))
                    {

                    }
                    else
                    {

                    }
                }
            };
        }

        private void TableToExcel(string sql)
        {

            //IWorkbook workbook = new HSSFWorkbook();
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
            //var dt = DBhelper.ExecuteTable(sql.Trim());

            //// 创建sheet页签
            //ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

            //// 创建表头
            //IRow row = sheet.CreateRow(0);
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    ICell cell = row.CreateCell(i);
            //    cell.SetCellValue(dt.Columns[i].ColumnName);
            //}

            //// 创建数据
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    IRow row1 = sheet.CreateRow(i + 1);
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        ICell cell = row1.CreateCell(j);
            //        cell.SetCellValue(dt.Rows[i][j].ToString());
            //    }
            //}

            //WriteStream(workbook, MainModel.FileName);

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
}
