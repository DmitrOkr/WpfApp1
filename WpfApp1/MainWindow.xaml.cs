using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Reflection;

namespace WpfApp1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetClassMetod();
        }

        public void GetClassMetod()
            {

            var path = new OpenFileDialog { CheckFileExists = true, Multiselect = false }; 
            path.ShowDialog();

            Assembly asm = Assembly.LoadFrom(path.FileName);
            Type[] typelist = asm.GetTypes();
            foreach (Type cl in typelist)

            {

                textBox.AppendText("" + "\r\n");
                textBox.AppendText(cl.Name + "\r\n");
                MethodInfo[] flag = cl.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic); //Флаги
                var protectedOnly = flag.Where(m => m.IsPublic || m.IsFamily); // Фильтр


                foreach (var count in protectedOnly)
                {
                    textBox.AppendText("-" + count.Name + "\r\n");
                }
                textBox.AppendText("" + "\r\n");
            }

        }
    }
}
