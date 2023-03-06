using System.Data;
using DbUp.Engine;

namespace ConsoleApp4;

public class Script_002_UploadPersonsImagesToS3_Migration : IScript 
{



    public string ProvideScript(Func<IDbCommand> dbCommandFactory)
    {
        /*
        AwsConnectionStrings c = new ();
        S3Client s = new (c.S3);
        s.UploadFile();
        */
        
        Console.WriteLine("I can do all kinds of things here!");
        Console.WriteLine("Like upload images to S3!");
        Console.WriteLine("Or input data into DynamoDB!");
        Console.WriteLine("Or even make foreach loops and put data into MsSql!");
        
        /*  Example of how to use the dbCommandFactory to execute SQL commands
            using (var cmd = dbCommandFactory())
            {
                cmd.CommandText = "SELECT DeliveryMethodName FROM Application.DeliveryMethods";
                using (var dr = cmd.ExecuteReader())
                {
                    Console.WriteLine("  Delivery Methods");
                    while (dr.Read())
                    {
                        Console.WriteLine($"    {dr["DeliveryMethodName"]}");
                    }
                }
            }
         */
        
        return string.Empty;
    }
}