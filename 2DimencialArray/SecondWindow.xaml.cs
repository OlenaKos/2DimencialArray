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
using System.Windows.Shapes;

namespace _2DimencialArray
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public static int n;
        public int[,] c;
        public int[,] d;
        public int[,] res;
        public SecondWindow()
        {
            InitializeComponent();

            Random random = new Random();
            int n = 5;// random.Next(5, 10);
            c = new int[n, n];
            d = new int[n, n];


            UIGrid.Columns = n;
            UIGrid.Rows = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = i + j; //random.Next(1, 10);
                    UIGrid.Children.Add(new Button() { Content = c[i, j].ToString() });
                }
            }

            UIGrid2.Columns = n;
            UIGrid2.Rows = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    d[i, j] = i + j;// random.Next(1, 10);
                    UIGrid2.Children.Add(new Button() { Content = d[i, j].ToString() });
                }
            }
            UIGrid3.Rows = n;
        } 

        private void btnNextTask_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {


            if (IsMultPossible(c, d) == true)
            {
                res = MultiplyToMatrix(c, d);
            }
            else
            {
                res[0, 0] = 0;//"Multiplication impossible";
            }

            //UIGrid3.Children.Clear();
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    UIGrid3.Children.Add(new Button() { Content = res[i, j].ToString() });
                }
            }
        }

        static int[,] MultiplyToMatrix(int[,] a, int[,] b)
        {

            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    r[i, j] = 0;
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        static bool IsMultPossible(int[,] a, int[,] b)
        {
            bool ismultpossible = false;
            if (a.GetLength(1) == b.GetLength(0))
            {
                ismultpossible = true;
            }
            return ismultpossible;
        }

    }
}
