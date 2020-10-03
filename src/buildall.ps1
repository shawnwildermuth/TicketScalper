Push-Location .\TicketScalper.Web\
./build.ps1
Pop-Location 

Push-Location .\TicketScalper.AuthAPI
./build.ps1
Pop-Location 

Push-Location .\TicketScalper.SalesAPI
./build.ps1
Pop-Location 

Push-Location .\TicketScalper.ShowsAPI
./build.ps1
Pop-Location 

Push-Location .\TicketScalper.Gateway
./build.ps1
Pop-Location 

