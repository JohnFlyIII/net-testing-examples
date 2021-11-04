pushd ../src/Calculator.Data
dotnet ef migrations script $1 --idempotent --context CalculatorDbContext -s ../CalcWeb/CalcWeb.csproj 
popd