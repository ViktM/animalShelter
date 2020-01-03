# Animal Shelter

This web application is designed for a small animal shelter. It enables all users to browse animals available for adoption. Admin users can use full CRUD functionality to maintain a database of animals available for adoption, users and to track adoptions.

# Description

This is .Net application in C# using Microsoft SQL database hosted in a Docker container. Seed data is provided.   

# Prerequisites

Minimum requirements and recommended stack to run the app:
- .Net Core v3.0.0
- Microsoft Entity Framework v3.0.0
- Microsoft VisualStudio Web CodeGeneration Design v3.0.0
- Microsoft MSSQL Server v2017-latest
- Docker
- Azure Data Studio
- Stripe.net v34.7.0
- MailKit v2.4.1
- JetBrains Rider v2019.2.2


Docker Terminal Command:\

docker run -e 'ACCEPT_EULA=Y' \
-e 'SA_PASSWORD=P@ssw0rd!' \
-p 1433:1433 \
--name sql1 \
-d microsoft/mssql-server-linux:2017-latest