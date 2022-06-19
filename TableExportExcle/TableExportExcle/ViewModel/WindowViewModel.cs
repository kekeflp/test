using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TableExportExcle.Framework;

namespace TableExportExcle.ViewModel
{
    public class WindowViewModel
    {
        public ICommand MouseLeftCommand { get; private set; }
        public ICommand DropCommand { get; private set; }
        public ICommand DragEnterCommand { get; private set; }
        public ICommand DragLeaveCommand { get; private set; }

        Canvas _canvas;
        public WindowViewModel()
        {
            MouseLeftCommand = new RelayCommand()
            {
                DoExecute = obj =>
                {
                    DragDrop.DoDragDrop((DependencyObject)obj, "fangkuai", DragDropEffects.Copy);
                }
            };

            /* 
             * 由于command 没法一次传递多个参数，
             * 所以拆分成多次传递
             */

            //1、接收对象,在本类中交换
            DragEnterCommand = new RelayCommand()
            {
                DoExecute = obj =>
                {
                    _canvas = obj as Canvas;
                }
            };

            //2、接收事件，
            DropCommand = new RelayCommand()
            {
                DoExecute = obj =>
                {
                    var e = obj as DragEventArgs;
                    // 接收拖拽源,与'fangkuai'关联起来，接收标识 
                    string data = e.Data.GetData(typeof(string)).ToString();
                    if (data == "fangkuai")
                    {
                        // 声明一个方块
                        Rectangle rectangle = new Rectangle()
                        {
                            Height = 80,
                            Width = 80,
                            Fill = Brushes.Red,
                        };

                        // 或者需要设置下放置的位置（相对位置-相对鼠标位置）
                        Canvas.SetLeft(rectangle, e.GetPosition(_canvas).X);
                        Canvas.SetTop(rectangle, e.GetPosition(_canvas).Y);

                        // 把方块对象添加到布局中
                        _canvas.Children.Add(rectangle);
                    };
                }
            };

            //3、销毁接收对象，释放资源
            DragLeaveCommand = new RelayCommand()
            {
                DoExecute = obj =>
                {
                    //todo 销毁对象
                }
            };
        }
    }
}
