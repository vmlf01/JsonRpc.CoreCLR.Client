# JsonRpc.CoreCLR.Client

Simple JSON-RPC Client for CoreCLR 5.0.

### Installation

*TODO*

### Build From Source

To build the library from source, please do:

```Shells
# Clone repository
git clone https://github.com/vmlf01/JsonRpc.CoreCLR.Client.git
cd JsonRpc.CoreCLR.Client

# Restore NuGet packages
dnu restore

# Build NuGet package
dnu pack src/JsonRpc.CoreCLR.Client --out build
```

You can also run the tests by doing:

```Shell
# Run tests from repository root
dnx -p tests/JsonRpc.CoreCLR.Client.Tests test
```

### Publish NuGet package to repository

You will need nuget.exe on your path and set the NuGet API Key before you can push a package to the NuGet repository.

```Shell
nuget.exe setApiKey 76d7xxxx-xxxx-xxxx-xxxx-eabb8b0cxxxx
nuget.exe push .\build\Debug\JsonRpc.CoreCLR.Client.0.0.1.nupkg
```

### Samples

*TODO*
