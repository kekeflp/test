using System.Windows.Input;

namespace TableExportExcle.Model
{
    internal class MainModel
    {
        public string SqlText { get; set; } = "select * from Employee e;";

        public string? FileName { get; set; }

    }
}
