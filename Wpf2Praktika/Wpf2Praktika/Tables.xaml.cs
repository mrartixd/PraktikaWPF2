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

namespace Wpf2Praktika
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        //db_Artur_ShabunovEntities db;
        db_Artur_ShabunovEntitiesInput db;
        public Tables()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //db = new db_Artur_ShabunovEntities();
            db = new db_Artur_ShabunovEntitiesInput();
            grouptable.ItemsSource = db.tGroups.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tGroup group = new tGroup();
            group.NameGroup = groupname.Text;
            db.tGroups.Add(group);
            db.SaveChanges();
            grouptable.ItemsSource = db.tGroups.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(IDbox.Text);
            var dRow = db.tGroups.Where(w => w.ID == num).FirstOrDefault();
            db.tGroups.Remove(dRow);
            db.SaveChanges();
            grouptable.ItemsSource = db.tGroups.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(IDbox.Text);
            var uRow = db.tGroups.Where(w => w.ID == num).FirstOrDefault();
            uRow.NameGroup = groupname.Text;
            db.SaveChanges();
            grouptable.ItemsSource = db.tGroups.ToList();
        }
    }
}
