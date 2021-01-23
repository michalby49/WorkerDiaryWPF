﻿using MahApps.Metro.Controls;
using System;
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
using System.Windows.Shapes;
using WorkerDiaryWPF.ViewModels;

namespace WorkerDiaryWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Settings.xaml
    /// </summary>
    public partial class SettingsView : MetroWindow
    {
        public SettingsView(bool needRestart)
        {
            InitializeComponent();
            DataContext = new SettingsViewModel(needRestart);
        }
    }
}
