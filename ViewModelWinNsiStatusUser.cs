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
    class ViewModelWinNsiStatusUser : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        WinNsiStatusUser WindowStatusUser = MainWindow.LinkMainWindow("WinNsiStatusUser");
        private string pathcontroller = "/api/NsiStatusUserController/";
        public static NsiStatusUser selectedWinNsiStatusUser;
        public static ObservableCollection<NsiStatusUser> ViewNsiStatusUsers { get; set; }


        public NsiStatusUser SelectedWinNsiStatusUser
        { get { return selectedWinNsiStatusUser; } set { selectedWinNsiStatusUser = value; OnPropertyChanged("SelectedWinNsiStatusUser"); } }
        // конструктор класса
        public ViewModelWinNsiStatusUser()
        {
            CallServer.PostServer(pathcontroller, pathcontroller, "GET");
            string CmdStroka = CallServer.ServerReturn();
            ObservableNsiStatusUsers(CmdStroka);
        }
        public static void ObservableNsiStatusUsers(string CmdStroka)
        {
            var result = JsonConvert.DeserializeObject<ListNsiStatusUser>(CmdStroka);
            List<NsiStatusUser> res = result.NsiStatusUser.ToList();
            ViewNsiStatusUsers = new ObservableCollection<NsiStatusUser>((IEnumerable<NsiStatusUser>)res);
        }



        // команда закрытия окна
        RelayCommand? closeNsiStatusUsers;
        public RelayCommand CloseNsiStatusUsers
        {
            get
            {
                return closeNsiStatusUsers ??
                  (closeNsiStatusUsers = new RelayCommand(obj =>
                  {
                      WindowStatusUser.Close();
                  }));
            }
        }

        // команда выбора строки из списка жалоб
        RelayCommand? selectNsiStatusUsers;
        public RelayCommand SelectNsiStatusUsers
        {
            get
            {
                return selectNsiStatusUsers ??
                  (selectNsiStatusUsers = new RelayCommand(obj =>
                  {
                      MainWindow WindowMain = MainWindow.LinkNameWindow("WindowMain");
                      if (selectedWinNsiStatusUser != null)
                      {
                          WindowMain.AccountUsert3.Text = selectedWinNsiStatusUser.idStatus.ToString() + ": " + selectedWinNsiStatusUser.nameStatus.ToString();
                          WindowMain.AccountUsert1.Text = selectedWinNsiStatusUser.kodDostupa.ToString();

                      }
                      WindowStatusUser.Close();
                  }));
            }
        }

    }

}
