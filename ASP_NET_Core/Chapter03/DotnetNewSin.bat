md CoreSolution
cd CoreSolution
dotnet new sln
type CoreSolution.sln
dotnet new mvc -o MvcApp01
dotnet sln add MvcApp01/MvcApp01.csproj
type CoreSolution.sln
dotnet new webapi -o WebApi01
dotnet sln add WebApi01
type CoreSolution.sln