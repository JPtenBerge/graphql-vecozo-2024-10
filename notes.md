# Notes

## GraphQL vs de REST

- REST
  - GET POST PUT PATCH DELETE  processen
  - filteren sorteren
- GraphQL
  - volledige uitdrukkingsvrijheid
  - Query
  - Mutation
- SOAP
  - altijd 200
  - beetje bloated
  - `<xml>` "niet webberig"
    - HTML is het broertje van XML, ze stammen beide af van SGML
  - volledige uitdrukkingsvrijheid
- gRPC: gRPC Remote Procedure Call
  - volledige uitdrukkingsvrijheid
  - binair formaat  - protobuf  "protocol buffer"
  - use cases
    - heul veul data  (minimaal 10MB)
    - serializatieproces: JSON is traag en beperkt met datatypen

## Keuze

3 manieren om je GraphQL endpoints mee te definiëren

- implementation-first
  - minst te tikken
  - kan wat magisch aanvoelen
  - klein risico dat je schema verandert terwijl je niet wil
    ```cs
    public class Query
    {
        public string HelloWorld()
        {

        }
    }
    ```
- code-first
  - explicieter types aan het configureren
    ```cs
    public class Query
    {
      public string HelloWorld()
      {

      }
    }
    public class QueryType : ObjectType<Query>
    {
      public string Configure()
      {
        descriptor
          .Field(x => x.HelloWorld())
          .UseFiltering()
          .UsePaging()
          .Type<NonNullable<ListType<NonNullable<StringType>>>>();

      }
    }
    ```
- schema-first
  - zelf schema typen: GROTE STRING

## Waarom Rider > Visual Studio

- 64-bit duurde veeeeeeeeeeeeeeeeeeeeeeel te lang  4GB
- HTML/CSS/JS/TS/SQL RUK
- random crashes
- 4 startup projects > run > 4 aparte terminals
  - 
- mafheden
- runconfiguraties

modal dialog "Waiting for a background operation to complete"

- VS Enterprise  Microsoft Fakes - static mocken
- Connections

## Nullabililty

GraphQL checkt @ runtime op `null`s waar `null` niet mag.

In het verleden met REST API icm DTOs was dat nog wel eens een dingetje.

```text
DTO  <== mappers ==> Entities

Id                   Id
FullName             Name    JSON output: null
```

## Integration testing

- ligt aan de definitie
  - "je bent iets aan het integreren"
- database
- HTML renderen
- API-request => REST
- we roepen niet rechtstreeks code aan.
  = query => graphql
- mocken
  - Moq NSubstitute  Rhino Mocks
    ^^^
