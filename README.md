# TWIC-Downloader
This is a simple tool to bulk download chess files from [The Week in Chess](https://theweekinchess.com/twic). It is not an agressive downloader it is intended to used incrementally downloading only new files via parameters. Files will be downloaded one by one and you can follow the progress.
## Command Syntax
```
USAGE:
    TwicDownloader.exe [from] [to] [OPTIONS]

ARGUMENTS:
    [from]    Indicates file number to start
    [to]      Indicates file number to finish up (Included)

OPTIONS:
    -h, --help    Prints help information
    -p, --path    Path to save files. Defaults to current directory
```

## How to use
To download files from 1000 to 1024 and save in current directory you can use

``TwicDownloader.exe 1000 1024``

In the same way you can specify a path absolute or relative to define where to save the files

``TwicDownloader.exe 1000 1024 -p C:\TwicFiles``
