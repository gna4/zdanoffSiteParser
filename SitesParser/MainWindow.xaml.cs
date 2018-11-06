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

using SitesParser.BL.Services;

namespace SitesParser
{
    public interface IMainForm
    {
        string Site { get; }
        void SetCountOfFoundShops(int count);
        void AddMessageLog(string msg);
        event EventHandler SatrtSearchClick;
        event EventHandler SaveShopsClick;
    }

    public partial class MainWindow : Window, IMainForm
    {
        public MainWindow()
        {
            InitializeComponent();

            btnStartSearch.Click += BtnStartSearch_Click;
            btnSaveResult.Click += BtnSaveResult_Click;
           
            MessageService msgService = new MessageService();
            FileManager dataService = new FileManager();
            ZolotoyvekParser parser = new ZolotoyvekParser();

            MainPresenter presenter = new MainPresenter(this, msgService, dataService, parser);
        }

        #region Events
        private void BtnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            if (SaveShopsClick != null)
            {
                SaveShopsClick(this, EventArgs.Empty);
            }
        }

        private void BtnStartSearch_Click(object sender, RoutedEventArgs e)
        {
            if (SatrtSearchClick != null)
            {
                SatrtSearchClick(this, EventArgs.Empty);
            }
        }
        #endregion

        #region IMainFom
        public string Site
        {
            get { return cboxSitesSupport.Text; }
        }
        
        public void SetCountOfFoundShops(int count)
        {
            lblShopsCount.Content = count.ToString();
        }

        public void AddMessageLog(string msg)
        {
            tBoxLog.Text += msg;
        }

        public event EventHandler SatrtSearchClick;
        public event EventHandler SaveShopsClick;
        #endregion
    }
}
