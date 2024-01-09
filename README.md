# Top Rated Actors Web API

Web API for managing top-rated actors database using C# .NET 6. This API is preloaded with top-rated actors from [IMDB Top rated Actors](https://www.imdb.com/list/ls000004615/).

## API Endpoints

### Get Actors
Get a list of actors within a specified rank range.

#### Request
```bash
curl -X 'GET' \
  'https://localhost:7290/api/v1/actors?MinRank=2&MaxRank=10&PageNumber=2&PageSize=5' \
  -H 'accept: text/json'
#### Response
[
  {"Id":7,"Name":"Tom Hanks"},
  {"Id":8,"Name":"Brad Pitt"},
  {"Id":9,"Name":"Anthony Hopkins"},
  {"Id":10,"Name":"Marlon Brando"}
]

### Create Actor
Create a new actor.

#### Request
curl -X 'POST' \
  'https://localhost:7290/api/v1/actors' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Jon Snow",
  "details": "King of the North",
  "rank": 150
}'
#### Response
{"Id":101,"Name":"Jon Snow","Details":"King of the North","Rank":150}



