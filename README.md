# EdsmApi
C# implementation to query EDSM Api from [edsm.net](https://www.edsm.net/)

[![Build](https://github.com/Dagonaute/EdsmApi/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Dagonaute/EdsmApi/actions/workflows/dotnet.yml)

## Usage sample
    var requestEngine = serviceProvider.GetRequiredService<EdsmRequestEngine>();
    var query = new EdsmQuerySystem { SystemName = "Sol" };
    var edsmModel = requestEngine.Get(query);
In the sample code above, the first line request the `EdsmRequestEngine` instance from IoC Container.  
The second line instanciate a `system` query. The resulting query will be  
*https://www.edsm.net/api-v1/system?system=Sol&showId=1&showCoordinates=1&showInformation=1&showPermit=1*  
The third line uses the `EdsmRequestEngine` instance to send a `GET` request with this query, and get the result deserialized in a `EdsmSystem` model.
