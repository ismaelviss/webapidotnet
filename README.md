# introduccion
### version
dotnet --version
### sdk instalados y demas informacion del la maquina
dotnet --info
# crear un nuevo proyecto
### muestra las plantillas disponibles
dotnet new -l
### creas una carpeta con el nombre que quieres que tenga tu proyecto y dentro de ella ejecutas el siguiente comando
dotnet new webapi
### ejecutar el proyecto
dotnet run

# docker of Postgres
### command for run postgres
docker run --name postgres-JSNT -p 55000:5432 -e POSTGRES_PASSWORD=postgrespw -d postgres
### pgAdmin4
Log in:
Username: pgadmin4@pgadmin.org
Password: admin
Click Add New Server and fill in the following fields:
Server Name: pg (or whatever you prefer)
On the Connection tab:
Host: host.docker.internal
Port: 55000
Username: postgres
Password: postgrespw

docker run -p 5050:80 -e 'PGADMIN_DEFAULT_EMAIL=pgadmin4@pgadmin.org' -e 'PGADMIN_DEFAULT_PASSWORD=admin' -d --name pgadmin4 dpage/pgadmin4
### PostgresSQL from your terminal
docker exec -it postgres-JSNT psql -U postgres

# postman project link
https://www.getpostman.com/collections/54c75457b1695db921d6
