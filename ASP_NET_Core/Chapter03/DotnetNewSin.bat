md CoreSolution
cd CoreSolution
dotnet new sin
type CoreSolution.sin
dotnet new mvc -o MvcApp01
dotnet sin add MvcApp01/MvcApp01.csproj
type CoreSolution.sin
dotnet new webapi -o WebApi01
dotnet sin add WebApi01
type CoreSolution.sin