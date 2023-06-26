using Microsoft.EntityFrameworkCore;
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

namespace WpfApp23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AplicationContext db = new AplicationContext();
        public MainWindow()
        {
            InitializeComponent();


            Loaded += Window_Loaded;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow(new User());
            if(userWindow.ShowDialog() == true)
            {
                User user = userWindow.User;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = usersList.SelectedItem as User;
            if (selectedUser == null) return;

            UserWindow userWindow = new UserWindow(selectedUser);
            if (userWindow.ShowDialog() == true)
            {
                db.SaveChanges();
            }
        }

        private void Delite_Click(object sender, RoutedEventArgs e)
        {
            User? user = usersList.SelectedItem as User;
            if (user is null) return;
            db.Users.Remove(user);
            db.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();

            db.Users.Load();

            DataContext = db.Users.Local.ToObservableCollection();
        }
    }
}
