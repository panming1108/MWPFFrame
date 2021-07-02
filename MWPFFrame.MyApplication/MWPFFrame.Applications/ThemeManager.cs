using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace MWPFFrame.Applications
{
    public static class ThemeManager
    {
        private static Dictionary<string, Uri[]> _themeDic = new Dictionary<string, Uri[]>();
        private static ResourceDictionary _themeResourceDictionary = new ResourceDictionary();
        public static ResourceDictionary ThemeResourceDictionary => _themeResourceDictionary;
        public static void InitTheme(string themeName)
        {
            _themeResourceDictionary.Clear();
            Uri[] uris = _themeDic[themeName];
            foreach (var uri in uris)
            {
                ResourceDictionary resourceDictionary = new ResourceDictionary() { Source = uri };
                ThemeResourceDictionary.MergedDictionaries.Add(resourceDictionary);
            }
        }
        public static void RegisterTheme(string themeName, Uri[] resourceUris)
        {
            if(_themeDic.ContainsKey(themeName))
            {
                _themeDic[themeName] = resourceUris;
            }
            else
            {
                _themeDic.Add(themeName, resourceUris);
            }
        }
    }
}
