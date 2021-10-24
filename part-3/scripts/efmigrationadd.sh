pushd ../src/Calculator.Data
dotnet ef migrations add $1 --context CalculatorDbContext -s ../CalcWeb/CalcWeb.csproj
popd