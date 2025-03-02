# Zeil-Coding-Test

This coding test provides a api endpoint to allow consumers to test if a given credit card number passes [Luhn Validation](https://en.wikipedia.org/wiki/Luhn_algorithm).

## Building and running solution

Ensure you have the [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) installed.

Run the solution
```shell
dotnet run
#or
dotnet watch
```

## Api Endpoints

The API will run at `http://localhost:5289`

### [POST] /v1/cardvalidation

Expected payload

```json
{
  "cardNumber": "{{card number 13-23 digits, spaces and dashes allowed}}"
}
```

**Example:**

```
curl --location 'http://localhost:5289/v1/cardvalidation' \
--header 'Content-Type: application/json' \
--data '{
    "cardNumber": "4111 1111 1111 1111"
}'
```

**Payload result:**

The payload will return a single boolean value `isValid` to indicate if it passed the Luhn test. 

```json
{
  "isValid": true
}
```



# Swagger

You can also access the swagger pages in development via http://localhost:5289/swagger/

# Postman

Included is a postman collection to test the api
`postman_collection.json`