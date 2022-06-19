using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TableExportExcle.ViewModel;
using Brushes = System.Windows.Media.Brushes;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace TableExportExcle.View
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 创建拖动对象
            // 当鼠标左键点击后，执行拖拽，设定一个标识
            DragDrop.DoDragDrop(this, "fangkuai", DragDropEffects.Copy);
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            // 接收拖拽源,与'fangkuai'关联起来，接收标识 
            string data = e.Data.GetData(typeof(string)).ToString();
            if (data == "fangkuai")
            {
                // 声明一个方块
                Rectangle rectangle = new Rectangle()
                {
                    Height = 80,
                    Width = 80,
                    Fill = Brushes.Orange,
                };

                // 需要设置下放置的位置(绝对位置)
                //Canvas.SetLeft(rectangle, 30);
                //Canvas.SetTop(rectangle, 30);
                // 或者需要设置下放置的位置（相对位置-相对鼠标位置）
                Canvas.SetLeft(rectangle, e.GetPosition((IInputElement)sender).X);
                Canvas.SetTop(rectangle, e.GetPosition((IInputElement)sender).Y);

                // 把方块对象添加到布局中
                (sender as Canvas).Children.Add(rectangle);
            }
        }
    }
}
