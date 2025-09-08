using AppRequests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRequests.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        private MyDatabase database;

        public ItemPage()
        {
            InitializeComponent();

            database = new MyDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydata.db3"));
            var data = database.GetAllData();
            dataList.ItemsSource = data;
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var data = (MyData)dataList.SelectedItem;
            if (data != null)
            {
                database.DeleteData(data.ID);
                var newData = database.GetAllData();
                dataList.ItemsSource = newData;
            }
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            var data = database.GetAllData();
            dataList.ItemsSource = data;
        }
    }
}