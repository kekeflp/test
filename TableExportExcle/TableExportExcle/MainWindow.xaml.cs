using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using System.IO;

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


        private void click()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel file(*.xls)|*.xls|*.xlsx",
                FilterIndex = 0,
                RestoreDirectory = true,
                Title = "Export Excel File"
            };
            //if (sfd.ShowDialog() != DialogResult.ok)
            //{
            //    return;
            //}
            string myExcel = sfd.FileName;
            HSSFWorkbook hwf = new HSSFWorkbook();
            var sheet = hwf.CreateSheet("Sheet1");
            FileStream file = new FileStream(myExcel, FileMode.Create);
            hwf.Write(file);
            file.Close();
            //DBhelper.SelectForScalar(TbxSql.Text.Trim(), null);

        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
