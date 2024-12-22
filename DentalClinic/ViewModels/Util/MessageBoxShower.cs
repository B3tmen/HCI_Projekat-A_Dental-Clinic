using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModels.Util
{
    public class MessageBoxShower
    {
        public static MessageBoxResult ShowSuccessBox(string caption, string content = "")
        {
            return MessageBox.Show(content, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult ShowErrorBox(string caption, string content = "")
        {
            return MessageBox.Show(content, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static MessageBoxResult ShowQuestionBox(string caption, string content = "")
        {
            return MessageBox.Show(content, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    
    }
}
