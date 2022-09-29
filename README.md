# Run Microservice On Kubernetes Locally
Running microservices and web on Kubernetes Locally :star_struck:

-----

- We will be practically implementing [Deploy a .NET microservice to Kubernetes](https://learn.microsoft.com/en-us/training/modules/dotnet-deploy-microservices-kubernetes/)
- We will be using our [Run Microservice On Docker Locally code template](https://github.com/vivekmvp/run-microservices-on-docker-locally) to begin with. :+1:

----

# High-level Architecture of Application

![image](https://user-images.githubusercontent.com/30829678/192071871-fdd7c8d2-2f9a-4262-a1cd-d32afe211ff1.png)

----

# Push the Docker Images to Docker Hub

Last time we have created Docker Images locally.  Now lets push those local docker images to docker hub.

![image](https://user-images.githubusercontent.com/30829678/193127849-21c9c1a6-6c69-4e9e-aec5-45bcd5d7a562.png)


## Commands to push local docker images to docker hub

In order to push local docker images to docker hub first we have to tag those images.

```
docker tag onlinestorefrontend [YOUR DOCKER USER NAME]/onlinestorefrontend
docker tag onlinestorebackend [YOUR DOCKER USER NAME]/onlinestorebackend
```
![image](https://user-images.githubusercontent.com/30829678/193128869-2d44cfa9-478b-477c-8f37-35767d8863f4.png)


And then push those images

```
docker push [YOUR DOCKER USER NAME]/onlinestorefrontend
docker push [YOUR DOCKER USER NAME]/onlinestorebackend
```
![image](https://user-images.githubusercontent.com/30829678/193129388-99051a6c-b24d-4bd7-a72d-747957f72de1.png)

