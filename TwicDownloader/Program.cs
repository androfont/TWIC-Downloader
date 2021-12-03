using Spectre.Console.Cli;
using TwicDownloader.Commands;

var app = new CommandApp<DownloadCommand>();
return app.Run(args);