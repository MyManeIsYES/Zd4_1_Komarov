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
    public partial class Page1 :ContentPage
    {
        public Page1 ()
        {
            InitializeComponent( );
        }
        private void slider_ValueChanged (object sender, ValueChangedEventArgs e)
        {
            label_slider.Text = slider.Value.ToString( ) + '%';
            f1(Amo_cred.Text, Term.Text, slider.Value, picker.SelectedIndex);
        }

        private void Amo_cred_TextChanged (object sender, TextChangedEventArgs e)
        {
            f1(Amo_cred.Text, Term.Text, slider.Value, picker.SelectedIndex);
        }

        private void Term_TextChanged (object sender, TextChangedEventArgs e)
        {
            f1(Amo_cred.Text, Term.Text, slider.Value,picker.SelectedIndex);
        }

        
        private void picker_SelectedIndexChanged (object sender, EventArgs e)
        {
            f1(Amo_cred.Text, Term.Text, slider.Value, picker.SelectedIndex);
        }
        private void f1 (string amo_cred, string term, double slider, int view)
        {
            if ( amo_cred != "" && term != "" )
            {
                try
                {
                    double t = Convert.ToDouble(term), ac = Convert.ToDouble(amo_cred);
                    if ( t != 0 && ac != 0 )
                    {
                        double mp, ta, ov;
                        switch (view) 
                        {
                            case 0:
                                mp = (ac + ac * slider / 100) / t;
                                ta = mp * t;
                                ov = ta - ac;
                                Monthly_payment.Text = $"Ежемесячный платеж: {Math.Round(mp, 2)}";
                                Total_amount.Text = $"Общая сумма: {Math.Round(ta, 2)}";
                                Overpayment.Text = $"Переплата: {Math.Round(ov, 2)}";
                                break;
                            case 1:
                                mp = ac*(slider+(slider/(Math.Pow((1+slider),t)-1)));
                                ta = mp * t;
                                ov = ta - ac;
                                Monthly_payment.Text = $"Ежемесячный платеж: {Math.Round(mp, 2)}";
                                Total_amount.Text = $"Общая сумма: {Math.Round(ta, 2)}";
                                Overpayment.Text = $"Переплата: {Math.Round(ov, 2)}";
                                break;
                            default:
                                Monthly_payment.Text = "Ежемесячный платеж: error";
                                Total_amount.Text = "Общая сумма: error";
                                Overpayment.Text = "Переплата: error"; break;
                        }
                        
                        
                    }
                    else
                    {
                        Monthly_payment.Text = "Ежемесячный платеж: error";
                        Total_amount.Text = "Общая сумма: error";
                        Overpayment.Text = "Переплата: error";
                    }
                }
                catch
                {
                    Monthly_payment.Text = "Ежемесячный платеж: error";
                    Total_amount.Text = "Общая сумма: error";
                    Overpayment.Text = "Переплата: error";
                }
            }
            else
            {
                Monthly_payment.Text = "Ежемесячный платеж: ...";
                Total_amount.Text = "Общая сумма: ...";
                Overpayment.Text = "Переплата: ...";
            }
        }

    }
}