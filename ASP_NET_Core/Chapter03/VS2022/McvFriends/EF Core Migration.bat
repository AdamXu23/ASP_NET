dotnet ef migrations add InitialDB
dotnet ef database update
dotnet aspnet-codegenerator controller --controllerName FriendsController -outDir Controllers -async -namespace MvcFriends.Controllers -m Friend -dc DatabaseContext -udl