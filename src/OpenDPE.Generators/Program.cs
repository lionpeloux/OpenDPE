// See https://aka.ms/new-console-template for more information
using OpenDPE.Core;
using OpenDPE.Generators;
using Scriban;
using System.Reflection;


var currentDir = Directory.GetCurrentDirectory();
var solutionDir = currentDir.Split("src")[0] + "src\\";

var jsonDir     = solutionDir + "OpenDPE.Core\\Data\\";
var templateDir = solutionDir + "OpenDPE.Generators\\Templates\\";
var outputDir   = solutionDir + "OpenDPE.Generators\\GeneratedFiles\\";

var cg = new CodeGenerators(jsonDir, templateDir, outputDir);
cg.CG_Departement(  "Departements.json"   , "Departement.tpl");
cg.CG_Departements( "Departements.json"   , "NomDepartement.tpl");


var d1 = Departement.ParNom(NomDepartement.Mayenne);
var d2 = Departement.ParCode("2A");
var d3 = Departement.ParCode("1");
//string filePath = Path.Combine(projectDir, templateDir, "Departement.tpl");
//var tplStr = File.ReadAllText(@"Templates\Departement.tpl");

//var tpl = Template.Parse(tplStr);
//var res = tpl.Render(new { Namespace = "OpenDPE.Core.Enums" });



//Console.WriteLine(res);
Console.ReadKey();

//var users = new List<User>
//{
//    new ( "John Doe", "gardener"),
//    new ( "Roger Roe", "driver"),
//    new ( "Lucy Smith", "teacher")
//};

//var fileName = "users.tpl";



//var res = tpl.Render(new { users = users });

//

