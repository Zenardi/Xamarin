using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FernandesBartender
{
    public partial class Album : ContentPage
    {
        public Album()
        {
            InitializeComponent();
            BindingContext = new AlbumPageViewModel();
        }
    }
}
