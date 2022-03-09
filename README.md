# ProductImport
 Product Import Console Application

# Build the import app

```console
dotnet build
cd bin\Release\net6.0
```

# Run the app

```console
dotnet ProductImport.dll Capterra feed-products/capterra.yaml
dotnet ProductImport.dll Softwareadvice feed-products/softwareadvice.json
```

# Output example

![testresult](https://user-images.githubusercontent.com/4528130/157536880-a8d084ed-e2f6-4996-958e-e815bfcbaedd.png)

# Run tests

You need to be located at ProductImport\GartnerCommandLine.ProductServiceTest\

```console
dotnet test
```

![image](https://user-images.githubusercontent.com/4528130/157537214-5352e998-ac8e-4def-9a32-37b121b4db59.png)


