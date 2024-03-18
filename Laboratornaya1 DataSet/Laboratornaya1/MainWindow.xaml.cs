using System;
using System.Collections.Generic;
using System.Data;
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

using Laboratornaya1.laba1DataSetTableAdapters;

namespace Laboratornaya1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  
        UsersTableAdapter users = new UsersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            UsersDgr.ItemsSource = users.GetData();
        }


        //Добавление 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            users.InsertQuery(NameTbx.Text, EmailSbx.Text, Convert.ToInt32(AgeCbx.Text));
            UsersDgr.ItemsSource = users.GetData();
        }


        //Изменение 
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (UsersDgr.SelectedItem as DataRowView).Row[0];
            users.UpdateQuery(NameTbx.Text, EmailSbx.Text, Convert.ToInt32(AgeCbx.Text), Convert.ToInt32(id));
            UsersDgr.ItemsSource = users.GetData();
        }


        //Удаление 
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object id = (UsersDgr.SelectedItem as DataRowView).Row[0];
            users.DeleteQuery(Convert.ToInt32(id));
            UsersDgr.ItemsSource = users.GetData();
        }
    }
}
