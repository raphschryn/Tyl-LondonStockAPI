

# Tyl-LondonStockAPI

## How to test with Swagger:

 - HTTP-Post to ~/exchange/add to add an exchange to the platform with the following data structure in the body:

		Body:
		{
		  "brokerId": "*Guid*",
		  "stock": {
		    "ticker": "*string*",
		    "price": *decimal*
		  },
		  "numberOrShares": *decimal*
		}

		The response is a HTTPCODE 200.

- HTTP-Post to ~/stock/price to get the prices of all the stocks if the body of the request is null, empty or an empty array.
To get only the stock of some specific tickers, the tickers of the stocks must be added in the body as a array of strings.

		For Tyl stocks:
		["TYL"]

		For Tyl and Microsoft stocks:
		["TYL", "MSFT"]

		The response value will be of type:
		[
		  {
		    "ticker": "*string*",
		    "price": *decimal*
		  },
		  {
		    "ticker": "*string*",
		    "price": *decimal*
		  },
		  ...
		]

## Data model
![enter image description here](https://github.com/raphschryn/Tyl-LondonStockAPI/assets/156947212/1e1d40da-4bea-499c-a2bd-b046b1fe5b66)

**ExternalExchange** being the model receive from the Client through the *~/exchange/add* endpoint.
It is then mapped to a **Exchange** object after fetching the Broker from the database using the ExternalExchange.BrokerId.
*(Ideally, for the scope of this project, a dummy Broker is generated using ExternalExchange.BrokerId)*.
The **Exchange** model will be used across the API. Its DateTimeOfExcecution is set on the time of creation of the instance, but could be instead passed by the Client, it is up for debate. 
**Stock** is used in **Exchange**, but also as a return model for the *~/stock/price* endpoint.

## System Design
![enter image description here](https://github.com/raphschryn/Tyl-LondonStockAPI/assets/156947212/33ef71c9-3ae9-4af8-b962-31f6ad777fd1)

For simplicity for this project, the Exchange database is a file 'Exhanges.txt'.
The file can be found in ~\Tyl-LondonStockAPI\API\bin\Debug\net8.0 when debugging the application.
Each new Exchange item is added as a line in JSON following the Exchange model.
As disclosed above, a dummy Broker is generated instead of being fetched from the database.
Assuming the complex and fast paste price calculation is done externally, that is why the stocks and theirs prices are requested through an external SDK. For this project, 4 hard-coded stocks (TYL, MSFT, TSLA, AAPL) are given a random price by a fake internal SDK and returned to the Client.

## Enhancements

### Stock Price functionality:
The Client must be authenticated and authorised to use this functionality.
If the Client is a professional trader, 2 sets of HTTP requests (one to our API, then one to the SDK) to get the prices might be too slow and an alternative feature must be developed.
A caching system also ticks all the boxes to be used with this functionality, depending if the Client needs the very latest price from every requests. 

### Add Exchange functionality:
The Client must be authenticated and authorised to use this functionality.
If the Client is not a trusted authority, the BrokerId would be used inside the request Claim instead of letter the Client freely sending it to us. This would make sure the Client is allowed to use that BrokerId and has not fiddled with it.
If the integrity of the data is important, the price of the Stock could be verified against the External SDK, or fetched directly from it instead of letting the Client notifying of the price. *(But tricky as the prices fluctuate very fast)*

The Client might constantly be calling the endpoint to add a single Exchange to the system and could overwhelm the API.
Allowing the Client to send a list of Exchanges (and setup the DateOfExcution himself) would diminish the number of requests drastically.

If the Broker information is not needed to process the Exchange, it shouldn't be fetch from the database.

The amount of Exchanges done per day in the London stock market is immense, the type of the database must be chosen very carefully. As Exchanges are very well structured, a SQL database would be the best fit.
If the Exchange database is not only used for archiving, but the data need to be retrieve, that would be the bottleneck.
As the database will be busy constantly writing new entries, some *read replicas* could be used to retrieve data.
Considering the volume, other specialized database type could also be considered (NoSQL/ElasticSearh).
