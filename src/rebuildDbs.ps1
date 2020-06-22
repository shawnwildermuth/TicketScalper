dotnet ef database drop -f -p ./TicketScalper.ShowsApi
dotnet ef database update -p ./TicketScalper.ShowsApi
dotnet ef database drop -f -p ./TicketScalper.SalesApi
dotnet ef database update -p ./TicketScalper.SalesApi
dotnet ef database drop -f -p ./TicketScalper.AuthApi
dotnet run --project ./TicketScalper.AuthApi /seed