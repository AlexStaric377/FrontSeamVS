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
    

    public partial class ListMedGrupDiagnoz
    {
        [JsonProperty("list")]
        public MedGrupDiagnoz[] MedGrupDiagnoz { get; set; }
    }

    public class MedGrupDiagnoz
    {
        public int id { get; set; }
        public string edrpou { get; set; }
        public string icdGrDiagnoz { get; set; } // код группы МКХ в которую входит диагноз

    }

    public partial class ListModelMedGrupDiagnoz
    {
        [JsonProperty("list")]
        public ModelMedGrupDiagnoz[] ModelMedGrupDiagnoz { get; set; }
    }

    public class ModelMedGrupDiagnoz : BaseViewModel
    {

        public int Id;
        public string Edrpou;
        public string IcdGrDiagnoz;
       

        public ModelMedGrupDiagnoz(int Id = 0, string Edrpou = "", string IcdGrDiagnoz = "")
        {
            this.Id = Id;
            this.Edrpou = Edrpou;
            this.IcdGrDiagnoz = IcdGrDiagnoz;
 
        }

        [JsonProperty("id")]
        public int id
        {
            get { return Id; }
            set { Id = value; OnPropertyChanged("id"); }
        }

        [JsonProperty("edrpou")]
        public string edrpou
        {
            get { return Edrpou; }
            set { Edrpou = value; OnPropertyChanged("edrpou"); }
        }
        [JsonProperty("icdGrDiagnoz")]
        public string icdGrDiagnoz
        {
            get { return IcdGrDiagnoz; }
            set { IcdGrDiagnoz = value; OnPropertyChanged("icdGrDiagnoz"); }
        }
    }
}
