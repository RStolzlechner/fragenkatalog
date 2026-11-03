// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Serialization;
using fragenkatalog;

if (args.Length == 0)
{
    Console.WriteLine("Kurs nicht angegeben (e.g. FoITS)");
    return;
}

string path = $"/home/ricardo/Documents/studium-cyber-security/Fragenkataloge/{args[0]}.json";
if(!File.Exists(path))
{
    Console.WriteLine($"Pfad {path} existiert nicht");
    return;
}

List<QandA> allQuestions = [];
List<QandA> assessmentQuestions = [];
using (StreamReader r = new StreamReader(path))
{
    string json = r.ReadToEnd();
    
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    allQuestions = JsonSerializer.Deserialize<List<QandA>>(json, options) ?? [];

    var assessment = new Assesment(allQuestions);
    assessmentQuestions = assessment.AssessmentQuestions;
}

var cnt = 1;
foreach (var q in assessmentQuestions)
{
    Console.WriteLine($"Frage {cnt++}: {q.Question}");
    Console.ReadLine();
    Console.WriteLine($"Antwort: {q.Answer}");
    
    Console.Write("Korrekt j (Ja) | t (teilweise) | N (Nein)? ");
    var correct = Console.ReadLine();
    Console.WriteLine();

    var allQ = allQuestions.First(aq => aq.Id == q.Id);
    if (correct == "j") allQ.Points+=1;
    else allQ.Points = 0;
}

string back = JsonSerializer.Serialize(allQuestions);
File.WriteAllText(path, back);