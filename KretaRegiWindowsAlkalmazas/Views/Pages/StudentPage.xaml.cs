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
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : UserControl
    {
        private StudentViewModel studentViewModel;

        public StudentPage(StudentViewModel studentViewModel)
        {
            this.studentViewModel = studentViewModel;
            InitializeComponent();
            this.DataContext = studentViewModel;
        }
    }
}
