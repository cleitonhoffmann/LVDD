using LVDD.CustomView;
using LVDD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LVDD.Page
{
    public class DetailsPage : ContentPage
    {
        public DetailsPage(UserItem item)
        {
            var firstName = new TitleValueCustomView("Nome", item.firstName);
            var lastName = new TitleValueCustomView("Sobrenome", item.lastName);
            var email = new TitleValueCustomView("Email", item.email);

            Content = new StackLayout
            {
                Children = { firstName, lastName, email }
            };
        }
    }
}
