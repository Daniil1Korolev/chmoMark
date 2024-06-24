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

namespace fsagfsdgdfsg
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public uchetkaEntities db = new uchetkaEntities();
        public MainWindow()
        {
            InitializeComponent();
            Data_Reload();
        }

        public void Data_Reload()
        {
            var UserList = db.User.ToList();
            dgUser.SelectedValuePath = "ID";
            dgUser.ItemsSource = UserList;
            dgUser.SelectionMode = DataGridSelectionMode.Single;

            var RoleList = db.Roles.ToList();
            Role.SelectedValuePath = "ID";
            Role.ItemsSource = RoleList;
            Role.SelectedIndex = 0;
            Role.DisplayMemberPath = "RoleName";
        }

        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUser.SelectedItem != null)
            {
                User selectedItem = (User)dgUser.SelectedItem;
                Login.Text = selectedItem.Login;
                Role.SelectedItem = selectedItem.Roles;
            }
        }
    }
}
