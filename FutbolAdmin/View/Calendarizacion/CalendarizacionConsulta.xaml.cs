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
using System.Windows.Shapes;
using FutbolAdmin.ViewModel.Calendarizacion;

namespace FutbolAdmin.View.Calendarizacion {
    /// <summary>
    /// Interaction logic for CalendarizacionConsulta.xaml
    /// </summary>
    public partial class CalendarizacionConsulta : Window {
        public CalendarizacionConsulta() {
            DataContext = new CalendarizacionConsultaViewModel();
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void GenerarButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
