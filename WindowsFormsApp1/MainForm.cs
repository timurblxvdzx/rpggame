using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Models;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        Getting getting = new Getting();
        public MainForm()
        {
            InitializeComponent();
            TypeComboBox.Items.AddRange(new []{"Warrior", "Elf", "Gnome", "Wizard"});
            ArmorComboBox.Items.AddRange(getting.Armors.Select(x=>x.Name).ToArray());
            WeaponComboBox.Items.AddRange(getting.Weapons.Select(x => x.Name).ToArray());
            MoneyTextBox.Text = Convert.ToString(100);
        }

        private void TypeComboBox_StyleChanged(object sender, EventArgs e)
        {
            WeaponComboBox.Items.Clear();

            WeaponComboBox.Items.AddRange(getting.Weapons.Where(x => x.Type == ArmorComboBox.SelectedItem.ToString())
                .Select(x => x.Name).ToArray());
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WeaponComboBox.Items.Clear();
            ArmorComboBox.Items.Clear();
            
            ArmorComboBox.Items.AddRange(getting.Armors.Where(x => x.UnitType==TypeComboBox.SelectedItem).Select(x=>x.Name).ToArray());

            WeaponComboBox.Items.AddRange(getting.Weapons.Where(x => x.UnitType == TypeComboBox.SelectedItem).Select(x => x.Name).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var b = getting.Armors.Select(x => x.Name).ToList();
            var a = getting.Armors.Find(x => x.Name == ArmorComboBox.SelectedItem.ToString());
            var cost = getting.Armors.Find(x => x.Name == ArmorComboBox.SelectedItem.ToString()).Cost +
                getting.Weapons.Find(x => x.Name == WeaponComboBox.SelectedItem.ToString()).Cost;

            if (Convert.ToInt32(MoneyTextBox.Text) > cost)
            {
                Unit unit = new Unit();
                unit.Type = TypeComboBox.SelectedText;
                unit.Name = NameTextBox.Text;
                unit.Armor = new Armor
                {
                    Name = ArmorComboBox.SelectedText,
                    Cost = 0,
                    UnitType = TypeComboBox.SelectedText
                };
                unit.Weapon = new Weapon
                {
                    Name = WeaponComboBox.SelectedText,
                    Cost = 0,
                    Type = "",
                    UnitType = TypeComboBox.SelectedText
                };
                getting.Create(unit);
                MessageBox.Show("Created!");
            }
            else
            {
                MessageBox.Show("Not enough money!");
            }
        }
    }
}
