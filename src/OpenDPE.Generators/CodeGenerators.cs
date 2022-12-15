using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using OpenDPE.Core.Model;
using OpenDPE.Core;

namespace OpenDPE.Generators
{
    interface ICodeGenerator
    {
        int PathToTemplateFile { get; set; }
        int PathToJsonFile { get; set; }
        void Generate(string pathToJsonFile, string pathToTemplateFile);
    }
    internal class CodeGenerators
    {
        public string JsonFolder { get; private set; } = "";
        public string TemplateFolder { get; private set; } = "";
        public string OutputFolder { get; private set; } = "";

        private CodeGenerators() { }
        public CodeGenerators(string jsonFolder, string templateFolder, string outputFolder)
        {
            JsonFolder = jsonFolder;
            TemplateFolder = templateFolder;
            OutputFolder = outputFolder;
        }

        public void CG_Departement(string jsonFileName, string templateFileName)
        {
            var csFileName = Path.GetFileNameWithoutExtension(templateFileName) + ".g.cs";
            string text = File.ReadAllText(JsonFolder + jsonFileName);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters ={
                    new JsonStringEnumConverter( JsonNamingPolicy.CamelCase)
                 },
            };

            var departements = JsonSerializer.Deserialize<List<Departement>>(text, options);
            var objs = departements.Select(d => new { 
                Nom = d.Nom, 
                Code = CodeDepartementToFieldName(d.Code), 
                Enum = NomDepartementToEnumName(d.Nom), 
                ZoneClimatique = d.ZoneClimatique
            });

            var tplStr = File.ReadAllText(TemplateFolder + templateFileName);
            var tpl = Template.Parse(tplStr);

            var res = tpl.Render(new { Departements = objs });
            File.WriteAllText(OutputFolder + csFileName, res);
            Console.Write(res);
        }
        public void CG_Departements(string jsonFileName, string templateFileName)
        {
            var csFileName = Path.GetFileNameWithoutExtension(templateFileName) + ".g.cs";
            string text = File.ReadAllText(JsonFolder + jsonFileName);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters ={
                    new JsonStringEnumConverter( JsonNamingPolicy.CamelCase)
                 },
            };

            var departements = JsonSerializer.Deserialize<List<Departement>>(text, options);
            var objs = departements.Select(d => new {
                Enum = NomDepartementToEnumName(d.Nom),
            });

            var tplStr = File.ReadAllText(TemplateFolder + templateFileName);
            var tpl = Template.Parse(tplStr);

            var res = tpl.Render(new { Departements = objs });
            File.WriteAllText(OutputFolder + csFileName, res);
        }

        private static string CodeDepartementToFieldName(string code)
        {
            int num;
            if (int.TryParse(code, out num))
                return num.ToString("00");
            else
                return code; // cas de la corse 2A ou 2B
        }
        private static string NomDepartementToEnumName(string nom)
        {
            var res = RemoveDiacritics(nom);
            var delimiters = new string[] { "_", "-", " ", "'"};
            return String.Join("_", res.Split(delimiters, StringSplitOptions.TrimEntries));
        }
        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}
