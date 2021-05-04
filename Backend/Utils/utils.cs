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
    }

}