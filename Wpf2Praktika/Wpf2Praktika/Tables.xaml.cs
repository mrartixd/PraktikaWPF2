using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            teachertable.ItemsSource = db.tTeachers.ToList();
            studenttable.ItemsSource = db.tStudents.ToList();
            string[] classes = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            _class.ItemsSource = classes;
            _class.SelectedIndex = 0;
            List<tGroup> group = new List<tGroup>();
            group = db.tGroups.ToList();
            foreach(tGroup g in group)
            {
                groupt.Items.Add(new ComboBoxItem(g.NameGroup, g.ID.ToString()));
                groups.Items.Add(new ComboBoxItem(g.NameGroup, g.ID.ToString()));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            tGroup group = new tGroup();
            group.NameGroup = groupname.Text;
            db.tGroups.Add(group);
            db.SaveChanges();
            grouptable.ItemsSource = db.tGroups.ToList();
            ClearBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
            int num = Convert.ToInt32(IDbox.Text);
            var dRow = db.tGroups.Where(w => w.ID == num).FirstOrDefault();
            db.tGroups.Remove(dRow);
            db.SaveChanges();
            grouptable.ItemsSource = db.tGroups.ToList();
            ClearBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            { 
            int num = Convert.ToInt32(IDbox.Text);
            var uRow = db.tGroups.Where(w => w.ID == num).FirstOrDefault();
            uRow.NameGroup = groupname.Text;
            db.SaveChanges();
            grouptable.ItemsSource = db.tGroups.ToList();
            ClearBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string filterText = search.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(grouptable.ItemsSource);

            if (!string.IsNullOrEmpty(filterText))
            {
                cv.Filter = o => {
                    tGroup p = o as tGroup;
                    return (p.NameGroup.ToUpper().StartsWith(filterText.ToUpper()));
                };
            }
            else
            {
                grouptable.ItemsSource = db.tGroups.ToList();
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            { 
            int num = Convert.ToInt32(IDboxt.Text);
            var dRow = db.tTeachers.Where(w => w.ID == num).FirstOrDefault();
            db.tTeachers.Remove(dRow);
            db.SaveChanges();
            teachertable.ItemsSource = db.tTeachers.ToList();
            ClearBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
}

        private void searcht_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = searcht.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(teachertable.ItemsSource);

            if (!string.IsNullOrEmpty(filterText))
            {
                cv.Filter = o => {
                    tTeacher p = o as tTeacher;
                    return (p.FirstName.ToUpper().StartsWith(filterText.ToUpper()));
                };
            }
            else
            {
                teachertable.ItemsSource = db.tTeachers.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
            tTeacher teacher = new tTeacher();
            teacher.FirstName = firstnamet.Text;
            teacher.LastName = lastnamet.Text;
            teacher.Telephone = telephonet.Text;
            teacher.ContactEmail = emailt.Text;
            teacher.GroupFK = Convert.ToInt32(((ComboBoxItem)groupt.SelectedItem).HiddenValue);
            db.tTeachers.Add(teacher);
            db.SaveChanges();
            teachertable.ItemsSource = db.tTeachers.ToList();
            ClearBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
}

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(IDboxt.Text);
            var uRow = db.tTeachers.Where(w => w.ID == num).FirstOrDefault();
            uRow.FirstName = firstnamet.Text;
            uRow.LastName = lastnamet.Text;
            uRow.Telephone = telephonet.Text;
            uRow.ContactEmail = emailt.Text;
            uRow.GroupFK = Convert.ToInt32(((ComboBoxItem)groupt.SelectedItem).HiddenValue);
            db.SaveChanges();
            teachertable.ItemsSource = db.tTeachers.ToList();
            ClearBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                tStudent student = new tStudent();
                student.FirstName = firstnames.Text;
                student.LastName = lastnames.Text;
                student.IDCode = Convert.ToInt32(idcode.Text);
                student.School = school.Text;
                student.Class = Convert.ToInt32(_class.SelectedItem);
                student.Telephone = telephones.Text;
                student.ContactEmail = emails.Text;
                student.GroupFK = Convert.ToInt32(((ComboBoxItem)groups.SelectedItem).HiddenValue);

                db.tStudents.Add(student);
                db.SaveChanges();
                studenttable.ItemsSource = db.tStudents.ToList();
                ClearBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group"+ ex.ToString() , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
           
            
           
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
            int num = Convert.ToInt32(IDboxs.Text);
            var uRow = db.tStudents.Where(w => w.ID == num).FirstOrDefault();
            uRow.FirstName = firstnames.Text;
            uRow.LastName = lastnames.Text;
            uRow.IDCode = Convert.ToInt32(idcode.Text);
            uRow.School = school.Text;
            uRow.Class = Convert.ToInt32(_class.SelectedItem);
            uRow.Telephone = telephones.Text;
            uRow.ContactEmail = emails.Text;
            uRow.GroupFK = Convert.ToInt32(((ComboBoxItem)groups.SelectedItem).HiddenValue);
            db.SaveChanges();
            studenttable.ItemsSource = db.tStudents.ToList();
            ClearBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group" + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
            int num = Convert.ToInt32(IDboxs.Text);
            var dRow = db.tStudents.Where(w => w.ID == num).FirstOrDefault();
            db.tStudents.Remove(dRow);
            db.SaveChanges();
            studenttable.ItemsSource = db.tStudents.ToList();
            ClearBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while editing. Check: email, telephone number, group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void IDboxs_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<tStudent> student = db.tStudents.ToList();
            foreach (tStudent r in student)
            {
                var result = 0;
                if (int.TryParse(IDboxs.Text, out result))
                {
                    if (r.ID == Convert.ToInt32(IDboxs.Text))
                    {
                        firstnames.Text = r.FirstName;
                        lastnames.Text = r.LastName;
                        idcode.Text = r.IDCode.ToString();
                        school.Text = r.School;
                        _class.Text = r.Class.ToString();
                        emails.Text = r.ContactEmail;
                        telephones.Text = r.Telephone;
                        groups.SelectedIndex = r.GroupFK;
                    }
                }
                else
                {
                    ClearBox();
                }
            }
        }
        private void ClearBox()
        {
            groupname.Clear();
            firstnames.Clear();
            firstnamet.Clear();
            lastnames.Clear();
            lastnamet.Clear();
            idcode.Clear();
            school.Clear();
            _class.SelectedIndex = 0;
            emails.Clear();
            emailt.Clear();
            telephones.Clear();
            telephonet.Clear();
            groups.SelectedIndex = -1;
            groupt.SelectedIndex = -1;
        }

        private void searchs_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = searchs.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(studenttable.ItemsSource);

            if (!string.IsNullOrEmpty(filterText))
            {
                cv.Filter = o => {
                    tStudent p = o as tStudent;
                    return (p.FirstName.ToUpper().StartsWith(filterText.ToUpper()));
                };
            }
            else
            {
                studenttable.ItemsSource = db.tStudents.ToList();
            }
        }

        private void IDboxs_KeyDown(object sender, KeyEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(IDboxs.Text);
        }

        private void IDboxs_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void IDboxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<tTeacher> teachers = db.tTeachers.ToList();
            foreach (tTeacher r in teachers)
            {
                var result = 0;
                if (int.TryParse(IDboxt.Text, out result))
                {
                    if (r.ID == Convert.ToInt32(IDboxt.Text))
                    {
                        firstnamet.Text = r.FirstName;
                        lastnamet.Text = r.LastName;
                        emailt.Text = r.ContactEmail;
                        telephonet.Text = r.Telephone;
                        groupt.SelectedIndex = r.GroupFK;
                    }
                }
                else
                {
                    ClearBox();
                }
            }
        }

        private void IDbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<tGroup> groups = db.tGroups.ToList();
            foreach (tGroup r in groups)
            {
                var result = 0;
                if (int.TryParse(IDbox.Text, out result))
                {
                    if (r.ID == Convert.ToInt32(IDbox.Text))
                    {
                        groupname.Text = r.NameGroup;
                    }
                }
                else
                {
                    ClearBox();
                }
            }
        }

        private void IDbox_KeyDown(object sender, KeyEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(IDbox.Text);
        }

        private void IDbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);

        }

        private void IDboxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void IDboxt_KeyDown(object sender, KeyEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(IDboxt.Text);
        }
    }
}
