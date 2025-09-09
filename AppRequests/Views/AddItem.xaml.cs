using AppRequests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppRequests.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        private MyDatabase database;

        public AddItem()
        {
            InitializeComponent();

            database = new MyDatabase(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydata.db3"));
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            var digits = Regex.Replace((phoneEntry.Text ?? ""), @"\D", ""); // только цифры
            if (!((digits.Length == 11 && (digits.StartsWith("7") || digits.StartsWith("8"))) || digits.Length == 10))
            {
                await DisplayAlert("Error", "Введите полный Российский номер телефона!", "Ok");
                return;
            }

            database.AddData(nameEntry.Text, phoneEntry.Text, moneyEntry.Text, platformEntry.Text, textEntry.Text);
            await Navigation.PopAsync();
            nameEntry.Text = "";
            phoneEntry.Text = "";
            moneyEntry.Text = "";
            platformEntry.Text = "";
            textEntry.Text = "";
            await DisplayAlert("Информация", "Заявка успешно подана", "Ок");
        }
    }
}