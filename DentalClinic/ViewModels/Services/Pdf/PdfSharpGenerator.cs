using Models.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Models.Model.Dto;
using System.IO.Packaging;
using System.IO;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows;

namespace Models.Services.Pdf
{
    public class PdfSharpGenerator : IPdfGenerator
    {

        public PdfSharpGenerator() {
        
        }

        public void GenerateInvoice(List<ReceiptDetailsDto> receiptData, object wpfWindow, string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                GenerateFileStructure(filePath);
            }

            // Convert WPF -> XPS -> PDF
            MemoryStream lMemoryStream = new MemoryStream();
            Package package = Package.Open(lMemoryStream, FileMode.Create);
            XpsDocument doc = new XpsDocument(package);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);

            // This is your window
            if (wpfWindow is Window window)
            {
                writer.Write(window);
                doc.Close();
                package.Close();

                var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(lMemoryStream);
                PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, filePath, 0);

                lMemoryStream.Flush();
                lMemoryStream.Close();
            }
            
           
        }

        private void GenerateFileStructure(string filePath)
        {
            // "../../../../../Database/Application/Receipts/Patient-ID/invoice_timestamp.pdf"
            string directoryPath = Path.GetDirectoryName(filePath);

            if (directoryPath != null)
            {
                // Create the directory and all necessary subdirectories
                Directory.CreateDirectory(directoryPath);

                Console.WriteLine($"The directory structure for '{directoryPath}' has been created or already exists.");
            }
            else
            {
                Console.WriteLine("Invalid file path.");
            }
        }

    }
}
