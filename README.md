# Odorik
![Build status](https://ci.appveyor.com/api/projects/status/github/LadislavMargai/Odorik)

API SDK for communicating with Odorik VOIP gateway.
# Quickstart
* Install Odorik nuget package
```powershell  
  PM> Install-Package Odorik
```
* Register on [Odorik.cz website](https://www.odorik.cz)
* Go to `Account settings -> API password` and get user and API password. Enusre you have possitive credit balance.
![Odorik.cz website](https://raw.githubusercontent.com/LadislavMargai/Odorik/master/pictures/odorik-web.png)
# Services
## Inital configuration
```csharp  
OdorikConfiguration.SetCredentials("https://www.odorik.cz/api/v1/", "{user}", "{apiPassword}");
```
## SMS service
```csharp  
ISMSService smsService = new SMSService();

var allowedSenders = await smsService.GetAllowedSendersAsync();
var sentSMS = await smsService.GetSentSMSsAsync(new SMSFilter { From = DateTime.MinValue, To = DateTime.Now });

await smsService.SendSmsAsync(allowedSenders.First(), "{Recipient number in format 00xxxx...}", "Message text");
```
## Credit service
```csharp
ICreditService creditService = new CreditService();

var actualBalance = await creditService.GetBalanceAsync();
```

## Speeddial service
```csharp
ISpeedDialService speedDialService = new SpeedDialService();

var speedDials = await speedDialService.GetSpeedDialsAsync();
```
# Releases
* 1.0 - Initial release
* 1.1 - Async support
