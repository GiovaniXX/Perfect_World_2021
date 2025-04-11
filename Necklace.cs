using System;
using System.IO;
using System.Windows.Forms;

namespace Perfect_World_2021
{
    internal class Necklace
    {
        private const string IconDirectory = @"E:\Projetos Csharp\Perfect_World_2021\icons";

        public void UpdateGeneralTab(string subType, string itemName, Label labelSubType, Label labelItemName, PictureBox pictureBoxIcon)
        {
            // Atualiza os labels com os valores selecionados
            labelSubType.Text = subType;
            labelItemName.Text = itemName;

            // Carrega o ícone correspondente ao item
            string iconPath = Path.Combine(IconDirectory, $"{itemName}.png");
            if (File.Exists(iconPath))
            {
                pictureBoxIcon.Image = System.Drawing.Image.FromFile(iconPath);
            }
            else
            {
                // Caso o ícone não seja encontrado, limpa a imagem ou exibe um ícone padrão
                pictureBoxIcon.Image = null;
            }
        }
    }
}