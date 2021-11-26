using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projecte.Entity;
using Projecte.Service;

namespace Projecte
{
    /// <summary>
    /// Lógica de interacción para Pestanya1.xaml
    /// </summary>
    public partial class Pestanya1 : Window
    {

        
        public Pestanya1()
        {
            InitializeComponent();

           listbox_1.ItemsSource = ResponsableService.GetAll();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Responsable oresp = new Responsable();
            oresp.Name = nom_entrat.Text;
            ResponsableService.Add(oresp);
            listbox_1.ItemsSource = ResponsableService.GetAll();

            nom_entrat.Clear();

        }
        public void TextBox_responsable_1(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_responsable_1;
        }
        
        private void butto_eliminar_Click(object sender, RoutedEventArgs e)
        {
            int index = listbox_1.SelectedIndex;
            Responsable tb = (Responsable)listbox_1.Items[index];
            ResponsableService.Delete(tb.ID);

            listbox_1.ItemsSource = ResponsableService.GetAll();

            //listbox_1.Items.RemoveAt(listbox_1.SelectedIndex);
            /*Responsable oresp = new Responsable();
            oresp.Name = nom_entrat.Text;
            ResponsableService resp = new ResponsableService();
            resp.(oresp);*/


        }
    }
}
