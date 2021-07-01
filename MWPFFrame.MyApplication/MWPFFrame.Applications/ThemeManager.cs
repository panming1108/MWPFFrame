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
        private static Dictionary<string, Brush> _currentTheme;
        public static Dictionary<string, Brush> CurrentTheme
        {
            get
            {
                if (_currentTheme == null)
                {
                    _currentTheme = new Dictionary<string, Brush>();
                }
                return _currentTheme;
            }
        }
        public static void InitTheme(string themeName)
        {
            _currentTheme = new Dictionary<string, Brush>();
            Uri[] resourceDictionaries = _themeDic[themeName];
            foreach (var uri in resourceDictionaries)
            {
                ResourceDictionary resourceDictionary = new ResourceDictionary() { Source = uri };
                var enumerator = resourceDictionary.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    _currentTheme.Add(enumerator.Key.ToString(), enumerator.Value as Brush);
                }
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
