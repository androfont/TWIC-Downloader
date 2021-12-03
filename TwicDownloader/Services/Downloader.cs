namespace TwicDownloader.Services;

public static class Downloader
{
    private const string DownloadUrlTemplate = "https://theweekinchess.com/zips/twic{0}g.zip";
    private static readonly HttpClient httpClient = new HttpClient();


    public static async Task DownloadFilesAsync(string savePath, int fromFileNumber, int toFileNumber, CancellationToken cancellationToken, IProgress<int>? progress)
    {
        int total = toFileNumber - fromFileNumber + 1;
        for (int i = fromFileNumber; i <= toFileNumber; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using var stream = await httpClient.GetStreamAsync(string.Format(DownloadUrlTemplate, i));
            using var fileStream = new FileStream(Path.Combine(savePath, $"twic{i}g.zip"), FileMode.CreateNew);
            await stream.CopyToAsync(fileStream);
            if (progress != null)
            {
                progress.Report((i + 1 - fromFileNumber) * 100 / total);
            }
        }
    }
}
