using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using TwicDownloader.Services;

namespace TwicDownloader.Commands;
internal sealed class DownloadCommand : AsyncCommand<DownloadCommand.Settings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        AnsiConsole.MarkupLine("\n[olive]Starting download...[/]");
        var progress = new Progress<int>();
        await AnsiConsole.Progress()
            .StartAsync(async ctx =>
            {
                // Define tasks
                var downloadTask = ctx.AddTask("[green]Downloading files...[/]");
                progress.ProgressChanged += (sender, percent) => downloadTask.Value = percent;
                await Downloader.DownloadFilesAsync(settings.Path, settings.From, settings.To, CancellationToken.None, progress);
            });
        AnsiConsole.MarkupLine("[olive]Download Completed!\n[/]");
        return 0;
    }    

    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "[from]")]
        public int From { get; set; }

        [CommandArgument(0, "[to]")]
        public int To { get; set; }

        [CommandOption("-p|--path")]
        [DefaultValue("")]
        public string Path { get; set; }

        public Settings()
        {
            Path = "";
        }
    }
}
