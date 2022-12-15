using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;

namespace BlobStorageDemo;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.ReadLine();

        UploadFileIntoBlobStorage();
    }

    private static void UploadFileIntoBlobStorage()
    {
        throw new NotImplementedException();
    }

    public static void GetBlobServiceClient(ref BlobServiceClient blobServiceClient, string accountName)
    {
        TokenCredential credential = new DefaultAzureCredential();

        string blobUri = "https://" + accountName + ".blob.core.windows.net";

        blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
    }

    public static async Task UploadFile(BlobServiceClient serviceClient, string localFilePath)
    {
        string fileName = Path.GetFileName(localFilePath);
        BlobContainerClient containerClient = serviceClient.GetBlobContainerClient("test container");
        BlobClient blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(localFilePath, true);
    }
}
