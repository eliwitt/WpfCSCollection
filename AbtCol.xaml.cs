using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace WpfCSCollection
{
    /// <summary>
    /// Interaction logic for AbtCol.xaml
    /// </summary>
    public partial class AbtCol : Window
    {
        private string abMsg;

        public AbtCol()
        {
            InitializeComponent();

        }

        public AbtCol(string myStrg)
        {
            InitializeComponent();
            // Set the title of the form.
            String ApplicationTitle;
            //if (Application.Info.Title != String.Empty)
            //    ApplicationTitle = Application.Info.Title;
            //else
            //ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(Assembly.AssemblyName);
            ApplicationTitle = Assembly.GetExecutingAssembly().FullName;
            this.Title = String.Format("About {0}", ApplicationTitle);
            this.LabelProductName.Content = "C #Collection";
            //this.LabelVersion.Content = String.Format("Version {0}", Application.Info.Version.ToString);
            //this.LabelCopyRight.Content = Application.Info.Copyright;
            this.LabelCompanyName.Content = "Self";
            this.TextBoxDescription.Text = myStrg;

        }

         private void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
