﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace FrontSeam
{
    class ViewModelMessageWarn : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        // команда закрытия окна
        RelayCommand? closeWarning;
        public RelayCommand CloseWarning
        {
            get
            {
                return closeWarning ??
                  (closeWarning = new RelayCommand(obj =>
                  {
                      MessageWarn WindowWarn = MainWindow.LinkMainWindow("MessageWarn");
                      WindowWarn.Close();
                  }));
            }
        }

        // команда закрытия окна
        RelayCommand? exitInterview;
        public RelayCommand ExitInterview
        {
            get
            {
                return exitInterview ??
                  (exitInterview = new RelayCommand(obj =>
                  {
                      MapOpisViewModel.StopDialog = true;
                      MessageWarn WindowWarn = MainWindow.LinkMainWindow("MessageWarn");
                      WindowWarn.Close();
                  }));
            }
        }
    }
}
