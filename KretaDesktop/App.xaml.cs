﻿using ApplicationPropertiesSettings;
using KretaDesktop.Localization;
using KretaDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KretaDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CultureProperties cultureProperties = new CultureProperties();
            cultureProperties.SetCurrentCultureToDefaultCulture();

            ProjectLocalization projectLocalization=new ProjectLocalization();
            projectLocalization.SwitchToCurrentCuture();

            // https://www.thecodebuzz.com/nlog-file-logging-wpf-application-net/

            /* var window = new MainWindow() { DataContext = new MainWindowViewModel()};
            window.Show();*/
        }
    }
}
