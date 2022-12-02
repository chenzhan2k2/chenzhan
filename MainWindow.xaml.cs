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
using DE1.Models;


namespace de3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        De1Context db = new De1Context();

        private void hienthi()
        {
            var data = from sp in db.Saches
                       orderby sp.Sotrang descending
                       select new
                       {
                           sp.Masach,
                           sp.Tensach,
                           sp.Matg,
                           sp.Sotrang,
                           Giasach = sp.Sotrang * 70000
                       };
            dssach.ItemsSource = data.ToList();
        }
        private void hienthicb()
        {
            var tacgia = from tg in db.TacGia
                         select tg;
            cbtacgia.ItemsSource = tacgia.ToList();
            cbtacgia.DisplayMemberPath = "Tentacgia";
            cbtacgia.SelectedValuePath = "Matg";
            cbtacgia.SelectedIndex = 0;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
            hienthicb();
        }

    //    private void btnthem_Click(object sender, RoutedEventArgs e)
    //    {
    //        var spthem = db.Saches.SingleOrDefault(t => t.Masach.Equals(txtmasach.Text));
    //        if (spthem != null)
    //        {
    //            MessageBox.Show("San pham nay da ton tai", "Thong bao");
    //        }
    //        else
    //        {
    //            Sach s = new Sach();
    //            s.Masach = txtmasach.Text;
    //            s.Tensach = txttensach.Text;
    //            s.Sotrang = int.Parse(txtsl.Text);
    //            s.Matg = ((TacGium)cbtacgia.SelectedItem).Matg;
    //            db.Saches.Add(s);
    //            db.SaveChanges();
    //            MessageBox.Show("them thanh cong", "Thong bao");
    //            hienthi();
    //        }
    //    }

    //    private void btntim_Click(object sender, RoutedEventArgs e)
    //    {
    //        var sptim = from sp1 in db.Saches
    //                    where sp1.Masach == txtmasach.Text
    //                    select new
    //                    {
    //                        sp1.Masach,
    //                        sp1.Tensach,
    //                        sp1.Matg,
    //                        sp1.Sotrang,
    //                        Giasach = sp1.Sotrang * 70000
    //                    };
    //        dssach.ItemsSource = sptim.ToList();
    //    }
    }
}