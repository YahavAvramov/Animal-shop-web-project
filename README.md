# About
This project represents a pet store whose role is to display, sell, add, respond to, and synchronize the details about the animals in the store.
#### `Users side`
As a user, you can get details about the animal and comment on the animal's page\
As a store employee/manager you can add categories, delete animals or inappropriate comments, add animals and change the details of the animals

#### `Data`
All information is saved locally on the computer using sqlite\
When running the application for the first time, the database is created\
The data can be accessed using the Repositories in \AnimalWeb\Repositories \ 
At \AnimalWeb\Data\Context.cs you can find the OnModelCreating function that creates the base data


At AnimalWeb\appsettings.json you can find the path to the database - "DefaultConnection": "Data Source=c:\\temp\\aminalShopData.db",
you can change this path to be more accessible for you

#### `technologies`
The project uses the following technologies:\
ASP.NET\
sqlite\
C#

## `project demonstration`
youtube - https://www.youtube.com/watch?v=Sb8XqdWliR0




