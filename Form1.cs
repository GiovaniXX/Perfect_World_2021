using System;
using System.Linq;
using System.Windows.Forms;

namespace Perfect_World_2021
{
    public partial class Form1_pwe_2021 : Form
    {
        public Form1_pwe_2021()
        {
            InitializeComponent();
        }

        private void button4_armor_add_Click(object sender, EventArgs e)
        {
            // Verificar se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(comboBox2_armor_bonus_list.Text) ||
                string.IsNullOrWhiteSpace(textBox2_armor_bonus_list_bonus.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construir o item a ser adicionado
            string item = $"{comboBox2_armor_bonus_list.Text} {textBox2_armor_bonus_list_bonus.Text}";

            // Adicionar o item ao TextBox
            textBox1_armor_bonus_list.AppendText(item + Environment.NewLine);
        }

        private void button3_armor_dell_Click(object sender, EventArgs e)
        {
            // Obter todas as linhas do TextBox
            string[] lines = textBox1_armor_bonus_list.Lines;

            // Verificar se há texto selecionado
            int selectionStart = textBox1_armor_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_armor_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verificar se a linha selecionada é válida
            if (currentLineIndex >= 0 && currentLineIndex < lines.Length)
            {
                // Criar uma nova lista sem a linha selecionada
                var updatedLines = lines.Where((line, index) => index != currentLineIndex).ToArray();

                // Atualizar o TextBox com as linhas restantes
                textBox1_armor_bonus_list.Lines = updatedLines;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_armor_down_Click(object sender, EventArgs e)
        {
            // Obter o texto completo do TextBox
            string[] lines = textBox1_armor_bonus_list.Lines;

            // Verificar se há texto selecionado
            int selectionStart = textBox1_armor_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_armor_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verificar se a linha selecionada não é a última
            if (currentLineIndex < lines.Length - 1)
            {
                // Trocar a linha atual com a linha abaixo
                string temp = lines[currentLineIndex];
                lines[currentLineIndex] = lines[currentLineIndex + 1];
                lines[currentLineIndex + 1] = temp;

                // Atualizar o TextBox com as linhas modificadas
                textBox1_armor_bonus_list.Lines = lines;

                // Reposicionar o cursor na nova posição da linha movida
                int newSelectionStart = textBox1_armor_bonus_list.GetFirstCharIndexFromLine(currentLineIndex + 1);
                textBox1_armor_bonus_list.SelectionStart = newSelectionStart;
                textBox1_armor_bonus_list.SelectionLength = temp.Length;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para está ação.!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_armor_up_Click(object sender, EventArgs e)
        {
            // Obter o texto completo do TextBox
            string[] lines = textBox1_armor_bonus_list.Lines;

            // Verificar se há texto selecionado
            int selectionStart = textBox1_armor_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_armor_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verificar se a linha selecionada não é a primeira
            if (currentLineIndex > 0)
            {
                // Trocar a linha atual com a linha acima
                string temp = lines[currentLineIndex];
                lines[currentLineIndex] = lines[currentLineIndex - 1];
                lines[currentLineIndex - 1] = temp;

                // Atualizar o TextBox com as linhas modificadas
                textBox1_armor_bonus_list.Lines = lines;

                // Reposicionar o cursor na nova posição da linha movida
                int newSelectionStart = textBox1_armor_bonus_list.GetFirstCharIndexFromLine(currentLineIndex - 1);
                textBox1_armor_bonus_list.SelectionStart = newSelectionStart;
                textBox1_armor_bonus_list.SelectionLength = temp.Length;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para está ação.!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}