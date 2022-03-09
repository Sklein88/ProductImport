# ProductImport
 Product Import Console Application is a console application with `multi threading` capabilities to process a file to a Client, easy to modify to accept new clients with 2 availables formats: json and yaml.

# Debug the app from visual studio

![image](https://user-images.githubusercontent.com/4528130/157557277-b08cf158-9e31-408f-b2f8-bfe6a5c470c4.png)
![image](https://user-images.githubusercontent.com/4528130/157557637-ad503d06-045f-4c45-85b4-9095b48ae12b.png)

Be sure to set Copy to output directory to "Copy always" if you add a new `IClient` to configure the file for debuging (te be copy in the debug folder)

![image](https://user-images.githubusercontent.com/4528130/157557440-71c3e661-cece-42b5-8356-53425e7d96a8.png)


# Build the import app

```console
dotnet build
cd bin\Release\net6.0
```

# Run the app in console

```console
dotnet ProductImport.dll Capterra feed-products/capterra.yaml
dotnet ProductImport.dll Softwareadvice feed-products/softwareadvice.json
```

# Output example

![testresult](https://user-images.githubusercontent.com/4528130/157536880-a8d084ed-e2f6-4996-958e-e815bfcbaedd.png)

# Execute in a single line the App multiple times

```console
dotnet ProductImport.dll Capterra feed-products/capterra.yaml;dotnet ProductImport.dll Capterra feed-products/capterra.yaml;
dotnet ProductImport.dll Capterra feed-products/capterra.yaml;
```
results off all the operations, multiple files and clients at the same time.

![image](https://user-images.githubusercontent.com/4528130/157554609-fa959860-a5c3-4929-af1f-c838cdc58f82.png)

# Run tests

You need to be located at ProductImport\GartnerCommandLine.ProductServiceTest\

```console
dotnet test
```

![image](https://user-images.githubusercontent.com/4528130/157537214-5352e998-ac8e-4def-9a32-37b121b4db59.png)



# The architecture

The architecture is think as a multi tenant application, the application handles interfaces for Clients, and for each new client , you use the `IClient` , this made easy to have new customers with different attributes, such as formats (json, yaml) or databases conexions, databases, and databases models.

![image](https://user-images.githubusercontent.com/4528130/157541496-153eee95-3e63-42df-b386-ec63fa0c26ec.png)


Also this makes really simply to create new ones, like `SoftwareAdvice` 

![image](https://user-images.githubusercontent.com/4528130/157541770-ba5e5de2-914a-4897-9560-ea325f0c8b9a.png)


And the project code base looks pretty simple, also we have the repository expecting a `IClient` therefore we can also add a `DbContext` to each one to handle each separate database por client with his own prodcuts / data model.

![image](https://user-images.githubusercontent.com/4528130/157542196-8d620f84-f889-4489-b0c0-c07ef3164e83.png)




