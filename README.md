# Burger Backend Readme

Minimum requirement to run:
    Installation of .NET 6.0 Runtime

Used in testing:
    HttpRepl (HTTP Read-Eval-Print Loop)

REST Structure:
    GET    /burgers --> list of all burgers
    POST   /burgers --> add a new burger
    GET    /burgers/{id} --> detail on a specific burger
    PUT    /burgers/{id} --> update the burger's details
    DELETE /burgers/{id} --> remove that burger

    GET    /restaurants --> list of all restaurant
    POST   /restaurants --> add a new restaurant
    GET    /restaurants/{id} --> detail on a specific restaurant
    PUT    /restaurants/{id} --> update the restaurant's details
    DELETE /restaurant/{id} --> remove that restaurant

    GET    /reviews --> list of all review
    POST   /reviews --> add a new review
    GET    /reviews/{id} --> detail on a specific review
    PUT    /reviews/{id} --> update the review's details
    DELETE /review/{id} --> remove that review