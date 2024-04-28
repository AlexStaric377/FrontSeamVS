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

namespace FrontSeam
{
    public partial class MapOpisViewModel : INotifyPropertyChanged
    {
        public static MainWindow MapAnaliz = MainWindow.LinkNameWindow("WindowMain");
        private bool addboolStanHealthPacient = false, loadboolStanHealthPacient=false, editboolStanHealthPacient = true;
        public static string pathcontrollerPacientMapAnaliz = "/api/PacientMapAnalizController/";
        public static PacientMapAnaliz selectPacientMapAnaliz;

        public PacientMapAnaliz SelectedPacientMapAnaliz
        {
            get { return selectPacientMapAnaliz; }
            set { selectPacientMapAnaliz = value; OnPropertyChanged("SelectedPacientMapAnaliz"); }
        }
        public static ObservableCollection<PacientMapAnaliz> ViewPacientMapAnalizs { get; set; }
        


        public void MethodLoadStanHealthPacient()
        {
            LoadStanHealthPacient();
        }

        public static void LoadStanHealthPacient()
        {
            CallServer.PostServer(pathcontrollerPacientMapAnaliz, pathcontrollerPacientMapAnaliz+ _pacientProfil+"/0", "GETID"); // 
            string CmdStroka = CallServer.ServerReturn();
            if (CmdStroka.Contains("[]"))CallServer.BoolFalseTabl();
            else ObservablelColectionStanHealthPacient(CmdStroka);
        }


        public static void ObservablelColectionStanHealthPacient(string CmdStroka)
        {
            var result = JsonConvert.DeserializeObject<ListPacientMapAnaliz>(CmdStroka);
            List<PacientMapAnaliz> res = result.PacientMapAnaliz.ToList();
            ViewPacientMapAnalizs = new ObservableCollection<PacientMapAnaliz>((IEnumerable<PacientMapAnaliz>)res);
            //BildModelReceptionPatient();
            MapAnaliz.StatusHealthTablGrid.ItemsSource = ViewPacientMapAnalizs;
        }
        public void MethodAddStanHealthPacient()
        {
            if (loadboolStanHealthPacient == false) MethodLoadStanHealthPacient();
            IndexAddEdit = IndexAddEdit == "addCommand" ? "" : "addCommand";
            if (addboolStanHealthPacient == false) BoolTrueStanHealthPacient();
            else BoolFalseStanHealthPacient();
            MapAnaliz.StatusHealthTablGrid.SelectedItem = null;

        }

        private void BoolTrueStanHealthPacient()
        {
            addboolStanHealthPacient = true;
            editboolStanHealthPacient = true;
            MapAnaliz.StatusHealthData1.IsEnabled = true;
            MapAnaliz.StatusHealthData1.Background = Brushes.AntiqueWhite;
            MapAnaliz.StatusHealth2.IsEnabled = true;
            MapAnaliz.StatusHealth2.Background = Brushes.AntiqueWhite;
            MapAnaliz.StatusHealth4.IsEnabled = true;
            MapAnaliz.StatusHealth4.Background = Brushes.AntiqueWhite;
            MapAnaliz.StatusHealth1.IsEnabled = true;
            MapAnaliz.StatusHealth1.Background = Brushes.AntiqueWhite;
            MapAnaliz.StatusHealth7.IsEnabled = true;
            MapAnaliz.StatusHealth7.Background = Brushes.AntiqueWhite;

        }

        private void BoolFalseStanHealthPacient()
        {
            addboolStanHealthPacient = false;
            editboolStanHealthPacient = false;
            MapAnaliz.StatusHealthData1.IsEnabled = false;
            MapAnaliz.StatusHealthData1.Background = Brushes.White;
            MapAnaliz.StatusHealth2.IsEnabled = false;
            MapAnaliz.StatusHealth2.Background = Brushes.White;
            MapAnaliz.StatusHealth4.IsEnabled = false;
            MapAnaliz.StatusHealth4.Background = Brushes.White;
            MapAnaliz.StatusHealth1.IsEnabled = false;
            MapAnaliz.StatusHealth1.Background = Brushes.White;
            MapAnaliz.StatusHealth7.IsEnabled = false;
            MapAnaliz.StatusHealth7.Background = Brushes.White;

        }


