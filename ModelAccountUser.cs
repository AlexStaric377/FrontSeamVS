﻿using System;
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

namespace FrontSeam
{

    // Учетные записи
   

    public class ModelAccountUser : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        private int Id;
        private string IdUser;
        private string IdStatus;
        private string Login;
        private string Password;
        private string KodDostupa;
        private string NameStatus;


        public ModelAccountUser(int Id = 0, string IdUser = "", string IdStatus = "", string Login = "", string Password = "",
            string KodDostupa="",string NameStatus="")
        {
            this.Id = Id;
            this.IdUser = IdUser;
            this.IdStatus = IdStatus;
            this.Login = Login;
            this.Password = Password;
            this.KodDostupa = KodDostupa;
            this.NameStatus = NameStatus;
        }

        public int id
        {
            get { return Id; }
            set { Id = value; OnPropertyChanged("id"); }
        }
        public string idUser
        {
            get { return IdUser; }
            set { IdUser = value; OnPropertyChanged("idUser"); }
        }
        public string idStatus 
        {
            get { return IdStatus; }
            set { IdStatus = value; OnPropertyChanged("idStatus"); }
        }
        public string login
        {
            get { return Login; }
            set { Login = value; OnPropertyChanged("login"); }
        }
        public string password
        { get { return Password; } set { Password = value; OnPropertyChanged("password"); } }
        public string kodDostupa
        {
            get { return KodDostupa; }
            set { KodDostupa = value; OnPropertyChanged("kodDostupa"); }
        }

        public string nameStatus
        {
            get { return NameStatus; }
            set { NameStatus = value; OnPropertyChanged("nameStatus"); }
        }
    }

    public partial class ListAccountUser
    {

        [JsonProperty("list")]
        public AccountUser[] AccountUser { get; set; }

    }
    public class AccountUser
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("idUser")]
        public string idUser { get; set; }

        [JsonProperty("idStatus")]
        public string idStatus { get; set; }

        [JsonProperty("login")]
        public string login { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }


    }


    // Типы и коды доступа пользователей
    public partial class ListNsiStatusUser
    {

        [JsonProperty("list")]
        public NsiStatusUser[] NsiStatusUser { get; set; }

    }
    public class NsiStatusUser
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("idStatus")]
        public string idStatus { get; set; } // 1,2,3,4,5

        [JsonProperty("statusUser")]
        public string statusUser { get; set; }

        [JsonProperty("nameStatus")]
        public string nameStatus { get; set; } // гость, пациент, доктор, администратор

        [JsonProperty("kodDostupa")]
        public string kodDostupa { get; set; } // RWED (читать,добавлять,редактировать,удалять)

    }

}
