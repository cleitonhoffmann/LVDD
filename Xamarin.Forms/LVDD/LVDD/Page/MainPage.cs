using LVDD.API;
using LVDD.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LVDD.Page
{
    public class MainPage : ContentPage
    {
        private Func<APIConsumer> apiConsumerFactory;
        private ObservableCollection<UserItem> observable;
        private ListView _list;

        public MainPage(Func<APIConsumer> apiConsumerFactory)
        {
            this.apiConsumerFactory = apiConsumerFactory;

            this._list = new ListView(ListViewCachingStrategy.RecycleElement);
            this._list.IsPullToRefreshEnabled = true;
            this._list.ItemTemplate = new DataTemplate(this.LoadListTemplate);
            this._list.ItemTapped += List_ItemTapped;
            this._list.Refreshing += List_Refreshing;
            
            this.observable = new ObservableCollection<Model.UserItem>();
            this._list.ItemsSource = this.observable;

            this._list.BeginRefresh();

            Content = new StackLayout
            {
                Children = { this._list }
            };
        }

        private void List_Refreshing(object sender, EventArgs e)
        {
            using (var api = this.apiConsumerFactory())
            {
                var newItems = api.GetUsers();
                this.observable.Clear();
                foreach (var item in newItems)
                {
                    this.observable.Add(item);
                }

                this._list.EndRefresh();
            }
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            this._list.SelectedItem = null;

            var modelItem = (UserItem)e.Item;

            Navigation.PushAsync(new DetailsPage(modelItem), true);
        }

        private object LoadListTemplate()
        {
            var cell = new TextCell();
            cell.SetBinding(TextCell.TextProperty, "firstName");
            cell.SetBinding(TextCell.DetailProperty, "email");

            return cell;
        }
    }
}
