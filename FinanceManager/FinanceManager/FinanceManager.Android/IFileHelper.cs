using System;
using System.IO; // Для Path
using FinanceManager.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperAndroid))]
namespace FinanceManager.Droid
{
    public class FileHelperAndroid : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}