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


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private laba1Entities context = new laba1Entities();
        public MainWindow()
        {
            InitializeComponent();
            UsersDgr.ItemsSource = context.Users.ToList();
        }


        //Добавление
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users c = new Users();
            c.UserName = NameTbx.Text;
            c.Email = EmailSbx.Text;
            c.Age = Convert.ToInt32(AgeCbx.Text);

            context.Users.Add(c);

            context.SaveChanges();
            UsersDgr.ItemsSource = context.Users.ToList();
        }


        //Изменение
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (UsersDgr.SelectedItem != null)
            {

                var selected = UsersDgr.SelectedItem as Users;

                selected.UserName = NameTbx.Text;
                selected.Email= EmailSbx.Text;
                selected.Age = Convert.ToInt32(AgeCbx.Text);

                context.SaveChanges();
                UsersDgr.ItemsSource = context.Users.ToList();
            }


        }


        //Удаление
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (UsersDgr.SelectedItem != null)
            {
                context.Users.Remove(UsersDgr.SelectedItem as Users);

                context.SaveChanges();
                UsersDgr.ItemsSource = context.Users.ToList();
            }
        }
    }
}
