#! bash

echo "Run dotnet build"

cd /d/Praca/NetCoreDev/EuropeanCommission/src/TaxationAndCustomsUnion/Vies.ConsoleApp

dotnet build "Vies.ConsoleApp.csproj" -c Release -o bin/Release/net5.0/

cd /d/Praca/NetCoreDev/EuropeanCommission/src/TaxationAndCustomsUnion/Vies.ConsoleApp/bin/Release/net5.0/

./Vies.ConsoleApp.exe