        public void MethodEditStanHealthPacient()
        {
            if (selectPacientMapAnaliz != null)
            { 
                IndexAddEdit = "editCommand";
                if (editboolStanHealthPacient == false)
                {
                    BoolTrueStanHealthPacient();
                }
                else
                {
                    BoolFalseStanHealthPacient();
                    MapAnaliz.StatusHealthTablGrid.SelectedItem = null;
                    IndexAddEdit = "";
                }            
            }

        }
        public void MethodRemoveStanHealthPacient()
        {
            if (selectPacientMapAnaliz != null)
            {
                if (selectPacientMapAnaliz.id != 0)
                {
                    string json = pathcontrollerPacientMapAnaliz + selectPacientMapAnaliz.id.ToString();
                    CallServer.PostServer(pathcontrollerPacientMapAnaliz, json, "DELETE");
                    ViewPacientMapAnalizs.Remove(selectPacientMapAnaliz);
                    selectPacientMapAnaliz = new PacientMapAnaliz();
                }

            }
            BoolFalseStanHealthPacient();
            IndexAddEdit = "";
        }
        public void MethodSaveStanHealthPacient()
        {
            if (MapAnaliz.StatusHealthData1.Text.Length != 0 && MapAnaliz.StatusHealth2.Text.Length != 0)
            {
                if (IndexAddEdit == "addCommand")
                {
                    //  формирование кода Detailing по значениею группы выранного храктера жалобы
                    SelectNewPacientMapAnaliz();
                    string json = JsonConvert.SerializeObject(selectPacientMapAnaliz);
                    CallServer.PostServer(pathcontrollerPacientMapAnaliz, json, "POST");
                    CallServer.ResponseFromServer = CallServer.ResponseFromServer.Replace("[", "").Replace("]", "");
                    PacientMapAnaliz Idinsert = JsonConvert.DeserializeObject<PacientMapAnaliz>(CallServer.ResponseFromServer);
                    if (ViewPacientMapAnalizs == null)
                    {
                        ViewPacientMapAnalizs = new ObservableCollection<PacientMapAnaliz>();
                        ViewPacientMapAnalizs.Add(Idinsert);
                    }
                    else
                    { ViewPacientMapAnalizs.Insert(ViewPacientMapAnalizs.Count, Idinsert); }
                    SelectedPacientMapAnaliz = Idinsert;
                    LoadStanHealthPacient();
                }
                else
                {
                    string json = JsonConvert.SerializeObject(selectPacientMapAnaliz);
                    CallServer.PostServer(pathcontrollerPacientMapAnaliz, json, "PUT");
                }
            }
            MapAnaliz.StatusHealthTablGrid.SelectedItem = null;
            BoolFalseStanHealthPacient();
            IndexAddEdit = "";
        }

        public void SelectNewPacientMapAnaliz()
        {
            selectPacientMapAnaliz = new PacientMapAnaliz();
            selectPacientMapAnaliz.kodPacient = _pacientProfil;
            selectPacientMapAnaliz.dateAnaliza = MapAnaliz.StatusHealthData1.Text.ToString();
            selectPacientMapAnaliz.pulse = MapAnaliz.StatusHealth2.Text.ToString();
            selectPacientMapAnaliz.pressure = MapAnaliz.StatusHealth4.Text.ToString();
            selectPacientMapAnaliz.temperature = MapAnaliz.StatusHealth1.Text.ToString();
            selectPacientMapAnaliz.resultAnaliza = MapAnaliz.StatusHealth7.Text.ToString();
        }

        public void MethodPrintStanHealthPacient()
        {
            if (ViewPacientMapAnalizs != null)
            {
                MessageBox.Show("Показники стану здоров'я :" + ViewPacientMapAnalizs[0].dateAnaliza.ToString()+"Пульс: "+ ViewPacientMapAnalizs[0].pulse.ToString());
            }
        }

 

        // команда выбора состояния анализа крови на указанную дату
        private RelayCommand? analizBlood;
        public RelayCommand AnalizBlood
        {
            get
            {
                return analizBlood ??
                  (analizBlood = new RelayCommand(obj =>
                  {

                      if (ViewPacientMapAnalizs == null)
                      {
                          MainWindow.MessageError = "Увага!" + Environment.NewLine + "Незавантажені показники стану здоров'я" + Environment.NewLine +
                          "Необхідно натиснути на кнопку <Завантажити>";
                          MapOpisViewModel.SelectedFalseLogin(5);
                          return;
                      }
                      WinColectionAnalizBlood Blood = new WinColectionAnalizBlood();
                      Blood.ShowDialog();


                  }));
            }
        }

        // команда выбора состояния анализа крови на указанную дату
        private RelayCommand? analizUrine;
        public RelayCommand AnalizUrine
        {
            get
            {
                return analizUrine ??
                  (analizUrine = new RelayCommand(obj =>
                  {

                      if (ViewPacientMapAnalizs == null)
                      {
                          MainWindow.MessageError = "Увага!" + Environment.NewLine + "Незавантажені показники стану здоров'я" + Environment.NewLine +
                         "Необхідно натиснути на кнопку <Завантажити>";
                          MapOpisViewModel.SelectedFalseLogin(5);
                          return;
                      }
                      WinColectionAnalizUrine Urine = new WinColectionAnalizUrine();
                      Urine.ShowDialog();



                  }));
            }
        }

        private RelayCommand? onVisibleObjStanHealth;
        public RelayCommand OnVisibleObjStanHealth
        {
            get
            {
                return onVisibleObjStanHealth ??
                  (onVisibleObjStanHealth = new RelayCommand(obj =>
                  {

                      if (MapAnaliz.StatusHealthTablGrid.SelectedIndex == -1) return;
                      if (ViewPacientMapAnalizs != null)
                      {
                          selectPacientMapAnaliz = ViewPacientMapAnalizs[MapAnaliz.StatusHealthTablGrid.SelectedIndex];
                          MapAnaliz.StatusHealthFolderBlood.Visibility = Visibility.Visible;
                          MapAnaliz.StatusHealthFoldUrine.Visibility = Visibility.Visible;

                      }


                  }));
            }
        }
    }
}
