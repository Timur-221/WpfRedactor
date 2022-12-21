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
using WpfRedactor.Class;
using WpfRedactor.MD;
using MongoDB.Driver;
using System.Threading;

namespace WpfRedactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MonD mongo { get; set; }

        Unit unit { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            mongo = new MonD();
            DataName.ItemsSource = mongo.FindAll().ToList();
        }

        private void UnitChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (UnitChoice.SelectedIndex)
            {
                case 0:
                    Strength.Minimum = 30;
                    Strength.Maximum = 250;
                    unit = new Warrior();
                    break;

                case 1:
                    Strength.Minimum = 10;
                    Strength.Maximum = 45;
                    unit = new Wizard();
                    break;

                case 2:
                    Strength.Minimum = 15;
                    Strength.Maximum = 55;
                    unit = new Rouge();
                    break;
            }
        }

        private void SaveDB_Click(object sender, RoutedEventArgs e)
        {
            int strength = Convert.ToInt32(Strength.Value);

            switch (UnitChoice.SelectedIndex)
            {
                case 0:

                    unit.name = NameUnit.Text;
                    unit.health = (strength * 2);
                    unit.damage = (strength * 5);
                    MessageBox.Show($" Name - {unit.name} {"\n"} Health - {unit.health} {"\n"} Damage - {unit.damage}");
                    mongo.AddUser(unit);
                    NameUnit.Text = string.Empty;
                    break;

                case 1:

                    unit.name = NameUnit.Text;
                    unit.health = strength;
                    unit.damage = strength * 3;
                    MessageBox.Show($" Name - {unit.name} {"\n"} Health - {unit.health} {"\n"} Damage - {unit.damage}");
                    mongo.AddUser(unit);
                    NameUnit.Text = string.Empty;
                    break;

                case 2:

                    unit.name = NameUnit.Text;
                    unit.health = strength;
                    unit.damage = (strength * 2);
                    MessageBox.Show($" Name - {unit.name} {"\n"} Health - {unit.health} {"\n"} Damage - {unit.damage}");
                    mongo.AddUser(unit);
                    NameUnit.Text = string.Empty;
                    break;
            }
            DataName.ItemsSource = mongo.FindAll().ToList();
        }

        private void DataName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit unit = DataName.SelectedItem as Unit;

            if (unit is Warrior)
            {
                var warrior = unit as Warrior;
                NameUnit.Text = warrior.name;
                UnitChoice.SelectedIndex = 0;
            }
            else if (unit is Wizard)
            {
                var wizard = unit as Wizard;
                NameUnit.Text = wizard.name;
                UnitChoice.SelectedIndex = 1;
            }
            else if (unit is Rouge)
            {
                var rouge = unit as Rouge;
                NameUnit.Text = rouge.name;
                UnitChoice.SelectedIndex = 2;
            }
        }

        private void FindUn_Click(object sender, RoutedEventArgs e)
        {
            mongo.Find(FindUnit.Text);
            FindUnit.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int strength = Convert.ToInt32(Strength.Value);
            var client = new MongoClient();
            var database = client.GetDatabase("WpfRedactor");
            var collection = database.GetCollection<Unit>("WpfHeroes");
            switch (UnitChoice.SelectedIndex)
            {
                case 0:
                    var warrior = unit as Warrior;
                    warrior.name = NameUnit.Text;
                    warrior.health = (strength * 2);
                    warrior.damage = (strength * 5);
                    collection.ReplaceOne(x => x.name == unit.name, warrior);
                    break;

                case 1:
                    var wizard = unit as Wizard;
                    wizard.name = NameUnit.Text;
                    wizard.health = strength;
                    wizard.damage = strength * 3;
                    collection.ReplaceOne(x => x.name == unit.name, wizard);
                    break;

                case 2:
                    var rouge = unit as Rouge;
                    rouge.name = NameUnit.Text;
                    rouge.health = strength;
                    rouge.damage = (strength * 2);
                    collection.ReplaceOne(x => x.name == NameUnit.Text, rouge);
                    break;
            }
          
           

        }
    }
}
