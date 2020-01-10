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

namespace _2DimencialArray
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int n;
        public int[,] a;
        public int[] v;
        public MainWindow()
        {
            Random random = new Random();
            int n = 5;// random.Next(5, 10);
            a = new int[n, n];
            v = new int[n];

            InitializeComponent();

            UIGrid.Columns = n;
            UIGrid.Rows = n;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = i + j;//random.Next(1, 10);
                    UIGrid.Children.Add(new Button() { Content = a[i, j].ToString()});
                }
            }

            UIGrid2.Rows = n;

            for (int i = 0; i < n; i++)
            {
                v[i] = i; random.Next(1, 10);
                UIGrid2.Children.Add(new Button() { Content = v[i].ToString() }); ;
            }

            UIGrid3.Rows = n;

        }

        private int[] MultiplyToVector(int[,] a, int[] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[] r = new int[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    r[i] += a[i, j] * b[j];
                }
            }
            return r;
        }

        private void btnNextTask_Click(object sender, RoutedEventArgs e)
        {
            Window secondWindow = new SecondWindow();
            secondWindow.Show();
            
            this.Close();
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {   
            int[] res = MultiplyToVector(a, v);

            UIGrid3.Children.Clear();
            for (int i = 0; i < res.Length; i++)
            {
                UIGrid3.Children.Add(new Button() { Content = res[i].ToString() });
            }
        }
    }
}
