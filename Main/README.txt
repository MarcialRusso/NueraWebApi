Usage
Run solution with IIS Express, note the port number
Open Postman

Example calls
Get http://localhost:PORT_NUMBER/api/client-catalog/
Delete http://localhost:PORT_NUMBER/api/client-catalog/{householdItemId} 
Post http://localhost:PORT_NUMBER/api/client-catalog/
{
	"name": "clothes 2",
	"value": 6,
	"category": "Clothing"
}


Project Techdebt

- Move folders Controllers, models, and Views into the presentation layer.
  Could also leave as is and with the removal of domain infer Main to be our presentation layer.
- The application layer is missing since it's currently not needed 
- Move the domain folder to its own project
- Implement behavioral test with specflow or xbehave for end-to-end testing
- Implement unit test for command handlers