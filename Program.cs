using System.Reflection;
using DbUp;


    /*
     * I would recommend naming your scripts like this:
     * Script_20230301_1030_InitialMigration_Migration.cs
     * Script_20230301_1535_InitialMigration_TestData.sql
     * Script_YYYYMMDD_HHMM_ScriptName_Type.cs
     * Date should be the time of PullRequest.
     * Only prepending Script since C# doesn't allow numbers as the first character in a file name
     */
    
    
    var enviromentName = "pullrequest"; // integration, staging, production etc. (even developer specific)
    var connectionString = "Server=localhost;Database=demo123;User Id=sa;Password=P4ssw0rd!;TrustServerCertificate=true";

    EnsureDatabase.For.SqlDatabase(connectionString); // If we want our code to create the database if it doesn't exist

    var upgrader =
        DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => 
                    ShouldExcludeSeedingData(s, enviromentName) &&
                    ShouldExcludeTestData(s, enviromentName)
            )
            .LogToConsole()
            .LogScriptOutput()
            .Build();

    var result = upgrader.PerformUpgrade();

    if (!result.Successful)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(result.Error);
        Console.ResetColor();
#if DEBUG
        Console.ReadLine();
#endif                
        return -1;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Success!");
    Console.ResetColor();
    return 0;


static bool ShouldExcludeTestData(string scriptName, string environmentName)
{
    // Implement your own logic here
    return true;
}

static bool ShouldExcludeSeedingData(string scriptName, string environmentName)
{
    return !scriptName.Contains("TestData");
}