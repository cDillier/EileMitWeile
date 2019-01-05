using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EileMitWeile.ViewModel
{
	public class EileMitWeileMainViewModel : ViewModelBase
	{
        Model.EileMitWeileMainModel model;
        
        public EileMitWeileMainViewModel()
        {
            this.model = new Model.EileMitWeileMainModel();
        }

        public string ActSpieler { get; set; }
        public Color ActColour { get; set; }
        public bool registerVisibility { get; set; } = false;

        public bool RotChecked { get; set; }
        public bool BlauChecked { get; set; }
        public bool GrünChecked { get; set; }
        public bool GelbChecked { get; set; }
        public string RotName { get; set; }
        public string BlauName { get; set; }
        public string GrünName { get; set; }
        public string GelbName { get; set; }
    }
}
