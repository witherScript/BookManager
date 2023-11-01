# Book Manager

## Overview

This application implements RBAC using the Microsoft Identity suite. At its core, it allows users to maintain a collection of books, parsed as Book Data Transfer Objects from the Google Books API. 

The entrypoint automates sysadmin configuration on start-up, creating admin and user roles after the initial Entity-Framework migration. **Note:** Admin secret is NOT stored securely at this point. This repository is a work in progress.

## Technologies Used
1. Newtonsoft.JSON
2. Entity Framework Core
3. LINQ
4. RestSharp
5. Microsoft Identity
6. Google Books API

## Set-up

1. Clone this repository
2. run ```dotnet resotre``` and ```dotnet ef database update``` (in that order) to configure your local MySQL envrionment to the project's specs
3. run ```dotnet watch run``` to host the project on a Kestrel server




