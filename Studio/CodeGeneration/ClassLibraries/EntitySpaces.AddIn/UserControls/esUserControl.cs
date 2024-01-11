using System.Windows.Forms;
using EntitySpaces.MetadataEngine;
using EntitySpaces.AddIn.ES2019;

namespace EntitySpaces.AddIn
{
    public class esUserControl : UserControl
    {
        public MainWindow MainWindow { get; set; }

        protected esSettings Settings => MainWindow?.Settings;

        public virtual void OnSettingsChanged()
        {

        }
    }
}
