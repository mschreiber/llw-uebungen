
using System.Data.SQLite;

const int LIMIT = 50;
const string CONNECTION_STRING = "Data Source=crossNumber.db";


Console.WriteLine("Quersummen Statistik Programm\n");
Console.WriteLine("Funktionen:");
Console.WriteLine("\t1...Datei parsen");
Console.WriteLine("\t2...Statistik anzeigen\n");
Console.WriteLine("Wählen sie 1,2 jede andere Taste beendet das Programm");
var consoleKey = Console.ReadKey(true);

switch (consoleKey.KeyChar)
{
  case '1':
    prepareDatabase();
    parseFile();
    break;
  case '2':
    prepareDatabase();
    showStatistic();
    break;
}


void showStatistic()
{
  using (var connection = new SQLiteConnection(CONNECTION_STRING))
  {
    connection.Open();
    Console.WriteLine("Statistik:\n");
    printFastetLimit(connection);
    printAverages(connection);
    printFirstLineMax(connection);
  }
}

void printFirstLineMax(SQLiteConnection connection)
{
  Console.WriteLine("Erreichen des Limits in Zeile 1:");
  var command = connection.CreateCommand();
  command.CommandText = "select file_path, max(limit_reached_at) as max_limit_reached from files join lines on files.id = lines.file_id where lines.line_number=1 group by files.id order by max_limit_reached limit 1";
  using (var reader = command.ExecuteReader())
  {
    if (reader.Read())
    {
      var filePath = reader.GetString(0);
      var limitReachedAt = reader.GetInt32(1);
      Console.WriteLine($"\tDatei: {filePath}; Limit erreicht bei {limitReachedAt} Zeichen/Zahlen");
    }
  }
}

void printFastetLimit(SQLiteConnection connection)
{
  Console.WriteLine("Schnellstes Erreichen des Limits:");
  var command = connection.CreateCommand();
  command.CommandText = "select file_path, min(limit_reached_at) as min_limit_reached from files join lines on files.id = lines.file_id group by files.id order by min_limit_reached limit 1";
  using (var reader = command.ExecuteReader())
  {
    if (reader.Read())
    {
      var filePath = reader.GetString(0);
      var limitReachedAt = reader.GetInt32(1);
      Console.WriteLine($"\tDatei: {filePath}; Limit erreicht bei {limitReachedAt} Zeichen/Zahlen");
    }
  }
}

void printAverages(SQLiteConnection connection)
{
  Console.WriteLine("Durchschnitt pro Datei:");
  var command = connection.CreateCommand();
  command.CommandText = "select file_path, avg(limit_reached_at) as avg_limit_reached from files join lines on files.id = lines.file_id group by files.id order by avg_limit_reached";
  using (var reader = command.ExecuteReader())
  {
    while (reader.Read())
    {
      var filePath = reader.GetString(0);
      var limitReachedAt = reader.GetDouble(1).ToString("##.00");
      Console.WriteLine($"\tDatei: {filePath}; Durchschnitt: {limitReachedAt}");
    }
  }
}


void parseFile()
{

  var fileName = getFileName();
  var linesIterator = File.ReadLines(fileName);
  var lineCounter = 0;
  var lineWithSmallesCount = int.MaxValue;
  var smallestCount = int.MaxValue;

  using (var connection = new SQLiteConnection(CONNECTION_STRING))
  {
    connection.Open();
    var fileId = insertFile(connection, fileName);
    foreach (var line in linesIterator)
    {
      lineCounter++;
      var crossNumberLimit = calculateCrossNumberLimit(line);
      if (crossNumberLimit > 0 && crossNumberLimit < smallestCount)
      {
        lineWithSmallesCount = lineCounter;
        smallestCount = crossNumberLimit;
      }
      Console.WriteLine($"Zeile {lineCounter}: {crossNumberLimit}");
      insertLine(connection, fileId, lineCounter, crossNumberLimit);
    }
    Console.WriteLine($"Zeile {lineWithSmallesCount} ist die Zeile, die am schnellsten die 50 erreicht hat");
  }
}

void insertLine(SQLiteConnection connection, int fileId, int lineCounter, int crossNumberLimit)
{
  var command = connection.CreateCommand();
  command.CommandText = "insert into lines(file_id, line_number, limit_reached_at) values($fileId,$lineNumber,$reachedAt)";
  command.Parameters.AddWithValue("$fileId", fileId);
  command.Parameters.AddWithValue("$lineNumber", lineCounter);
  command.Parameters.AddWithValue("$reachedAt", crossNumberLimit);
  command.ExecuteNonQuery();
}

int insertFile(SQLiteConnection connection, string fileName)
{
  var command = connection.CreateCommand();
  command.CommandText = "insert into files(file_path) values($filepath); select last_insert_rowid();";
  command.Parameters.AddWithValue("$filepath", fileName);
  // TODO: handle last_insert_rowid in a better way (fail safe)
  return Convert.ToInt32(command.ExecuteScalar());
}

// Calculates the cross number of one line
int calculateCrossNumberLimit(string line)
{
  var crossNumber = 0;
  var count = 0;
  foreach (var number in line)
  {
    count++;
    crossNumber += short.Parse(number.ToString());
    if (crossNumber >= LIMIT)
    {
      return count;
    }
  }
  return -1;
}



// Get the file name either from the command line or 
// by asking the user to enter the path 
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


// Check if the database contains the tables, if not create them
void prepareDatabase()
{
  using (var connection = new SQLiteConnection(CONNECTION_STRING))
  {
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = "SELECT name FROM sqlite_master WHERE type='table'";
    var fileTableExists = false;
    var linesTableExists = false;
    using (var reader = command.ExecuteReader())
    {
      while (reader.Read())
      {
        var tableName = reader.GetString(0);
        if ("lines".Equals(tableName))
        {
          linesTableExists = true;
        }
        if ("files".Equals(tableName))
        {
          fileTableExists = true;
        }
      }
    }
    if (!linesTableExists)
    {
      var createTableCommand = connection.CreateCommand();
      createTableCommand.CommandText = "CREATE TABLE files(ID INTEGER PRIMARY KEY AUTOINCREMENT, file_path varchar(255))";
      createTableCommand.ExecuteNonQuery();
    }
    if (!fileTableExists)
    {
      var createTableCommand = connection.CreateCommand();
      createTableCommand.CommandText = "CREATE TABLE lines(id integer primary key autoincrement, file_id integer, line_number, limit_reached_at integer)";
      createTableCommand.ExecuteNonQuery();
    }
  }
}