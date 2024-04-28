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

namespace FrontSeam
{
    /// <summary>
    /// Логика взаимодействия для WinMessageDialog.xaml
    /// </summary>
    public partial class WinMessageDialog : Window
    {
        public static int AutoCloseTick = 0, SetTimeClose = 0;
        System.Windows.Threading.DispatcherTimer CloseAuto = new System.Windows.Threading.DispatcherTimer();
        public WinMessageDialog(string TextWindows = null, int AutoClose = 0, int TimeClose = 0)
        {
            InitializeComponent();
            if (TextWindows != null)
            {
                // Определить высоту окна по количеству \n в многострочном тексте
                var TextWindows_a = TextWindows.Split('\n');

                this.MessageText.Text = TextWindows != null ? TextWindows : "Сообщение отсутствует!";

            }
        }
    }
}
