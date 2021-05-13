# Delivery-System

This project is to be done as the techincal stage of an interview.

The aim is to create a delivery system to connect users from the consumer market to partners.

The application will consist of a Web API that will be used by both partners and consumers.

## Requirements
* The API should support all CRUD operations
* Deliveries will consist of 5 different states (created, approved, completed cancelled, expired)
* A delivery can only be approved before it starts
* A delivery can only be completed once it's been approved
* A delivery must be completed within the access window provided with each delivery
* A delivery can only be cancelled when it's in created or approved state

## Structure

```
{
  "state": "created",
  "accessWindow": {
    "startTime": "2019-12-13T09:00:00Z",
    "endTime": "2019-12-13T11:00:00Z"
  },
  "receipient": {
    "name": "John Doe",
    "address": "Merchant Road, London",
    "email": "john.doe@mail.com",
    "phoneNumber": "+44123123123123"
  },
  "order": {
    "orderNumber": "12209667",
    "sender": "Ikea"
  }
}
```

## Prerequisites
* Visual Studio Code
* .Net 5.0.200
* SQLite
* Postman (or other)
* Docker

## Current Issues
1) When retreiving deliveries from the database, the nested classes come up as null. I suspect this has soemthing to do with the Dtos and how they are set up. I can only see the full json like the example above when I am adding a delivery.
2) When the delivery is outside the access window, it doesn't update automatically. It is only checking when trying to update the delivery state manually.
3) Docker error. The application runs correctly initially but when trying to make a HTTP call, I get a database error. This only happens in the container. When the project runs locally using dotnet run, there are no errors.

## Additional Functionality (Bonus)
* Data Storage (SQLite)
* Authentication
* Docker
* Documentation

## Running the project
As mentioned above there are currently two ways to run the project:

### Using Docker

To use this option follow these steps:
1) Make sure Docker is installed locally
2) Using cmd/terminal navigate to the project directory after it's cloned
3) Run command: `docker build -t delivery-system .`
4) Once the above is done, run `docker run -d -p 8080:80 delivery-system`
5) Use `docker ps` to make sure the container is running

### Using dotnet

To use this option follow these steps:
1) If using cmd/terminal, navigate to cloned directory and run commane `dotnet run`
2) If using using Visual Studio, simple press the green play button

## Instructions
The project is authenticated hence to make any calls you will need to have login details.

To start using the project follow these steps:
1) Open Postman or another HTTP tool to make a HTTP request using port number 5000 or if using docker the specified port number in the docker run command
2) Make a call to `http://localhost:5000/auth/Register` (or other port number) using POST
3) In the body section, add json for your username and password for example: `{ "username": "test", "password": "123456" }`
4) Press send and if the username doesn't exists, you should get a 200 code, otherwise you will get an error saying 'User already exists'
5) Once registered, then make a call to `http://localhost:5000/auth/Login` (or other port number) using POST
6) In the body section, use the same json used to register with your username and password
7) If login is successful, in the response, under data, you should see a long key
8) Copy that key
9) Make a request to add a delivery using `http://localhost:5000/delivery` (or other port number) using POST
10) In the body section, add the json with all the details or the delivery, just like in the example shown at the top of the README file - No need to add an id as it automatically increases
11) In the Headers section, under the Key column, type Authorization and under the Value column, type Bearer followed by a space and then copy the key from above
12) Press send and you should get a response of all the deliveries currently in the database including the one just added
13) Other calls that can be made are (they all require the key from the login HTTP call:
* `http://localhost:5000/delivery/1` using GET - This is to view a single delivery by calling it by its Id - No body needed
* `http://localhost:5000/delivery/GetAll` using GET - This is to view all the deliveries stored in the database - No body needed
* `http://localhost:5000/delivery` using PUT - This is to edit the state of a delivery - In the body, make sure the json has the Id of the delivery and the new state
* `http://localhost:5000/delivery/1` using DELETE - This is to delete a delivery from the database using its Id  - No body needed

## Future Improvements
In the future, in order to make the project more reliable and improve it in general, the following features could be added:
* Fix current issues (listed above)
* Unit Testing
* Logging
* Merge the User model with the Recipient model 
* Have a separate consumer model (which will have different rules to the consumer)
