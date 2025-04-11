using System.Text;
using System.Xml.Linq;

namespace Perfect_World_2021
{
    public class XmlGenerator
    {
        public static string GenerateItemXml(
            int id, int pos, int count, int maxCount, string data, int proctype,
            int expireDate, int guid1, int guid2, int mask)
        {
            // Criação do XML usando LINQ to XML
            var itemElement = new XElement("items",
                new XElement("variable", new XAttribute("name", "id"), new XAttribute("type", "int"), id),
                new XElement("variable", new XAttribute("name", "pos"), new XAttribute("type", "int"), pos),
                new XElement("variable", new XAttribute("name", "count"), new XAttribute("type", "int"), count),
                new XElement("variable", new XAttribute("name", "max_count"), new XAttribute("type", "int"), maxCount),
                new XElement("variable", new XAttribute("name", "data"), new XAttribute("type", "octets"), data),
                new XElement("variable", new XAttribute("name", "proctype"), new XAttribute("type", "int"), proctype),
                new XElement("variable", new XAttribute("name", "expire_date"), new XAttribute("type", "int"), expireDate),
                new XElement("variable", new XAttribute("name", "guid1"), new XAttribute("type", "int"), guid1),
                new XElement("variable", new XAttribute("name", "guid2"), new XAttribute("type", "int"), guid2),
                new XElement("variable", new XAttribute("name", "mask"), new XAttribute("type", "int"), mask)
            );

            // Retorna o XML como string formatada
            return itemElement.ToString();
        }

        public static string GenerateDataValue(
            int grade, int freqAtq, int atqRn, int distFrag, int durMM, int atqFMM, int atqMMM,
            int lvlReq, int strReq, int conReq, int agiReq, int intReq)
        {
            // Constroi o valor hexadecimal com base nos dados fornecidos
            var sb = new StringBuilder();

            sb.Append(grade.ToString("X4")); // Exemplo: Grade em hexadecimal
            sb.Append(freqAtq.ToString("X4")); // Frequência de ataque
            sb.Append(atqRn.ToString("X4")); // Ataque RN
            sb.Append(distFrag.ToString("X4")); // Distância de fragmentação
            sb.Append(durMM.ToString("X8")); // Duração m/m
            sb.Append(atqFMM.ToString("X8")); // Ataque físico m/m
            sb.Append(atqMMM.ToString("X8")); // Ataque mágico m/m
            sb.Append(lvlReq.ToString("X4")); // Requisito de nível
            sb.Append(strReq.ToString("X4")); // Requisito de força
            sb.Append(conReq.ToString("X4")); // Requisito de constituição
            sb.Append(agiReq.ToString("X4")); // Requisito de agilidade
            sb.Append(intReq.ToString("X4")); // Requisito de inteligência

            // Retorna o valor hexadecimal gerado
            return sb.ToString();
        }
    }
}