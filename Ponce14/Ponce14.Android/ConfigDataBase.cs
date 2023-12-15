using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ponce14.Droid;
using Ponce14.Interfaces;
using System.IO;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Dependency(typeof(ConfigDataBase))]

namespace Ponce14.Droid
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);
        }
    }
}