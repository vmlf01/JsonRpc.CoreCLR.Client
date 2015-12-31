# JsonRpc.CoreCLR.Client

Simple JSON-RPC Client for CoreCLR 5.0.

With bits and pieces from [JSON-RPC.NET](https://github.com/Astn/JSON-RPC.NET)

### Installation

Just use ```dnu``` in your project folder to pull the package from NuGet:

```Shell
# Install JsonRpc.CoreCLR.Client package
dnu install JsonRpc.CoreCLR.Client
```

### Samples

The sample app makes an JSON-RPC request to the [Guru JSON-RPC Tester](http://gurujsonrpc.appspot.com/) service.
You can run the sample inside the ```src/HelloGuruJsonRpcSample``` folder:

```Shell
# change into sample app folder
cd src/HelloGuruJsonRpcSample

# restore package dependencies
dnu restore

# run the sample app
dnx run
```

The relevant code is:

```cs
public static async Task CallTestService()
{
    Uri rpcEndpoint = new Uri("http://gurujsonrpc.appspot.com/guru");
    JsonRpcWebClient rpc = new JsonRpcWebClient(rpcEndpoint);

    // you can use Json.Net JValue if the service returns a value or
    // JObject if it returns an object or you can provide your own
    // custom class type to be used when deserializing the rpc result
    var response = await rpc.InvokeAsync<JValue>("guru.test", new string[]
    {
        "World"
    });

    System.Console.WriteLine("RPC Reply: {0}", response.Result);
}
```

### Build From Source

To build the library from source, please do:

```Shell
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
