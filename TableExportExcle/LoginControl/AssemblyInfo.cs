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

#region �Զ������ƿռ����÷�װ��
// ע�����XAML �����ռ�Ķ���ֻ�����ⲿ������Ч�����������õģ��Լ�û���������������

// XmlnsPrefix ����������ռ��Ĭ��ǰ׺��ֻ��Ĭ�϶��ѣ�չʾ�������� xmlns:flplc="xxxxxxx"
[assembly: XmlnsPrefix("http://schemas.flp.com/wpfLogin/2022/xaml", "flplc")]
// XmlnsDefinition ����ĳ�� C# �����ռ��һ�������ռ��ַ����ǵ����
[assembly: XmlnsDefinition("http://schemas.flp.com/wpfLogin/2022/xaml", "LoginControl")]
[assembly: XmlnsDefinition("http://schemas.flp.com/wpfLogin/2022/xaml", "LoginControl.Controls")]
#endregion 
