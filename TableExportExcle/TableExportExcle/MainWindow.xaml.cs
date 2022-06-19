using System.Windows;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using TableExportExcle.Toolkit;
using TableExportExcle.ViewModel;
using TableExportExcle.Framework;
using TableExportExcle.View;

namespace TableExportExcle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            // 通过 字符串 和 ActionStack 作为桥梁，串接起View窗口和Viewmodel，
            ActionStack.Register("dialog", obj =>
            {
                Window2 window2 = new Window2();
                window2.DataContext = obj;
                window2.ShowDialog();
            });
        }

        private void TableToExcel()
        {
            if (TbxSql.Text.Contains("update") || TbxSql.Text.Contains("delete") || TbxSql.Text.Contains("drop"))
            {
                this.ShowMessageAsync("Error", "查询语句中不能包含update、delete、drop。", MessageDialogStyle.Affirmative);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel文件|*.xls;*.xlsx|所有文件|*.*",
                FilterIndex = 0,
                RestoreDirectory = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                FileName = "TestTable.xlsx",
                Title = "Export Excel File"
            };

            // 如果没点OK，就跳出
            if (sfd.ShowDialog() != true) return;




        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.PsbProcess.Value = 0;
            TableToExcel();
            this.PsbProcess.Value = 100;
        }
    }
}
