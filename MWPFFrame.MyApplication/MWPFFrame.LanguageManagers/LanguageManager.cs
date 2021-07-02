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

        private static ResourceDictionary _languageResourceDictionary = new ResourceDictionary();
        public static ResourceDictionary LanguageResourceDictionary => _languageResourceDictionary;
        public static void InitLanguage(string languageName)
        {
            _languageResourceDictionary.Clear();
            Uri[] uris = _globalDic[languageName];
            foreach (var uri in uris)
            {
                ResourceDictionary resourceDictionary = new ResourceDictionary() { Source = uri };
                _languageResourceDictionary.MergedDictionaries.Add(resourceDictionary);
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
