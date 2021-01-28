#! bash

echo "Run dotnet build"

cd /d/Praca/NetCoreDev/EuropeanCommission/src/TaxationAndCustomsUnion/Vies.ConsoleApp

dotnet build "Vies.ConsoleApp.csproj" -c Debug -o bin/Debug/net5.0/

cd /d/Praca/NetCoreDev/EuropeanCommission/src/TaxationAndCustomsUnion/Vies.ConsoleApp/bin/Debug/net5.0/

./Vies.ConsoleApp.exe