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

        // Создаем объект, возвращающий свойства устройства
        IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();

        public LoginPage()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Desktop)
                loginButton.CornerRadius = 0;

            // Передаем информацию о платформе на экран
            runningDevice.Text = detector.GetDevice();
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

                var infoMessage = (Label)stackLayout.Children.Last();
                infoMessage.Text = "Слишком много попыток! Попробуйте позже";

                // Новый цвет для информационных сообщений
                var warningColor = Color.FromHex("#ffa500");
                // Добавлем в словарь.
                Resources.Add("warningColor", warningColor);

                // Используем добавленный ресурс
                infoMessage.TextColor = (Color)Resources["warningColor"];
            }
            else
            {
                loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCouner}";
            }

            loginCouner += 1;
        }
    }
}