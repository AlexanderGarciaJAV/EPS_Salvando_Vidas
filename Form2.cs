using Fase3JavierGarcia.Generators;
using Fase3JavierGarcia.Managers;
using Fase3JavierGarcia.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Fase3JavierGarcia
{
    public partial class Form2 : Form
    {
        private readonly UserDataManager _userDataManager;
        private readonly DataGridViewManager _dataGridViewManager;
        private readonly ReportGenerator _reportGenerator;

        public Form2()
        {
            InitializeComponent();
            _userDataManager = new UserDataManager();
            _dataGridViewManager = new DataGridViewManager(dataGridView1, dataGridView2, dataGridView3);
            _reportGenerator = new ReportGenerator();
            SetInitialState();
        }

        private void SetInitialState()
        {
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Valida que el texto contenga solo dígitos.
            string filteredText = string.Concat(textBox2.Text.Where(char.IsDigit));
            if (textBox2.Text != filteredText)
            {
                textBox2.Text = filteredText;
                // Coloca el cursor al final para una mejor experiencia de usuario.
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!UserDataService.IsValidAlphabetic(textBox1.Text))
            {
                textBox1.Text = string.Concat(textBox1.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Valida que el texto contenga solo dígitos.
            string filteredText = string.Concat(textBox3.Text.Where(char.IsDigit));
            if (textBox3.Text != filteredText)
            {
                textBox3.Text = filteredText;
                // Coloca el cursor al final para una mejor experiencia de usuario.
                textBox3.SelectionStart = textBox3.Text.Length;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) => UpdateCopagoDisplay();
        private void radioButton1_CheckedChanged(object sender, EventArgs e) => UpdateCopagoDisplay();
        private void radioButton2_CheckedChanged(object sender, EventArgs e) => UpdateCopagoDisplay();

        private void UpdateCopagoDisplay()
        {
            if (comboBox2.SelectedItem == null || (!radioButton1.Checked && !radioButton2.Checked))
            {
                textBox4.Clear();
                return;
            }

            int estrato = int.Parse(comboBox2.SelectedItem.ToString());
            ICopagoCalculator calculator;

            if (radioButton1.Checked)
            {
                calculator = new GeneralMedicineCopagoCalculator();
            }
            else
            {
                calculator = new LaboratoryCopagoCalculator();
            }

            decimal copago = calculator.CalculateCopago(estrato);
            textBox4.Text = $"${copago:N0}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!UserDataService.ValidateAllFields(comboBox1, textBox2, textBox1, textBox3, comboBox2, radioButton1, radioButton2, comboBox3))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar si la edad es un número entero.
            if (!int.TryParse(textBox3.Text, out int edad))
            {
                MessageBox.Show("El campo 'Edad' debe ser un número entero válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar si el número de identificación es un número entero.
            if (!int.TryParse(textBox2.Text, out int numeroIdentificacion))
            {
                MessageBox.Show("El campo 'Número de identificación' debe ser un número entero válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nuevoUsuario = new EstructuraDatosUsuario
            {
                TipoIdentificacion = comboBox1.SelectedItem.ToString(),
                NumeroIdentificacion = textBox2.Text,
                NombreCompleto = textBox1.Text,
                Edad = edad,
                Estrato = int.Parse(comboBox2.SelectedItem.ToString()),
                TipoAtencion = radioButton1.Checked ? "medicina general" : "examen laboratorio",
                FechaRegistro = dateTimePicker1.Value,
                ValorCopago = GetCalculatedCopagoValue()
            };

            AddUserToSelectedStructure(nuevoUsuario);
            _dataGridViewManager.UpdateGrids(_userDataManager.PilaUsuarios, _userDataManager.ColaUsuarios, _userDataManager.ListaUsuarios);
            LimpiarCampos();
        }

        private decimal GetCalculatedCopagoValue()
        {
            int estrato = int.Parse(comboBox2.SelectedItem.ToString());
            ICopagoCalculator calculator;
            if (radioButton1.Checked)
            {
                calculator = new GeneralMedicineCopagoCalculator();
            }
            else
            {
                calculator = new LaboratoryCopagoCalculator();
            }
            return calculator.CalculateCopago(estrato);
        }
        
        private void AddUserToSelectedStructure(EstructuraDatosUsuario user)
        {
            string selectedStructure = comboBox3.SelectedItem.ToString();
            switch (selectedStructure)
            {
                case "Pila":
                    _userDataManager.AddUserToStack(user);
                    break;
                case "Cola":
                    _userDataManager.AddUserToQueue(user);
                    break;
                case "Lista":
                    _userDataManager.AddUserToList(user);
                    break;
            }
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e) => LimpiarCampos();

        private void button4_Click(object sender, EventArgs e) => _reportGenerator.GeneratePilaReport(_userDataManager.PilaUsuarios, textBox5);
        private void button7_Click(object sender, EventArgs e) => _reportGenerator.GenerateColaReport(_userDataManager.ColaUsuarios, textBox5);
        private void button9_Click(object sender, EventArgs e) => _reportGenerator.GenerateListaReport(_userDataManager.ListaUsuarios, textBox5);

        private void button5_Click(object sender, EventArgs e)
        {
            if (_userDataManager.PilaUsuarios.Any())
            {
                if (MessageBox.Show("¿Estás seguro de que deseas borrar el último registro de la pila?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _userDataManager.PopUserFromStack();
                    _dataGridViewManager.UpdateGrids(_userDataManager.PilaUsuarios, _userDataManager.ColaUsuarios, _userDataManager.ListaUsuarios);
                    MessageBox.Show("Registro eliminado de la pila.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay registros en la pila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_userDataManager.ColaUsuarios.Any())
            {
                if (MessageBox.Show("¿Estás seguro de que deseas borrar el primer registro de la cola?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _userDataManager.DequeueUserFromQueue();
                    _dataGridViewManager.UpdateGrids(_userDataManager.PilaUsuarios, _userDataManager.ColaUsuarios, _userDataManager.ListaUsuarios);
                    MessageBox.Show("Registro eliminado de la cola.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay registros en la cola para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (_userDataManager.ListaUsuarios.Any())
            {
                if (MessageBox.Show("¿Estás seguro de que deseas borrar el último registro de la lista?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _userDataManager.RemoveUserFromList(_userDataManager.ListaUsuarios.Count - 1);
                    _dataGridViewManager.UpdateGrids(_userDataManager.PilaUsuarios, _userDataManager.ColaUsuarios, _userDataManager.ListaUsuarios);
                    MessageBox.Show("Registro eliminado de la lista.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay registros en la lista para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _reportGenerator.ExportAllReportsToExcel(_userDataManager.PilaUsuarios, _userDataManager.ColaUsuarios, _userDataManager.ListaUsuarios);
        }

    }
}