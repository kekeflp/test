using System.Windows;
using System.Windows.Markup;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]

#region 自定义名称空间引用封装包
// 注意事项：XAML 命名空间的定义只会在外部程序集生效。（给别人用的，自己没法享受这个福利）

// XmlnsPrefix 定义此命名空间的默认前缀（只是默认而已）展示出来就是 xmlns:flplc="xxxxxxx"
[assembly: XmlnsPrefix("http://schemas.flp.com/wpfLogin/2022/xaml", "flplc")]
// XmlnsDefinition 定义某个 C# 命名空间和一段命名空间字符串是等意的
[assembly: XmlnsDefinition("http://schemas.flp.com/wpfLogin/2022/xaml", "LoginControl")]
[assembly: XmlnsDefinition("http://schemas.flp.com/wpfLogin/2022/xaml", "LoginControl.Controls")]
#endregion 
