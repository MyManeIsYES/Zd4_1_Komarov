using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_k
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 :ContentPage
    {
        public Page2 ()
        {
            InitializeComponent( );
        }

        private void USD_TextChanged (object sender, TextChangedEventArgs e)
        {
            try
            {
                EUR.Text = (Convert.ToDouble(USD.Text) * 1.075).ToString( );
            }
            catch
            {
                EUR.Text = "error";
            }
        }
    }
}