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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace myRouter
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Teste : Window
    {
        public Teste()
        {
            InitializeComponent();
        }

        private void circle_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        Storyboard lanStoryBoard = new Storyboard();
        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            lanStoryBoard.Children.Clear();
            ColorAnimation ca2 = new ColorAnimation(Colors.Gray, Colors.Green, new Duration(TimeSpan.FromMilliseconds(500)));
            lanStoryBoard.Children.Add(ca2);
         //     Storyboard.SetTarget(ca2, az);
            Storyboard.SetTargetProperty(ca2, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));

            lanStoryBoard.Begin();
        }
    }
}
