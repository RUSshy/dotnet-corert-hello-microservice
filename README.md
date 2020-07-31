# Tiny dotnet hello world microservice using CoreRT

A hello world microservice written in C# using CoreRT, adapted from: https://github.com/ktenzer/go-hello-world

- AOT Compiled
- Tiny self contained executable: only 1.8mb!!
- Reponse serialized using System.Json
- Reflection-free

## Usage 

- ``cd HelloMicroservice``
- ``dotnet publish -c release -r win-x64`` | linux-x64 | osx-x64
- ``cd dist``
- ``HelloMicroservice.exe``

- ``curl http://localhost:8080/status``

TODO: docker file
