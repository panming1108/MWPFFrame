using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MWPFFrame.Applications
{
    public class ProgramBase
    {
        private static string[] _composeParts;
        internal static string[] ComposeParts
        {
            get 
            {
                if(_composeParts == null)
                {
                    _composeParts = new string[] { };
                }
                return _composeParts;
            }
        }

        public void BuildComposeParts(string[] assemblies)
        {
            _composeParts = assemblies;
            AggregateCatalog catalog = new AggregateCatalog();
            foreach (var item in assemblies)
            {
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.Load(item)));
            }
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
