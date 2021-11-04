pushd ../src/Calculator.Data
dotnet ef migrations list --context CalculatorDbContext -s ../CalcWeb/CalcWeb.csproj
popd