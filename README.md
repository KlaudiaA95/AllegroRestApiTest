# Allegro Rest API Tests

Client + Tests written to check 3 separate Category enpoints from Allegro Rest Api.

This solution is divided to 2 projects:
- AllegroApi - containing business entity models and client service for accessing Allegro Api.
- AllegroTests - containing test for Category endpoints

## Getting Started

To get those tests up and running in easiest possible way you will need to download/checkout this project in Visual Studio from where you can execute each test separately or all tests together.

### Prerequisites

In AllegroTests project find 'testsettings.json' file. Fill ClientId and ClientSecret fields with your own auth data to gain an access to API.

```
{
  ...
  "ClientId": "YOUR_CLIENT_ID",
  "ClientSecret": "YOUR_CLIENT_SECRET"
}
```

For logging purposes there is configured basic logger that will proceed all logs to file. 

Log file will be accessible on following path: {baseDir}/logfile.txt. (Most probably AllegroTests/bin.../.../logfile.txt)


### Tests

There are 3 tests classes that will cover 3 following endpoints: 

- GET IDs of Allegro categories (GetIDsOfAllegroCategoriesTests class)
- GET a category by ID (GetCategoryByIdTests class)
- GET parameters supported by a category (GetParametersByCategoryTests class)

Each test is written using Arrange, Act, Assert style. 

Test names are constructed basing on following pattern: BusinessEntityName_TestedFunctionality_Is/Are/Possible


## Author

* **Klaudia Aleksandrzak** 
