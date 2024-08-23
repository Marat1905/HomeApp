using HomeApp.Models;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceListPage : ContentPage
    {
        public List<HomeDevice> Devices { get; set; } = new List<HomeDevice>();

        public DeviceListPage()
        {
            InitializeComponent();

            // Заполняем список устройств
            Devices.Add(new HomeDevice("Чайник", "Chainik.png", description: "LG, объем 2л."));
            Devices.Add(new HomeDevice("Стиральная машина", "StiralnayaMashina.png", description: "BOSCH"));
            Devices.Add(new HomeDevice("Посудомоечная машина", "PosudomoechnayaMashina.png", description: "Gorenje"));
            Devices.Add(new HomeDevice("Мультиварка", "Multivarka.png", description: "Philips"));

            BindingContext = this;
        }

        /// <summary>
        /// Обработчик нажатия
        /// </summary>
        private void deviceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // распаковка модели из объекта
            var tappedDevice = (HomeDevice)e.Item;
            // уведомление
            DisplayAlert("Нажатие", $"Вы нажали на элемент {tappedDevice.Name}", "OK"); ; ;
        }

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // распаковка модели из объекта
            var selectedDevice = (HomeDevice)e.SelectedItem;
            // уведомление
            DisplayAlert("Выбор", $"Вы выбрали {selectedDevice.Name}", "OK"); ; ;
        }
    }
}