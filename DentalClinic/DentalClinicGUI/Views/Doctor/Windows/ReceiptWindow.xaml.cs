using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.IO;
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
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using ViewModels.Doctor;

namespace DentalClinicGUI.Views.Doctor.Windows
{
    /// <summary>
    /// Interaction logic for ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {
        public ReceiptWindow()
        {
            InitializeComponent();

            DataContext = new ReceiptViewModel(this, PrintButton, VerticalScrollViewer);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ///*
            // *  Convert WPF -> XPS -> PDF
            // */
            //MemoryStream lMemoryStream = new MemoryStream();
            //Package package = Package.Open(lMemoryStream, FileMode.Create);
            //XpsDocument doc = new XpsDocument(package);
            //XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);

            //// This is your window
            //writer.Write(this);

            //doc.Close();
            //package.Close();

            //var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(lMemoryStream);
            //PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, "../../../invoice.pdf", 0);
            //MessageBox.Show("SUCCESS");
        }
    }
}
