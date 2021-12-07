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


Test Examples:
    
    Post Restaurant example:
        post -c "{"name": "The Sour House", "address": "Friar Street 301A", "openingtimes": "10:00-19:00"}"

    put Restaurant example:
        put [UUID] -c "{"name": "The Flour House", "address": "Friar Street 301A", "openingtimes": "10:00-19:00"}"

    Post Burger with ID of Restaurant example:
        post -c "{"name": "Onion-tended Consequences", "ingredients": "Bun, veggie beef, onion rings, lettuce, tomato, BBQ sauce and homemade burger dressing", "vegetarian": true, "restaurantid": "[UUID]"}"
    
    Post Review with ID of Burger example:
	    post -c "{"title": "Onion Goodness", "description": "I really like onions!", "tastescore": 8, "burgerid": "[UUID]"}"