using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitesParser.BL.Interfaces;

namespace SitesParser
{
    class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IMessageService _messageService;
        private readonly IDataService _dvataService;
        private readonly IParser _parser;

        public MainPresenter(IMainForm view, IMessageService msgService, IDataService dataService, IParser parser)
        {
            _view = view;
            _messageService = msgService;
            _dvataService = dataService;
            _parser = parser;

            _view.SetCountOfFoundShops(0);

            _view.SatrtSearchClick += _view_SatrtSearchClick;

        }

        private void _view_SatrtSearchClick(object sender, EventArgs e)
        {
            string site = _view.Site;
            List<string> shops = _parser.FindShops(site);
            _view.SetCountOfFoundShops(shops.Count);
            _view.AddMessageLog(shops.Aggregate((i, j) => i + "\n" + j));            
        }
    }
}