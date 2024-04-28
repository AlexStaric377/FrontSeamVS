﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Windows.Media;
using System.Windows.Controls;

namespace FrontSeam
{
    class ViewModelWinDeleteData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        // команда отказа от удаления закрытия окна
        RelayCommand? noDelete;
        public RelayCommand NoDelete
        {
            get
            {
                return noDelete ??
                  (noDelete = new RelayCommand(obj =>
                  {
                      WinDeleteData WindowWarning = MainWindow.LinkMainWindow("WinDeleteData");
                      MapOpisViewModel.DeleteOnOff = false;
                      WindowWarning.Close();
                  }));
            }
        }

        // команда отказа от удаления закрытия окна
        RelayCommand? yesDelete;
        public RelayCommand YesDelete
        {
            get
            {
                return yesDelete ??
                  (yesDelete = new RelayCommand(obj =>
                  {
                      WinDeleteData WindowWarning = MainWindow.LinkMainWindow("WinDeleteData");
                      MapOpisViewModel.DeleteOnOff = true;
                      WindowWarning.Close();
                  }));
            }
        }
    }
}
