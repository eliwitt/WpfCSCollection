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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WpfCSCollection
{
   
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FrmMain : Window
    {
        public CollectionEx<Player> players;
        /// <summary>
        /// Initialize everything
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            rbtAscending.IsChecked = true;
            players = new CollectionEx<Player>();
            players.Add(new Player("Blacklock", 0.266, 0.401, 591));
            players.Add(new Player("Young", 0.314, 0.459, 691));
            players.Add(new Player("Teixeira", 0.282, 0.514, 628));
            players.Add(new Player("Kinsler", 0.286, 0.454, 423));
            players.Add(new Player("Morgan", 0.166, 0.101, 191));
            players.Add(new Player("McGraier", 0.214, 0.401, 601));
            players.Add(new Player("Peraz", 0.482, 0.614, 728));
            players.Add(new Player("Rose", 0.486, 0.754, 2021));
            // The generic collection is not dirty at load.
            players.IsDirty = false;
            // Bind the generic collection to the grid.
            BindData();
        }
         
        private void BindData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = players;
            //  the following code hides columns in the grid you do not want the user to see.
            dataGridView1.Columns["IsDirty"].Visible = false;
            dataGridView1.Columns["IsNew"].Visible = false;
            dataGridView1.Columns["IsDeleted"].Visible = false;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// Bring up the about dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAbout_Click(object sender, RoutedEventArgs e)
        {
            AbtCol my411 = new AbtCol("Collection Handler routine");
            my411.ShowDialog();
        }
        /// <summary>
        /// That's all folks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            if (optSortAtBats.IsChecked == true)
            {
                if (rbtAscending.IsChecked == true)
                    players.Sort("AtBats", ListSortDirection.Ascending);
                else
                    players.Sort("AtBats", ListSortDirection.Descending);
            }
            else if (optSortAverage.IsChecked == true)
            {
                if (rbtAscending.IsChecked == true)
                    players.Sort("Average", ListSortDirection.Ascending);
                else
                    players.Sort("Average", ListSortDirection.Descending);
            }
            else if (optSortLastName.IsChecked == true)
            {
                if (rbtAscending.IsChecked == true)
                    players.Sort("LastName", ListSortDirection.Ascending);
                else
                    players.Sort("LastName", ListSortDirection.Descending);
            }
            else if (optSortSlugging.IsChecked == true)
            {
                if (rbtAscending.IsChecked == true)
                    players.Sort("SluggingPercentage", ListSortDirection.Ascending);
                else
                    players.Sort("SluggingPercentage", ListSortDirection.Descending);
            }

            BindData();
        }

        private void btnResetList_Click(object sender, RoutedEventArgs e)
        {
            players.Reset();
            BindData();
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            Player ply = new Player("Fergus", .326, .654, 600);
            ply.IsNew = true;
            players.Add(ply);
            BindData();
        }

        private void btnDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                Player curItem = dataGridView1.SelectedRows[0].DataBoundItem as Player;
                if (curItem != null)
                {
                    curItem.IsDeleted = true;
                    players.Remove(curItem);
                    BindData();
                }
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                Player curItem = dataGridView1.SelectedRows[0].DataBoundItem as Player;
                if (curItem != null)
                {
                    curItem.AtBats += 10;
                    curItem.Average += .010;
                    BindData();
                }
            }
        }

        private void btnFindPlayer_Click(object sender, RoutedEventArgs e)
        {
            FindPropFrm myFind = new FindPropFrm(players);
            myFind.ShowDialog();
        }

    }
}
