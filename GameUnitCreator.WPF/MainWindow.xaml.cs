using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameUnitCreator.WPF.ViewModel;

namespace GameUnitCreator.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MainViewModel)DataContext).MatchedArmors.Clear();
            ((MainViewModel)DataContext).MatchedWeapons.Clear();

            var marm = ((MainViewModel)DataContext).Armors.Where(x => x.UnitType == TypeComboBox.SelectedItem.ToString());
            foreach (var arm in marm)
            {
                ((MainViewModel)DataContext).MatchedArmors.Add(arm);
            }

            var mweap = ((MainViewModel)DataContext).Weapons.Where(x => x.UnitType == TypeComboBox.SelectedItem.ToString());
            foreach (var weap in mweap)
            {
                ((MainViewModel)DataContext).MatchedWeapons.Add(weap);
            }
        }
    }

}
