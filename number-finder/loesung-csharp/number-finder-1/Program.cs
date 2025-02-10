
const string NUMER_TO_MATCH = "777";

string fileName = getFileName();
StreamReader streamReader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));
string? line;
int count = 0;
int lineNumber = 0;
while ((line = streamReader.ReadLine()) != null)
{
  lineNumber++;
  count = count + getCount(line);
}
Console.WriteLine($"In der Datei \"{fileName}\" kommt die Zahl {count} mal vor!");


int getCount(string line)
{
  int count = 0;
  string[] chunks = line.Split(" ");
  foreach (string chunk in chunks)
  {
    if (NUMER_TO_MATCH == chunk)
    {
      count++;
    }
  }
  return count;
}

// Print Usage of Console App
string getFileName()
{
  Console.WriteLine();
  Console.WriteLine("Please specify the path to the file that should be read:");
  string? input = Console.ReadLine();
  while (input == null || input.Length == 0 || !File.Exists(input))
  {
    Console.WriteLine("Please specify a valid path!");
    input = Console.ReadLine();
  }
  return input;
}