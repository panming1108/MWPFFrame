using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows;

namespace MWPFFrame.LanguageManagers
{
    public class LanguageManager
    {
        private static Dictionary<string, Uri[]> _globalDic = new Dictionary<string, Uri[]>();

        private static Dictionary<string, string> _currentLanguageReSource;
        public static Dictionary<string,string> CurrentLanguageReSource
        {
            get
            {
                if(_currentLanguageReSource == null)
                {
                    _currentLanguageReSource = new Dictionary<string, string>();
                }
                return _currentLanguageReSource;
            }
        }

        public static void InitLanguage(string languageName)
        {
            _currentLanguageReSource = new Dictionary<string, string>();
            Uri[] resourceDictionaries = _globalDic[languageName];
            foreach (var uri in resourceDictionaries)
            {
                ResourceDictionary resourceDictionary = new ResourceDictionary() { Source = uri };
                var enumerator = resourceDictionary.GetEnumerator();
                while(enumerator.MoveNext())
                {
                    _currentLanguageReSource.Add(enumerator.Key.ToString(), enumerator.Value.ToString());
                }
            }
        }

        public static void RegisterLanguage(string languageName, Uri[] resourceDictionaries)
        {
            if (_globalDic.ContainsKey(languageName))
            {
                _globalDic[languageName] = resourceDictionaries;
            }
            else
            {
                _globalDic.Add(languageName, resourceDictionaries);
            }
        }
    }
}
