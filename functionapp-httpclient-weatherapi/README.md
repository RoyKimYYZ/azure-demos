How To Create An Azure Function App that Calls an External 3rd Party API

Scenario: A quick and simple bar bones Function App that calls an API out in the internet. In this demo, will be a weather API to get the current weather in .NET 6. Build all resources and code in Azure Portal.

Motivation: By now there should be a lot of examples of doing this, but to my surprise, I couldn’t find any working example. Not even with ChatGPT. Therefore, hope this is a working example to help you get started, as of February 2023.

1) Go to Azure Portal and create a Function App resource for any given resource group.


Set a storage account (new or existing)


I want my function to be accessible directly from the internet.


Always a good idea to have some monitoring. I like to use a shared Application Insights for reuse and cost efficiencies.


Continue to select defaults or settings you desire and then click Create.

Here is the Function App


Create an Http Trigger based function since I want to call it as an Http request. I am going to develop the code in the portal as it is easier.


Note that the name of this function is HttpTrigger1 and can’t be named from the beginning. You can create additional functions in this Function App.

Click into the function to get options for getting the function Url and the ability to update the code.


The default function url is
https://rk-weather.azurewebsites.net/api/HttpTrigger1?code=qf3-mJ_ubdmmrU0op8b9-nzP0ed8XdGGii7ma3VOZu3FAzFu_N63Ag==

It has a query string ‘code‘ with a simple type of security key.

The output is as follows.


Click on Code + Test to put your own code


Go to any weather api that you prefer, but I registered for a free account at weatherstack.com. When I register, I am given an API Key.


Click on Test/Run


To make the function anonymous and not needing any code parameter, click on Integration, click on the Trigger, then set the Authorization Level from Function to Anonymous. Click Save.


Go back to the Function > Overview and click Get Function Url


https://rk-weather.azurewebsites.net/api/HttpTrigger1?


To specify a location: https://rk-weather.azurewebsites.net/api/HttpTrigger1?location=Calgary,Canada


Current Calgary’s temperature is -25C.

Conclusion

I have to say this looks all simple, but but figuring out simple things like handling a query string parameter and calling out to a 3rd party API and making the appropriate assembly reference may not be so quickly accomplished end to end with the help with Google and ChatGPT. Hope things helps you get started super quickly.