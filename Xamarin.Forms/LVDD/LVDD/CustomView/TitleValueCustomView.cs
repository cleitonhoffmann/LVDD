using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LVDD.CustomView
{
    public class TitleValueCustomView : StackLayout
    {
        public TitleValueCustomView(string title, string value)
        {
            var titleLabel = new Label();
            titleLabel.Text = string.Format("{0}:", title);
            titleLabel.FontAttributes = FontAttributes.Bold;
            
            var valueLabel = new Label();
            valueLabel.Text = value;
            valueLabel.FontSize *= 1.5;

            base.Children.Add(titleLabel);
            base.Children.Add(valueLabel);
        }
    }
}
