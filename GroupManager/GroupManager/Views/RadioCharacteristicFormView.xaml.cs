using GroupManager.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupManager.Views
{
    /// <summary>
    /// Interaction logic for RadioCharacteristicFormView.xaml
    /// </summary>
    public partial class RadioCharacteristicFormView : UserControl
    {
        public RadioCharacteristicFormView()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var check=sender as CheckBox;
           
            var dt = (DataContext as RadioCharacteristicFormViewModel);
            dt.CharacteristicModel.StudentRecomendations.Add(check.Content.ToString());
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;

            var dt = (DataContext as RadioCharacteristicFormViewModel);
            dt.CharacteristicModel.StudentRecomendations.Remove(check.Content.ToString());
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var check = sender as RadioButton;

            var dt = (DataContext as RadioCharacteristicFormViewModel);
            dt.CharacteristicModel.PhysicalCharacteristic="Фізично "+check.Content.ToString();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            var check = sender as RadioButton;

            var dt = (DataContext as RadioCharacteristicFormViewModel);
            string str= check.Content.ToString();
            if (str == "присутнє")
            {
                dt.CharacteristicModel.Collective = "Підтримує дружні стосунки із студентами групи, має друзів";
                dt.CharacteristicModel.IsGoodStudent = true;
            }
            else
            {
                dt.CharacteristicModel.Collective = "Не підтримує дружні стосунки із студентами групи, не має друзів";
                dt.CharacteristicModel.IsGoodStudent= false;
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            var dt = (DataContext as RadioCharacteristicFormViewModel);
            string str = radio.Content.ToString();
            if (str == "адекватна")
            {
                dt.CharacteristicModel.Behavior = "До навчання ставиться спокійно, вчиться на добре, хоча може краще.";
                dt.CharacteristicModel.IsGoodStudent = true;
            }
            else
            {
                dt.CharacteristicModel.Behavior = "Має проблеми у судженнях,неадекватно реагує на зауваження";
                dt.CharacteristicModel.IsGoodStudent = false;

            }

        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            var dt = (DataContext as RadioCharacteristicFormViewModel);
            string str = radio.Content.ToString();
            if (str == "є")
            {
                dt.CharacteristicModel.PoliceSituations = "Мав приводи у поліцію";
                dt.CharacteristicModel.IsGoodStudent = false;
            }
            else
            {
                dt.CharacteristicModel.IsGoodStudent = true;
                dt.CharacteristicModel.PoliceSituations = "";
            }
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            var dt = (DataContext as RadioCharacteristicFormViewModel);
            string str = radio.Content.ToString();
            if (str == "мав")
            {
                dt.CharacteristicModel.LawAndOrderViolations = "За час навчання в коледжі доган порушення внутрішнього розпорядку";
                dt.CharacteristicModel.IsGoodStudent = false;
            }
            else
            {
                dt.CharacteristicModel.LawAndOrderViolations = "";
                dt.CharacteristicModel.IsGoodStudent = true;

            }
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            var dt = (DataContext as RadioCharacteristicFormViewModel);
            string str = radio.Content.ToString();
            if (str == "схильний")
            {
                dt.CharacteristicModel.AlchogolSituations = "Схільний до зловживання алкоголем, наркотичних речовин та девіантної поведінки";
                dt.CharacteristicModel.IsGoodStudent = false;
            }
            else
            {
                dt.CharacteristicModel.AlchogolSituations = "";
                dt.CharacteristicModel.IsGoodStudent = true;
            }
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            var dt = (DataContext as RadioCharacteristicFormViewModel);
            string str = radio.Content.ToString();
            if (str == "посередньо")
            {
                dt.CharacteristicModel.ReadyToArmy = "До служби в Збройних силах України відноситься посередньо";
            }
            else if (str == "негативно")
            {
                dt.CharacteristicModel.ReadyToArmy = "До служби в Збройних силах України відноситься негативно";
            }
            else if (str == "неохоче")
            {
                dt.CharacteristicModel.ReadyToArmy = "До служби в Збройних силах України відноситься неохоче";
            }
            else if (str == "позитивно")
            {
                dt.CharacteristicModel.ReadyToArmy = "До служби в Збройних силах України відноситься позитивно";
            }
        }
    }
}
