using Fase3JavierGarcia.Factories;
using Fase3JavierGarcia.Services;
using System;
using System.Windows.Forms;

namespace Fase3JavierGarcia
{
    public partial class Form1 : Form
    {
        private readonly AuthService _authService;

        public Form1()
        {
            InitializeComponent();
            _authService = new AuthService();
            SetInitialState();
        }

        private void SetInitialState()
        {
            textBox1.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Confirmación de salida
            HandleExitConfirmation();
        }

        private void HandleExitConfirmation()
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ProcessPasswordInput();
        }

        private void ProcessPasswordInput()
        {
            textBox1.PasswordChar = '*';
            int cursorPosition = textBox1.SelectionStart;

            string lettersOnly = FilterLetters(textBox1.Text);

            textBox1.Text = lettersOnly;
            textBox1.SelectionStart = cursorPosition > textBox1.Text.Length ? textBox1.Text.Length : cursorPosition;
        }

        private string FilterLetters(string input)
        {
            string lettersOnly = "";
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    lettersOnly += c;
                }
            }
            return lettersOnly;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutMessage();
        }

        private void ShowAboutMessage()
        {
            string message = AboutMessageFactory.CreateMessage("EPS Salvando vidas: Somos una EPS que cuida tu bienestar", "+57 3155055971", "Javier Alexander Garcia Mariño");
            MessageBox.Show(message, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iniDeSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableLoginFields();
        }

        private void EnableLoginFields()
        {
            textBox1.Enabled = true;
            button2.Enabled = true;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_authService.Authenticate(textBox1.Text))
            {
                OpenNewForm();
            }
            else
            {
                ShowAuthenticationError();
            }
        }

        private void OpenNewForm()
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void ShowAuthenticationError()
        {
            MessageBox.Show("Lo sentimos, la contraseña ingresada es incorrecta. Por favor, inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }
    }
}