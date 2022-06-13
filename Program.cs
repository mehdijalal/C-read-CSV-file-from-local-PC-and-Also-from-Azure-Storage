using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;


//string connectionString = "DefaultEndpointsProtocol=https;AccountName=riodevstorage;AccountKey=jKTJ2w+sAjSqiLVE2LDNHDX7q1tQ6nWV35Tkj8tAX9BMZHuZzVMpmzToBtdi/oM28qODPkarCEyb8mHy9ZaadA==;EndpointSuffix=core.windows.net";

////string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

//BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

//BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("resetaccountlist");

//BlobClient blobClient = containerClient.GetBlobClient("accountlist.CSV");

//if(await blobClient.ExistsAsync())
//{
//    var response = await blobClient.DownloadAsync();
//    using (var streamReader = new StreamReader(response.Value.Content))
//    {
//        while (!streamReader.EndOfStream)
//        {
//            var line = await streamReader.ReadLineAsync();
//            Console.WriteLine(line);

//        }
//        Console.ReadLine();
//    }
//}


using (var streadReader = new StreamReader(@"C:\Test\accountlist.csv"))
{
using (var csvReader = new CsvReader(streadReader, CultureInfo.InvariantCulture))
{
var records = csvReader.GetRecords<Accounts>().ToArray();
foreach (var record in records)
{
Console.WriteLine(record.Email);

}
Console.ReadLine();
}
}

public class Accounts
{
    public String Email { get; set; }
}