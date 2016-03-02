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

namespace WpfCSCollection
{
    /// <summary>
    /// Interaction logic for FindPropFrm.xaml
    /// </summary>
    public partial class FindPropFrm : Window
    {
        CollectionEx<Player> Findplayers;

        public FindPropFrm()
        {
            InitializeComponent();
        }

        public FindPropFrm(CollectionEx<Player> ps)
        {
            InitializeComponent();
            Findplayers = ps.Copy();
            ResetFields();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Player tmpPlayer = new Player("dummy", 5.0, 5.0, 12);
            double tmpDble;
            Int32 tmpInt32;
            this.DataGridView1.DataSource = null;
            this.lblResults.Content = String.Empty;
            if (tmpPlayer.GetType().GetProperty(this.txtProName.Text) == null)
            {
                ResetFields();
                this.lblResults.Content = "This property name " + this.txtProName.Text +
                    "could not be found.";
                return;
            }
            if (this.txtValue.Text == String.Empty)
            {
                this.lblResults.Content = "Enter to search for";
                return;
            }

            switch (this.txtProName.Text)
            {
                case "AtBats":
                    if (!Int32.TryParse(this.txtValue.Text, out tmpInt32))
                    {
                        this.lblResults.Content = "The value to search for is not an integer.";
                        return;
                    }
                    break;
                case "Average":
                case "SluggingPercentage":
                    if (!Double.TryParse(this.txtValue.Text, out tmpDble))
                    {
                        this.lblResults.Content = "The value to search for is not a double.";
                        return;
                    }
                    break;
            }
            CollectionEx<Player> ps;
            String playerStg = String.Empty;

            if (this.rbtEqualTo.IsChecked == true)
            {
                ps = Findplayers.Find(this.txtProName.Text,
                    this.txtValue.Text, FindRange.Equal);
            }
            else
            {
                if (this.rbtGreaterThan.IsChecked == true)
                {
                    ps = Findplayers.Find(this.txtProName.Text,
                        this.txtValue.Text, FindRange.GreaterThan);
                }
                else
                {
                    ps = Findplayers.Find(this.txtProName.Text,
                        this.txtValue.Text, FindRange.LessThan);
                }
            }
            if (ps.Count > 0)
            {
                this.DataGridView1.DataSource = ps;
                DataGridView1.Columns["IsDirty"].Visible = false;
                DataGridView1.Columns["IsNew"].Visible = false;
                DataGridView1.Columns["IsDeleted"].Visible = false;
            }
            else
            {
                ResetFields();
                this.lblResults.Content = "No matches could be found.";
            }
        }

        private void ResetFields()
        {
            this.DataGridView1.DataSource = null;
            this.txtProName.Text = String.Empty;
            this.txtValue.Text = String.Empty;
            this.rbtEqualTo.IsChecked = true;
            this.lblResults.Content = String.Empty;
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
