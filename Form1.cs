using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Perfect_World_2021
{
    public partial class Form1_pwe_2021 : Form
    {
        public Form1_pwe_2021()
        {
            InitializeComponent();
            LoadWeaponItems();
            LoadArmorItems();
            LoadAccessoryItems();

            // Adiciona os eventos para carregar subtipos, itens e ícones
            // Weapon
            comboBox3_weapon_itens_type.SelectedIndexChanged += ComboBox3_weapon_itens_type_SelectedIndexChanged;
            comboBox4_weapon_itens_sub_type.SelectedIndexChanged += ComboBox4_weapon_itens_sub_type_SelectedIndexChanged;
            comboBox5_weapon_itens_item_name.SelectedIndexChanged += ComboBox5_weapon_itens_item_name_SelectedIndexChanged;

            // Armor
            comboBox3_armor_itens_type.SelectedIndexChanged += ComboBox3_armor_itens_type_SelectedIndexChanged;
            comboBox4_armor_itens_sub_type.SelectedIndexChanged += ComboBox4_armor_itens_sub_type_SelectedIndexChanged;
            comboBox5_armor_itens_item_name.SelectedIndexChanged += ComboBox5_armor_itens_item_name_SelectedIndexChanged;

            // Accessory
            comboBox3_accessory_itens_type.SelectedIndexChanged += ComboBox3_accessory_itens_type_SelectedIndexChanged;
            comboBox4_accessory_itens_sub_type.SelectedIndexChanged += ComboBox4_accessory_itens_sub_type_SelectedIndexChanged;
            comboBox5_accessory_itens_item_name.SelectedIndexChanged += ComboBox5_accessory_itens_item_name_SelectedIndexChanged;

            // Adiciona o evento KeyPress para validar apenas números
            textBox2_weapon_bonus_list_bonus.KeyPress += TextBox2_weapon_bonus_list_bonus_KeyPress;
        }

        private void button4_armor_add_Click(object sender, EventArgs e)
        {
            // Verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(comboBox2_armor_bonus_list.Text) ||
                string.IsNullOrWhiteSpace(textBox2_armor_bonus_list_bonus.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Constroi o item a ser adicionado
            string item = $"{comboBox2_armor_bonus_list.Text} {textBox2_armor_bonus_list_bonus.Text}";

            // Adiciona o item ao TextBox
            textBox1_armor_bonus_list.AppendText(item + Environment.NewLine);
        }

        private void button3_armor_dell_Click(object sender, EventArgs e)
        {
            // Obtem todas as linhas do TextBox
            string[] lines = textBox1_armor_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_armor_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_armor_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada é válida
            if (currentLineIndex >= 0 && currentLineIndex < lines.Length)
            {
                // Cria uma nova lista sem a linha selecionada
                var updatedLines = lines.Where((line, index) => index != currentLineIndex).ToArray();

                // Atualiza o TextBox com as linhas restantes
                textBox1_armor_bonus_list.Lines = updatedLines;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_armor_down_Click(object sender, EventArgs e)
        {
            // Obtem o texto completo do TextBox
            string[] lines = textBox1_armor_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_armor_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_armor_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada não é a última
            if (currentLineIndex < lines.Length - 1)
            {
                // Troca a linha atual com a linha abaixo
                string temp = lines[currentLineIndex];
                lines[currentLineIndex] = lines[currentLineIndex + 1];
                lines[currentLineIndex + 1] = temp;

                // Atualiza o TextBox com as linhas modificadas
                textBox1_armor_bonus_list.Lines = lines;

                // Reposiciona o cursor na nova posição da linha movida
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
            // Obtem o texto completo do TextBox
            string[] lines = textBox1_armor_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_armor_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_armor_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada não é a primeira
            if (currentLineIndex > 0)
            {
                // Troca a linha atual com a linha acima
                string temp = lines[currentLineIndex];
                lines[currentLineIndex] = lines[currentLineIndex - 1];
                lines[currentLineIndex - 1] = temp;

                // Atualiza o TextBox com as linhas modificadas
                textBox1_armor_bonus_list.Lines = lines;

                // Reposiciona o cursor na nova posição da linha movida
                int newSelectionStart = textBox1_armor_bonus_list.GetFirstCharIndexFromLine(currentLineIndex - 1);
                textBox1_armor_bonus_list.SelectionStart = newSelectionStart;
                textBox1_armor_bonus_list.SelectionLength = temp.Length;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para está ação.!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_weapon_add_Click(object sender, EventArgs e)
        {
            // Verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(comboBox2_weapon_bonus_list.Text) ||
                string.IsNullOrWhiteSpace(textBox2_weapon_bonus_list_bonus.Text))
            {
                MessageBox.Show("Preencha todos os campos do Bonus List antes de adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Constroi o item a ser adicionado
            string item = $"{comboBox2_weapon_bonus_list.Text} {textBox2_weapon_bonus_list_bonus.Text}";

            // Adiciona o item ao TextBox
            textBox1_weapon_bonus_list.AppendText(item + Environment.NewLine);
        }

        private void TextBox2_weapon_bonus_list_bonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e a tecla Backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada de caracteres inválidos
            }
        }

        private void button3_weapon_dell_Click(object sender, EventArgs e)
        {
            // Obtem todas as linhas do TextBox
            string[] lines = textBox1_weapon_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_weapon_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_weapon_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada é válida
            if (currentLineIndex >= 0 && currentLineIndex < lines.Length)
            {
                // Cria uma nova lista sem a linha selecionada
                var updatedLines = lines.Where((line, index) => index != currentLineIndex).ToArray();

                // Atualiza o TextBox com as linhas restantes
                textBox1_weapon_bonus_list.Lines = updatedLines;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_weapon_down_Click(object sender, EventArgs e)
        {
            // Obtem o texto completo do TextBox
            string[] lines = textBox1_weapon_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_weapon_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_weapon_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada não é a última
            if (currentLineIndex < lines.Length - 1)
            {
                // Troca a linha atual com a linha abaixo
                string temp = lines[currentLineIndex];
                lines[currentLineIndex] = lines[currentLineIndex + 1];
                lines[currentLineIndex + 1] = temp;

                // Atualiza o TextBox com as linhas modificadas
                textBox1_weapon_bonus_list.Lines = lines;

                // Reposiciona o cursor na nova posição da linha movida
                int newSelectionStart = textBox1_weapon_bonus_list.GetFirstCharIndexFromLine(currentLineIndex + 1);
                textBox1_weapon_bonus_list.SelectionStart = newSelectionStart;
                textBox1_weapon_bonus_list.SelectionLength = temp.Length;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para está ação.!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_weapon_up_Click(object sender, EventArgs e)
        {
            // Obtem o texto completo do TextBox
            string[] lines = textBox1_weapon_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_weapon_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_weapon_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada não é a primeira
            if (currentLineIndex > 0)
            {
                // Troca a linha atual com a linha acima
                string temp = lines[currentLineIndex];
                lines[currentLineIndex] = lines[currentLineIndex - 1];
                lines[currentLineIndex - 1] = temp;

                // Atualiza o TextBox com as linhas modificadas
                textBox1_weapon_bonus_list.Lines = lines;

                // Reposiciona o cursor na nova posição da linha movida
                int newSelectionStart = textBox1_weapon_bonus_list.GetFirstCharIndexFromLine(currentLineIndex - 1);
                textBox1_weapon_bonus_list.SelectionStart = newSelectionStart;
                textBox1_weapon_bonus_list.SelectionLength = temp.Length;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para está ação.!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_accessory_add_Click(object sender, EventArgs e)
        {
            // Verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(comboBox2_accessory_bonus_list.Text) ||
                string.IsNullOrWhiteSpace(textBox2_accessory_bonus_list_bonus.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Constroi o item a ser adicionado
            string item = $"{comboBox2_accessory_bonus_list.Text} {textBox2_accessory_bonus_list_bonus.Text}";

            // Adiciona o item ao TextBox
            textBox1_accessory_bonus_list.AppendText(item + Environment.NewLine);
        }

        private void button3_accessory_dell_Click(object sender, EventArgs e)
        {
            // Obtem todas as linhas do TextBox
            string[] lines = textBox1_accessory_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_accessory_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_accessory_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada é válida
            if (currentLineIndex >= 0 && currentLineIndex < lines.Length)
            {
                // Cria uma nova lista sem a linha selecionada
                var updatedLines = lines.Where((line, index) => index != currentLineIndex).ToArray();

                // Atualiza o TextBox com as linhas restantes
                textBox1_accessory_bonus_list.Lines = updatedLines;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_accessory_down_Click(object sender, EventArgs e)
        {
            // Obtem o texto completo do TextBox
            string[] lines = textBox1_accessory_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_accessory_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_accessory_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada não é a última
            if (currentLineIndex < lines.Length - 1)
            {
                // Troca a linha atual com a linha abaixo
                string temp = lines[currentLineIndex];
                lines[currentLineIndex] = lines[currentLineIndex + 1];
                lines[currentLineIndex + 1] = temp;

                // Atualiza o TextBox com as linhas modificadas
                textBox1_accessory_bonus_list.Lines = lines;

                // Reposiciona o cursor na nova posição da linha movida
                int newSelectionStart = textBox1_accessory_bonus_list.GetFirstCharIndexFromLine(currentLineIndex + 1);
                textBox1_accessory_bonus_list.SelectionStart = newSelectionStart;
                textBox1_accessory_bonus_list.SelectionLength = temp.Length;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para está ação.!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_accessory_up_Click(object sender, EventArgs e)
        {
            // Obtem o texto completo do TextBox
            string[] lines = textBox1_accessory_bonus_list.Lines;

            // Verifica se há texto selecionado
            int selectionStart = textBox1_accessory_bonus_list.SelectionStart;
            int currentLineIndex = textBox1_accessory_bonus_list.GetLineFromCharIndex(selectionStart);

            // Verifica se a linha selecionada não é a primeira
            if (currentLineIndex > 0)
            {
                // Troca a linha atual com a linha acima
                string temp = lines[currentLineIndex];
                lines[currentLineIndex] = lines[currentLineIndex - 1];
                lines[currentLineIndex - 1] = temp;

                // Atualiza o TextBox com as linhas modificadas
                textBox1_accessory_bonus_list.Lines = lines;

                // Reposiciona o cursor na nova posição da linha movida
                int newSelectionStart = textBox1_accessory_bonus_list.GetFirstCharIndexFromLine(currentLineIndex - 1);
                textBox1_accessory_bonus_list.SelectionStart = newSelectionStart;
                textBox1_accessory_bonus_list.SelectionLength = temp.Length;
            }
            else
            {
                MessageBox.Show("Nenhuma linha existente para está ação.!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnItemSelected(object sender, EventArgs e)
        {
            string selectedArmorSubType = comboBox4_armor_itens_sub_type.SelectedItem?.ToString() ?? string.Empty;
            string selectedArmorItemName = comboBox5_armor_itens_item_name.SelectedItem?.ToString() ?? string.Empty;

            string selectedWeaponSubType = comboBox4_weapon_itens_sub_type.SelectedItem?.ToString() ?? string.Empty;
            string selectedWeaponItemName = comboBox5_weapon_itens_item_name.SelectedItem?.ToString() ?? string.Empty;

            string selectedNecklaceSubType = comboBox4_accessory_itens_sub_type.SelectedItem?.ToString() ?? string.Empty;
            string selectedNecklaceItemName = comboBox5_accessory_itens_item_name.SelectedItem?.ToString() ?? string.Empty;

            Armor armor = new Armor();
            armor.UpdateGeneralTab(
                selectedArmorSubType,
                selectedArmorItemName,
                label17_general_armor_sub_type,
                label15_general_armor_item_name,
                pictureBox6
            );

            Weapon weapon = new Weapon();
            weapon.UpdateGeneralTab(
                selectedWeaponSubType,
                selectedWeaponItemName,
                label29_general_weapon_sub_type,
                label30_general_weapon_item_name,
                pictureBox1
            );

            Accessory necklace = new Accessory();
            necklace.UpdateGeneralTab(
                selectedNecklaceSubType,
                selectedNecklaceItemName,
                label1_general_accessory_sub_type,
                label2_general_accessory_item_name,
                pictureBox5
            );
        }

        private void button4_weapon_generate_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura os valores da interface
                if (!int.TryParse(textBox1_weapon_itens_itemID.Text, out int id))
                {
                    MessageBox.Show("O campo 'Item ID' deve conter um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox2_weapon_itens_prot.Text, out int pos))
                {
                    MessageBox.Show("O campo 'Posição' deve conter um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox3_weapon_itens_maker.Text, out int proctype))
                {
                    MessageBox.Show("O campo 'Maker' deve conter um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Valida e captura os valores para gerar o campo "data"
                if (!int.TryParse(textBox1_weapon_general_grade.Text, out int grade) ||
                    !int.TryParse(textBox2_weapon_general_freq.Text, out int freqAtq) ||
                    !int.TryParse(textBox3_weapon_general_atqRn.Text, out int atqRn) ||
                    !int.TryParse(textBox4_weapon_general_distFrag.Text, out int distFrag) ||
                    !int.TryParse(textBox10_weapon_general_dur_mm.Text, out int durMM) ||
                    !int.TryParse(textBox14_weapon_general_atqF_mm.Text, out int atqFMM) ||
                    !int.TryParse(textBox12_weapon_general_atqM_mm.Text, out int atqMMM) ||
                    !int.TryParse(textBox17_weapon_general_strReq.Text, out int strReq) ||
                    !int.TryParse(textBox18_weapon_general_conReq.Text, out int conReq) ||
                    !int.TryParse(textBox19_weapon_general_agiReq.Text, out int agiReq) ||
                    !int.TryParse(textBox20_weapon_general_intReq.Text, out int intReq))
                {
                    MessageBox.Show("Todos os campos numéricos devem conter valores válidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gera o valor de "data"
                string data = XmlGenerator.GenerateDataValue(grade, freqAtq, atqRn, distFrag, durMM, atqFMM, atqMMM, grade, strReq, conReq, agiReq, intReq);

                // Outros valores fixos ou capturados
                int count = 1;
                int maxCount = 1;
                int expireDate = 0;
                int guid1 = 0;
                int guid2 = 0;
                int mask = 1;

                // Gera o XML
                string xml = XmlGenerator.GenerateItemXml(id, pos, count, maxCount, data, proctype, expireDate, guid1, guid2, mask);

                // Exibi o XML gerado no TextBox
                textBox1_weapon_generate.Text = xml;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o XML: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_weapon_general_freq_TextChanged(object sender, EventArgs e)
        {
            // Captura o valor inserido no TextBox
            string input = textBox2_weapon_general_freq.Text;

            // Valida se o valor é um número
            if (int.TryParse(input, out int freqAtq))
            {
                if (freqAtq >= 1 && freqAtq <= 5)
                {
                    // Atualiza o texto da label com o valor formatado como decimal
                    label15_freq_atq.Text = $"{freqAtq}.0";
                }
                else if (freqAtq > 5)
                {
                    // Exibi mensagem informando que o valor máximo é 5
                    MessageBox.Show("Frequência de ataque somente até 5", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Ajusta o valor para 5
                    textBox2_weapon_general_freq.Text = "5";
                    textBox2_weapon_general_freq.SelectionStart = textBox2_weapon_general_freq.Text.Length; // Reposiciona o cursor
                }
                else
                {
                    // Exibi uma mensagem padrão ou limpar a label se o valor for inválido
                    label15_freq_atq.Text = "????";
                }
            }
            else if (!string.IsNullOrWhiteSpace(input)) // Verifica se o valor não é vazio
            {
                // Exibi mensagem informando que apenas números são aceitos
                MessageBox.Show("Somente números são aceitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Limpa o TextBox
                textBox2_weapon_general_freq.Clear();
            }
            else
            {
                // Limpa a label se o valor for vazio
                label15_freq_atq.Text = "????";
            }
        }

        private void button1_armor_clear_Click(object sender, EventArgs e)
        {
            // Limpa o conteúdo do TextBox
            textBox2_armor_bonus_list_bonus.Text = string.Empty;
        }

        private void button2_weapon_clear_Click(object sender, EventArgs e)
        {
            // Limpa o conteúdo do TextBox
            textBox2_weapon_bonus_list_bonus.Text = string.Empty;
        }

        private void button3_accessory_clear_Click(object sender, EventArgs e)
        {
            // Limpa o conteúdo do TextBox
            textBox2_accessory_bonus_list_bonus.Text = string.Empty;
        }

        private void button5_accessory_reset_Click(object sender, EventArgs e)
        {
            // Limpa o conteúdo do TextBox
            textBox1_accessory_generate.Clear();
        }

        private void button3_weapon_reset_Click(object sender, EventArgs e)
        {
            // Limpa o conteúdo do TextBox
            textBox1_weapon_generate.Clear();
        }

        private void button1_armor_reset_Click(object sender, EventArgs e)
        {
            // Limpa o conteúdo do TextBox
            textBox1_armor_generate.Clear();
        }

        // Weapon
        private void LoadWeaponItems()
        {
            string weaponItemsPath = @"E:\Projetos Csharp\Perfect_World_2021\items\Weapons";

            // Verifica se o diretório existe
            if (Directory.Exists(weaponItemsPath))
            {
                // Obtém todos os diretórios no caminho especificado
                string[] directories = Directory.GetDirectories(weaponItemsPath);

                // Limpa os itens existentes no ComboBox
                comboBox3_weapon_itens_type.Items.Clear();

                // Adiciona os nomes das pastas ao ComboBox
                foreach (string directory in directories)
                {
                    comboBox3_weapon_itens_type.Items.Add(Path.GetFileName(directory));
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox3_weapon_itens_type.Items.Count < 0)
                {
                    comboBox3_weapon_itens_type.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("O diretório especificado não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWeaponSubTypes(string selectedFolder)
        {
            string basePath = @"E:\Projetos Csharp\Perfect_World_2021\items\Weapons";
            string folderPath = Path.Combine(basePath, selectedFolder);

            // Verifica se a pasta selecionada existe
            if (Directory.Exists(folderPath))
            {
                // Obtém todas as subpastas
                string[] subDirectories = Directory.GetDirectories(folderPath);

                // Limpa os itens existentes no ComboBox
                comboBox4_weapon_itens_sub_type.Items.Clear();

                // Adiciona os nomes das subpastas ao ComboBox
                foreach (string subDirectory in subDirectories)
                {
                    comboBox4_weapon_itens_sub_type.Items.Add(Path.GetFileName(subDirectory));
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox4_weapon_itens_sub_type.Items.Count > 0)
                {
                    comboBox4_weapon_itens_sub_type.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("A pasta selecionada não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox3_weapon_itens_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox3_weapon_itens_type
            string selectedFolder = comboBox3_weapon_itens_type.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFolder))
            {
                LoadWeaponSubTypes(selectedFolder);
            }
        }

        private void LoadWeaponItemNames(string selectedSubType)
        {
            string basePath = @"E:\Projetos Csharp\Perfect_World_2021\items\Weapons";
            string subTypeFolderPath = Path.Combine(basePath, selectedSubType, selectedSubType);

            // Constrói o caminho do arquivo .txt
            string filePath = Path.Combine(subTypeFolderPath, selectedSubType + ".txt");

            // Verifica se o arquivo existe
            if (File.Exists(filePath))
            {
                // Lê todas as linhas do arquivo
                string[] itemNames = File.ReadAllLines(filePath);

                // Limpa os itens existentes no ComboBox
                comboBox5_weapon_itens_item_name.Items.Clear();

                // Adiciona os nomes dos itens ao ComboBox
                foreach (string itemName in itemNames)
                {
                    comboBox5_weapon_itens_item_name.Items.Add(itemName.Trim());
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox5_weapon_itens_item_name.Items.Count > 0)
                {
                    comboBox5_weapon_itens_item_name.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show($"O arquivo de itens para '{selectedSubType}' não foi encontrado no caminho esperado:\n{filePath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox4_weapon_itens_sub_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox4_weapon_itens_sub_type
            string selectedSubType = comboBox4_weapon_itens_sub_type.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedSubType))
            {
                LoadWeaponItemNames(selectedSubType);
            }
        }

        private void LoadWeaponIcon(string selectedItemName)
        {
            string iconsBasePath = @"E:\Projetos Csharp\Perfect_World_2021\items\icons";

            // Procura o arquivo de ícone recursivamente
            string[] iconFiles = Directory.GetFiles(iconsBasePath, selectedItemName + ".png", SearchOption.AllDirectories);

            if (iconFiles.Length > 0)
            {
                // Carrega o primeiro arquivo encontrado no PictureBox
                pictureBox1.Image = Image.FromFile(iconFiles[0]);
            }
            else
            {
                // Limpa o PictureBox se o ícone não for encontrado
                pictureBox1.Image = null;
                MessageBox.Show($"O ícone para o item '{selectedItemName}' não foi encontrado em nenhuma subpasta de:\n{iconsBasePath}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox5_weapon_itens_item_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox5_weapon_itens_item_name
            string selectedItemName = comboBox5_weapon_itens_item_name.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedItemName))
            {
                LoadWeaponIcon(selectedItemName);
            }
        }

        // Armor
        private void LoadArmorItems()
        {
            string armorItemsPath = @"E:\Projetos Csharp\Perfect_World_2021\items\Armors";

            // Verifica se o diretório existe
            if (Directory.Exists(armorItemsPath))
            {
                // Obtém todos os diretórios no caminho especificado
                string[] directories = Directory.GetDirectories(armorItemsPath);

                // Limpa os itens existentes no ComboBox
                comboBox3_armor_itens_type.Items.Clear();

                // Adiciona os nomes das pastas ao ComboBox
                foreach (string directory in directories)
                {
                    comboBox3_armor_itens_type.Items.Add(Path.GetFileName(directory));
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox3_armor_itens_type.Items.Count < 0)
                {
                    comboBox3_armor_itens_type.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("O diretório especificado não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadArmorSubTypes(string selectedFolder)
        {
            string basePath = @"E:\Projetos Csharp\Perfect_World_2021\items\Armors";
            string folderPath = Path.Combine(basePath, selectedFolder);

            // Verifica se a pasta selecionada existe
            if (Directory.Exists(folderPath))
            {
                // Obtém todas as subpastas
                string[] subDirectories = Directory.GetDirectories(folderPath);

                // Limpa os itens existentes no ComboBox
                comboBox4_armor_itens_sub_type.Items.Clear();

                // Adiciona os nomes das subpastas ao ComboBox
                foreach (string subDirectory in subDirectories)
                {
                    comboBox4_armor_itens_sub_type.Items.Add(Path.GetFileName(subDirectory));
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox4_armor_itens_sub_type.Items.Count > 0)
                {
                    comboBox4_armor_itens_sub_type.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("A pasta selecionada não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox3_armor_itens_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox3_weapon_itens_type
            string selectedFolder = comboBox3_armor_itens_type.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFolder))
            {
                LoadArmorSubTypes(selectedFolder);
            }
        }

        private void LoadArmorItemNames(string selectedSubType)
        {
            string basePath = @"E:\Projetos Csharp\Perfect_World_2021\items\Armors";
            string subTypeFolderPath = Path.Combine(basePath, selectedSubType, selectedSubType);

            // Constrói o caminho do arquivo .txt
            string filePath = Path.Combine(subTypeFolderPath, selectedSubType + ".txt");

            // Verifica se o arquivo existe
            if (File.Exists(filePath))
            {
                // Lê todas as linhas do arquivo
                string[] itemNames = File.ReadAllLines(filePath);

                // Limpa os itens existentes no ComboBox
                comboBox5_armor_itens_item_name.Items.Clear();

                // Adiciona os nomes dos itens ao ComboBox
                foreach (string itemName in itemNames)
                {
                    comboBox5_armor_itens_item_name.Items.Add(itemName.Trim());
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox5_armor_itens_item_name.Items.Count > 0)
                {
                    comboBox5_armor_itens_item_name.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show($"O arquivo de itens para '{selectedSubType}' não foi encontrado no caminho esperado:\n{filePath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox4_armor_itens_sub_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox4_weapon_itens_sub_type
            string selectedSubType = comboBox4_armor_itens_sub_type.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedSubType))
            {
                LoadArmorItemNames(selectedSubType);
            }
        }

        private void LoadArmorIcon(string selectedItemName)
        {
            string iconsBasePath = @"E:\Projetos Csharp\Perfect_World_2021\items\icons";

            // Procura o arquivo de ícone recursivamente
            string[] iconFiles = Directory.GetFiles(iconsBasePath, selectedItemName + ".png", SearchOption.AllDirectories);

            if (iconFiles.Length > 0)
            {
                // Carrega o primeiro arquivo encontrado no PictureBox
                pictureBox1.Image = Image.FromFile(iconFiles[0]);
            }
            else
            {
                // Limpa o PictureBox se o ícone não for encontrado
                pictureBox5.Image = null;
                MessageBox.Show($"O ícone para o item '{selectedItemName}' não foi encontrado em nenhuma subpasta de:\n{iconsBasePath}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox5_armor_itens_item_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox5_armor_itens_item_name
            string selectedItemName = comboBox5_armor_itens_item_name.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedItemName))
            {
                LoadArmorIcon(selectedItemName);
            }
        }

        // Accessory
        private void LoadAccessoryItems()
        {
            string accessoryItemsPath = @"E:\Projetos Csharp\Perfect_World_2021\items\Accessory";

            // Verifica se o diretório existe
            if (Directory.Exists(accessoryItemsPath))
            {
                // Obtém todos os diretórios no caminho especificado
                string[] directories = Directory.GetDirectories(accessoryItemsPath);

                // Limpa os itens existentes no ComboBox
                comboBox3_accessory_itens_type.Items.Clear();

                // Adiciona os nomes das pastas ao ComboBox
                foreach (string directory in directories)
                {
                    comboBox3_accessory_itens_type.Items.Add(Path.GetFileName(directory));
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox3_accessory_itens_type.Items.Count < 0)
                {
                    comboBox3_accessory_itens_type.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("O diretório especificado não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccessorySubTypes(string selectedFolder)
        {
            string basePath = @"E:\Projetos Csharp\Perfect_World_2021\items\Accessory";
            string folderPath = Path.Combine(basePath, selectedFolder);

            // Verifica se a pasta selecionada existe
            if (Directory.Exists(folderPath))
            {
                // Obtém todas as subpastas
                string[] subDirectories = Directory.GetDirectories(folderPath);

                // Limpa os itens existentes no ComboBox
                comboBox4_accessory_itens_sub_type.Items.Clear();

                // Adiciona os nomes das subpastas ao ComboBox
                foreach (string subDirectory in subDirectories)
                {
                    comboBox4_accessory_itens_sub_type.Items.Add(Path.GetFileName(subDirectory));
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox4_accessory_itens_sub_type.Items.Count > 0)
                {
                    comboBox4_accessory_itens_sub_type.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("A pasta selecionada não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox3_accessory_itens_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox3_accessory_itens_type
            string selectedFolder = comboBox3_accessory_itens_type.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFolder))
            {
                LoadAccessorySubTypes(selectedFolder);
            }
        }

        private void LoadAccessoryItemNames(string selectedSubType)
        {
            string basePath = @"E:\Projetos Csharp\Perfect_World_2021\items\Accessory";
            string subTypeFolderPath = Path.Combine(basePath, selectedSubType, selectedSubType);

            // Constrói o caminho do arquivo .txt
            string filePath = Path.Combine(subTypeFolderPath, selectedSubType + ".txt");

            // Verifica se o arquivo existe
            if (File.Exists(filePath))
            {
                // Lê todas as linhas do arquivo
                string[] itemNames = File.ReadAllLines(filePath);

                // Limpa os itens existentes no ComboBox
                comboBox5_accessory_itens_item_name.Items.Clear();

                // Adiciona os nomes dos itens ao ComboBox
                foreach (string itemName in itemNames)
                {
                    comboBox5_accessory_itens_item_name.Items.Add(itemName.Trim());
                }

                // Define o primeiro item como selecionado, se houver itens
                if (comboBox5_accessory_itens_item_name.Items.Count > 0)
                {
                    comboBox5_accessory_itens_item_name.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show($"O arquivo de itens para '{selectedSubType}' não foi encontrado no caminho esperado:\n{filePath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox4_accessory_itens_sub_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox4_accessory_itens_sub_type
            string selectedSubType = comboBox4_accessory_itens_sub_type.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedSubType))
            {
                LoadAccessoryItemNames(selectedSubType);
            }
        }

        private void LoadAccessoryIcon(string selectedItemName)
        {
            string iconsBasePath = @"E:\Projetos Csharp\Perfect_World_2021\items\icons";

            // Procura o arquivo de ícone recursivamente
            string[] iconFiles = Directory.GetFiles(iconsBasePath, selectedItemName + ".png", SearchOption.AllDirectories);

            if (iconFiles.Length > 0)
            {
                // Carrega o primeiro arquivo encontrado no PictureBox
                pictureBox1.Image = Image.FromFile(iconFiles[0]);
            }
            else
            {
                // Limpa o PictureBox se o ícone não for encontrado
                pictureBox6.Image = null;
                MessageBox.Show($"O ícone para o item '{selectedItemName}' não foi encontrado em nenhuma subpasta de:\n{iconsBasePath}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox5_accessory_itens_item_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o item selecionado no comboBox5_accessory_itens_item_name
            string selectedItemName = comboBox5_accessory_itens_item_name.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedItemName))
            {
                LoadAccessoryIcon(selectedItemName);
            }
        }
    }
}