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

var allowedSenders = smsService.GetAllowedSenders();
var sentSMS = smsService.GetSentSMSs(new SMSFilter { From = DateTime.MinValue, To = DateTime.Now });

smsService.SendSms(allowedSenders.First(), "{Recipient number in format 00xxxx...}", "Message text");
```
## Credit service
```csharp
ICreditService creditService = new CreditService();

var actualBalance = creditService.GetBalance();
```

## Speeddial service
```csharp
ISpeedDialService speedDialService = new SpeedDialService();

var speedDials = speedDialService.GetSpeedDials();
```
# Releases
* 1.0 - Initial release
