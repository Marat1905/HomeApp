using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public
        const string BUTTON_TEXT = "Войти";
        public static int loginCouner = 0;
       // IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();

        public LoginPage()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Desktop)
                loginButton.CornerRadius = 0;

            //runningDevice.Text = detector.GetDevice();

            // Устанавливаем динамический ресурс с помощью специально метода
            infoMessage.SetDynamicResource(Label.TextColorProperty, "errorColor");
        }

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private void Login_Click(object sender, EventArgs e)
        {
            if (loginCouner == 0)
            {
                loginButton.Text = $"Выполняется вход..";
            }
            else if (loginCouner > 5)
            {
                loginButton.IsEnabled = false;

                // Обновляем динамический ресурс по необходимости
                Resources["errorColor"] = Color.FromHex("#e70d4f");
                infoMessage.Text = "Слишком много попыток! Попробуйте позже";
            }
            else
            {
                // Обновляем динамический ресурс по необходимости
                Resources["errorColor"] = Color.FromHex("#ff8e00");

                loginButton.Text = $"Выполняется вход...";
                infoMessage.Text = $" Попыток входа: { loginCouner}";
            }

            loginCouner += 1;
        }
    }
}