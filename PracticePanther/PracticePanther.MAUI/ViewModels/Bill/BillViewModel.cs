using System;
using PracticePanther.Library.Models;

namespace PracticePanther.MAUI.ViewModels
{
	public class BillViewModel
	{
		public BillViewModel()
		{
            Model = new Bill();
        }

        public BillViewModel(Bill bill)
        {
            Model = bill;
            //SetupCommands();
        }

        //*****************************ELEMENTS******************************

        public Bill Model { get; set; }

        //*******************************METHODS*******************************

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
    }
}

