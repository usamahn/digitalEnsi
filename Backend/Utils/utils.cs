using System;
using System.Linq;
using AutoMapper;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Utils
{

    public static class Utils{
        public static string convertDate(DayOfWeek jour,TimeSpan heure){
            var a=(int)(jour + 18) ; //range of date in frontend is from 2021-04-19 to 2021-04-24 (week) 
            return "2021-04-"+a+"T"+heure;
            
        }
        public static string getAnnéeUniversitaireActuelle(){
            if(DateTime.Now.Month>=8){
                return DateTime.Now.Year+"-"+DateTime.Now.Year+1;

            } else {
                return DateTime.Now.Year-1+"-"+DateTime.Now.Year;
            }
        }
        public static int getSemestreActuelle(){
            if(DateTime.Now.Month>=1 && DateTime.Now.Month<8){
                return 2;

            } else {
                return 1;
            }
        }

        public static int getYear(string année_Universitaire, int semestre){
            string  annee;
            if(semestre==1){
                 annee =année_Universitaire.Split("-")[0];
            }else{
                 annee =année_Universitaire.Split("-")[1];
            }
            return Int16.Parse(annee);
        }
    }

}