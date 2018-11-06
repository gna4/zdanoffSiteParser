using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SitesParser
{
    public interface IMessageService
    {
        void ShowMessage(string msg);
        void ShowWarning(string msg);
        void ShowError(string msg);
    }

    class MessageService: IMessageService
    {
        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
