using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Fase3JavierGarcia.Services
{
    public static class UserDataService
    {
        public static bool IsValidNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d*$");
        }

        public static bool IsValidAlphabetic(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z\s]*$");
        }

        public static bool ValidateAllFields(ComboBox comboBox1, TextBox textBox2, TextBox textBox1, TextBox textBox3, ComboBox comboBox2, RadioButton radioButton1, RadioButton radioButton2, ComboBox comboBox3)
        {
            return comboBox1.SelectedItem != null &&
                   !string.IsNullOrWhiteSpace(textBox2.Text) &&
                   !string.IsNullOrWhiteSpace(textBox1.Text) &&
                   !string.IsNullOrWhiteSpace(textBox3.Text) &&
                   comboBox2.SelectedItem != null &&
                   (radioButton1.Checked || radioButton2.Checked) &&
                   comboBox3.SelectedItem != null;
        }
    }
}
