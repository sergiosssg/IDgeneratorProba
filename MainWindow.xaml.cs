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

namespace IDgeneratorProba
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDgenerator _idGenerator;

        public MainWindow()
        {
            InitializeComponent();
            _idGenerator = new IDgenerator();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("The window is loading ...");
        }
    }
}
