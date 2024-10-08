﻿using AutoMapper;
using HomeApp.Clients;
using HomeApp.Data;
using HomeApp.Pages;
using System;
using System.IO;
using Xamarin.Forms;

namespace HomeApp
{
    public partial class App : Application
    {
        // Инициализация репозитория
        public static HomeDeviceRepository HomeDevices = new HomeDeviceRepository(
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                $"homedevices.db")
            );

        /// <summary>
        /// Инициализация Api-клиента для использования во всех частях приложения
        /// </summary>
        public static HomeApiClient ApiClient = new HomeApiClient("http://10.0.2.2:5000");

        public static IMapper Mapper { get; set; }

        public App()
        {
            Mapper = CreateMapper();

            // инициализация интерфейса
            InitializeComponent();
            // Инициализация главного экрана и стека навигации
            MainPage = new NavigationPage(new LoginPage());
        }

        /// <summary>
        /// Создание Автомаппера для преобразования сущностей
        /// </summary>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Маппинг сущностей базы данных во внутренние сущности бизнес-логики
                cfg.CreateMap<Data.Tables.HomeDevice, Models.HomeDevice>();
                cfg.CreateMap<Models.HomeDevice, Data.Tables.HomeDevice>();

                // Маппинг внешнего контракта API во внутреннюю модель
                cfg.CreateMap<HomeApi.Contracts.Home.InfoResponse, Models.HouseInfo>();
                cfg.CreateMap<HomeApi.Contracts.Home.AddressInfo, Models.Address>();
            });

            return config.CreateMapper();
        }

        protected async override void OnStart()
        {
            await HomeDevices.InitDatabase();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
