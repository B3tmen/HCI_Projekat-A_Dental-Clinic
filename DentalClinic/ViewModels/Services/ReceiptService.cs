using Models.Interfaces;
using Models.Model;
using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace ViewModels.Services
{
    public class ReceiptService
    {
        private readonly IPdfGenerator _pdfGenerator;
        private readonly string _fileName;

        public ReceiptService(IPdfGenerator pdfGenerator, int patientId)
        {
            _pdfGenerator = pdfGenerator;
            _fileName = $"../../../../../Database/Application/Receipts/Patient-{patientId}/invoice_{DateTime.Now.Ticks}.pdf";
        }

        public void GenerateReceipt(List<ReceiptDetailsDto> receiptData, Window wpfWindow)
        {
            //Height = "800" Width = "860"  // Capping the window dimensions because of potential user resize
            //wpfWindow.Height = 800;
            //wpfWindow.Width = 860;

            _pdfGenerator.GenerateInvoice(receiptData, wpfWindow, _fileName);
            if (File.Exists(_fileName))
            {
                Console.WriteLine("successfull write");
            }
            else
            {
                Console.WriteLine("unsuccessfull write");
            }
        }
    }
}
