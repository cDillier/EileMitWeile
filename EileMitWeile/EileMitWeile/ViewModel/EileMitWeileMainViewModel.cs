using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EileMitWeile.ViewModel
{
	public class EileMitWeileMainViewModel : ViewModelBase
	{
        Model.EileMitWeileMainModel model;
        
        public EileMitWeileMainViewModel()
        {
            this.model = new Model.EileMitWeileMainModel();
        }

       //Hier Propertys för Bindnings
	}
}
