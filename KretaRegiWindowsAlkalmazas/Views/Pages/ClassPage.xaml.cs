﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Kreta.ViewModels;


namespace Kreta.Views.Pages
{
    /// <summary>
    /// Interaction logic for ClassPage.xaml
    /// </summary>
    public partial class ClassPage : UserControl
    {
        private ClassViewModel classViewModel;
        public ClassPage(ClassViewModel classViewModel)
        {
            this.classViewModel = classViewModel;
            InitializeComponent();
            this.DataContext = classViewModel;
        }
    }
}
