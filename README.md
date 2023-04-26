# Prerequisites
.NET 5.0 SDK
Docker

# Run Raven

docker run --rm -d -p 8080:8080 -p 38888:38888 -v c:/RavenDb/Data:/opt/RavenDB/Server/RavenData --name RavenDb-WithData -e RAVEN_Setup_Mode=None -e RAVEN_License_Eula_Accepted=true -e RAVEN_Security_UnsecuredAccessAllowed=PrivateNetwork ravendb/ravendb

# Create Database

Navigate to http://localhost:8080/ and Add database named "Northwind"