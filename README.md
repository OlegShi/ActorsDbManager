# Top Rated Actors Web API

Web API for managing top-rated actors database using C# .NET 6. This API is preloaded with top-rated actors from [IMDB Top rated Actors](https://www.imdb.com/list/ls000004615/).

## API Endpoints

#### Get Actors Request:
curl -X 'GET' \
  'https://localhost:7290/api/v1/actors?MinRank=2&MaxRank=10&PageNumber=2&PageSize=5' \
  -H 'accept: text/json'
#### Get Actors Response:  
  [
  {"Id":7,"Name":"Tom Hanks"},
  {"Id":8,"Name":"Brad Pitt"},
  {"Id":9,"Name":"Anthony Hopkins"},
  {"Id":10,"Name":"Marlon Brando"}
]

  
#### Create Actor Request: 
curl -X 'POST' \
  'https://localhost:7290/api/v1/actors' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Jon Snow",
  "details": "King of the North",
  "rank": 150
}'
#### Create Actor Response:
	{"Id":101,"Name":"Jon Snow","Details":"King of the North","Rank":150}


#### Update Actor Request:
curl -X 'PUT' \
  'https://localhost:7290/api/v1/actors' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 2,
  "name": "Night King",
  "details": "Supreme leader and the first of the White Walkers",
  "rank": 200
}'
#### Update Actor Response:
	{"Id":2,"Name":"Night King","Details":"Supreme leader and the first of the White Walkers","Rank":200}


#### Delete Actor Request:
curl -X 'DELETE' \
  'https://localhost:7290/api/v1/actors' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 5
}'
#### Delete Actor Response:
	Actor with id 5 successfully deleted


#### Get Actor by ID Request:
curl -X 'GET' \
  'https://localhost:7290/api/v1/actors/10' \
  -H 'accept: text/plain'
#### Get Actor by ID Response:  
  {"Id":10,"Name":"Marlon Brando","Details":"Marlon Brando is widely considered the greatest movie actor of all time, rivaled only by the more theatrically oriented Laurence Olivier in terms of esteem. Unlike Olivier, who preferred the stage to the screen, Brando concentrated his talents on movies after bidding the Broadway stage adieu in ...","Rank":10}

### swagger.json attached

## Additional Considerations
### Authentication and Authorization
implement secure authentication and authorization mechanisms to control access to endpoints and manage user permissions.

### Logger
Implement logging functionality to track and monitor API activities, errors, and important events for debugging and analysis purposes.

### HTTPS
Enforce HTTPS for secure communication between clients and the API to protect data privacy and integrity.

### Augment the Swagger
Enhance Swagger documentation to provide comprehensive details about API endpoints, request/response models, and examples.

### Testing
Implement thorough testing methodologies including unit tests, integration tests, and possibly end-to-end tests to ensure the API functions as expected and handles edge cases properly.
