using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Projecte.Persistence;
using System.Threading.Tasks;
using System.IO;
using Projecte.Entity;
using Projecte.Service;


namespace Projecte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
      


        public MainWindow()
        {
            InitializeComponent();
            DbContext.Up();
           // textbox_1.ItemsSource = ResponsableService.GetAll();
            textbox_1.ItemsSource = TascaService.GetAll();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //textbox_1.ItemsSource = tasca_1.Text;
            Pestanya2 pestanya2 = new Pestanya2(this);
            pestanya2.ShowDialog();

            //Tasca tasc = new Tasca();
            //tasc.Name = tasca_1.Text;
            //TascaService.Add(tasc);
            textbox_1.ItemsSource = TascaService.GetAll();
           


            // textbox_1.Items.Add(tasca_1.Text);
            
        }
        public void TextBox_tasca_1(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_tasca_1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            Pestanya1 pestanya1 = new Pestanya1();
            pestanya1.ShowDialog();

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            
            int index = textbox_1.SelectedIndex;
            Tasca tb = (Tasca)textbox_1.Items[index];
            TascaService.Delete(tb.ID);

            textbox_1.ItemsSource = TascaService.GetAll();
            
        }

        private void textbox_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void refresh()
        {
            textbox_1.ItemsSource = TascaService.GetAll();
        }

    }

}
      /*  private void Window_ContentRendered(object sender, EventArgs e)
        {
            //Obtenim la llista des d'on s'ha polsat 
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            //Obtenim l'element seleccionat
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        private object GetDataFromListBox(ListBox dragSource, object p)
        {
            throw new NotImplementedException();
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(string));
            ((IList)dragSource.ItemsSource).Remove(data);
            ((IList)parent.ItemsSource).Add(data);
        }
    }

    }

*/