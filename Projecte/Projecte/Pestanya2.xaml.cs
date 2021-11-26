using Projecte.Service;
using System;
using System.Collections.Generic;
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
using Projecte;




namespace Projecte
{
    /// <summary>
    /// Lógica de interacción para Pestanya2.xaml
    /// </summary>
    public partial class Pestanya2 : Window
    {
        MainWindow mainWindow;
        public Pestanya2(MainWindow mw)
        {
            InitializeComponent();
            mainWindow = mw;
            mainWindow.refresh();
           
        }

        private void txt_afegirbuto_Click(object sender, RoutedEventArgs e)
        {
            Tasca oresp = new Tasca();
            oresp.ID = txt_id.CaretIndex;
            oresp.Name = txt_name.Text;
            oresp.Descripcio = txt_descripció.Text;
            oresp.Data = DateTime.Parse(txt_data.Text);
            oresp.Data1 = DateTime.Parse(txt_data_1.Text);
            TascaService.Add(oresp);
            mainWindow.refresh();

            txt_id.Clear();
            txt_name.Clear();
            txt_descripció.Clear();
            txt_data.Clear();
            txt_data_1.Clear();

            mainWindow.refresh();


            this.Close();
        }

        
        public void TextBox_txt_id(object sender, RoutedEventArgs e)
        {
                TextBox tb = (TextBox)sender;
                tb.Text = string.Empty;
                tb.GotFocus -= TextBox_txt_id;
        }
        public void TextBox_txt_descripció(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_descripció;
        }
        public void TextBox_txt_responsable(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_responsable;
        }
        public void TextBox_txt_data(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_data;
        }

    }
}
