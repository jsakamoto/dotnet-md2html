# dotnet-md2html [![NuGet Package](https://img.shields.io/nuget/v/dotnet-md2html.svg)](https://www.nuget.org/packages/dotnet-md2html/)

## Summary

Yet another implementation of the Markdown Text to HTML Converter, built on .NET Core console application.

## Install

### Case 1. Install as a .NET Core project local tool - Reference from .NET Core project

Add a .NET CLI Tool reference in the .csproj file.

```xml
<ItemGroup>
  <DotNetCliToolReference Include="dotnet-md2html" Version="1.0.0.1-preview1" />
</ItemGroup>
```

After NuGet package restoring, you can use `dotnet md2html` command in the project folder.

### Case 2. Install as a global tool

```shell
dotnet tool install -g dotnet-md2html --version 1.0.0.1-preview1
dotnet-md2html -i {input-file} -o {output-file}
```

See also Microsoft Docs site.

- [Docs / .NET / .NET Core Guide / Tools - "dotnet tool install"](https://docs.microsoft.com/dotnet/core/tools/dotnet-tool-install)

## Command Line Syntax

### Usage

```shell
> dotnet md2html [options]
```

### Options

Options | Description
---------------------|-----------------
-v | Show version of dotnet-md2html command.
-i `{path}` | Specify the file path of source markdown text file. If `-i` options is not specified, `dotnet-md2html` command reads source markdown text from standard input stream.
-o `{path}` | Specify the file path of destination HTML file. If `-o` option is not specified, `dotnet-md2html` command writes HTML converted from source markdown text into standard output stream.
-e | Embed images into the HTML file as a data protocol instead of image path references.

## License

[Mozilla Public License 2.0](https://github.com/jsakamoto/dotnet-md2html/blob/master/LICENSE)
