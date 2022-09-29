# Run Microservice On Docker Locally
Running microservices and web on Docker Locally :star_struck:

-----

- We will be practically implementing [Build your first microservice with .NET](https://learn.microsoft.com/en-us/training/paths/create-microservices-with-dotnet/)
- We will be using our [Indepth-microservices code template](https://github.com/vivekmvp/indepth-microservices) to begin with. :+1:

----

# High-level Architecture of Application

![image](https://user-images.githubusercontent.com/30829678/192071871-fdd7c8d2-2f9a-4262-a1cd-d32afe211ff1.png)

----

# Creating a Docker File

## Creating a Docker File for Frontend web

```
  FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
  WORKDIR /src
  COPY frontend.csproj .
  RUN dotnet restore
  COPY . .
  RUN dotnet publish -c release -o /app

  FROM mcr.microsoft.com/dotnet/aspnet:6.0
  WORKDIR /app
  EXPOSE 80
  EXPOSE 443
  COPY --from=build /app .
  ENTRYPOINT ["dotnet", "frontend.dll"]
```



## Creating a Docker File for Backend Api

And similarly add Docker file code for Backend api

----

# Build and Run the Docker Image locally

## Build Docker Image

Go to Backend code directory and build the docker image.

```
docker build -t onlinestorebackend .
```

![image](https://user-images.githubusercontent.com/30829678/192162597-a01be5e2-4b58-4a52-809c-b764252b3950.png)



And similarly for Frondend


```
docker build -t onlinestorefrontend .
```

![image](https://user-images.githubusercontent.com/30829678/192162545-0b6a15e1-851f-4eec-b2ab-f49259ababc0.png)

![image](https://user-images.githubusercontent.com/30829678/192162561-435c5687-5d9b-48b2-8238-3645279f6b96.png)


You can verify that image was build successfully in Docker Desktop locally

![image](https://user-images.githubusercontent.com/30829678/192162614-67d298ac-0186-41b2-8936-10c140cceb9c.png)



## Run Docker Image Locally

Go to Backend code directory and run the docker image.


```
docker run -it --rm -p 5021:80 --name onlinestorebackendcontainer onlinestorebackend
```

Verifying by running the backend api endpoint

```
http://localhost:5021/product
```

![image](https://user-images.githubusercontent.com/30829678/192166967-fdfe544c-3034-40c0-a56d-65d53372117f.png)




And similarly for Frondend

```
docker run -it --rm -p 5067:80 --name onlinestorefrontendcontainer onlinestorefrontend
```

Verifying by running the frontend url

```
http://localhost:5067
```

![image](https://user-images.githubusercontent.com/30829678/192105629-11b9cf64-8933-4dc0-88ce-8f853e3a2b07.png)





----

# Running the docker image using docker-compose file

## Create a docker-compose.yaml file

```
version: '3.4'

services: 

  frontend:
    image: onlinestorefrontend
    build:
      context: frontend
      dockerfile: Dockerfile
    environment: 
      - backendUrl=http://backend
    ports:
      - "5067:80"
    depends_on: 
      - backend


  backend:
    image: onlinestorebackend
    build: 
      context: backend
      dockerfile: Dockerfile
    ports: 
      - "5021:80"
```      

**Run the following command to Build image using docker-compose.yaml file**

```      
docker-compose build
```      

![image](https://user-images.githubusercontent.com/30829678/192371691-0536995a-4680-4865-9f91-9be709f64797.png)

<br/>

**Run the following command to Run image using docker-compose.yaml file**

```      
docker-compose up
```      
![image](https://user-images.githubusercontent.com/30829678/192371800-caef0a14-748f-4a04-93b7-7ae2f471cf5f.png)


Verifying by running the frontend url

```
http://localhost:5067
```

![image](https://user-images.githubusercontent.com/30829678/192105629-11b9cf64-8933-4dc0-88ce-8f853e3a2b07.png)
