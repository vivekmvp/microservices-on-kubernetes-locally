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


----

# Kubernetes

Kubernetes is a portable, extensible open-source platform for managing and orchestrating containerized workloads.

Main benefits of using Kubernetes are:

- Self-healing of containers. An example would be restarting containers that fail or replacing containers.
- Scaling deployed container count up or down dynamically, based on demand.
- Automating rolling updates and rollbacks of containers.
- Managing storage.
- Managing network traffic.
- Storing and managing sensitive information, such as usernames and passwords.


## Download and Install Kubectl 

(If you haven't already)

Download and Install Kubectl from https://kubernetes.io/docs/tasks/tools/install-kubectl-windows/

<kbd>![image](https://user-images.githubusercontent.com/30829678/187966291-e7a78efe-a9df-4fc5-a93a-39915a226b0c.png)</kbd>



----

# Deploy a microservice container to Kubernetes

## Deploy both backend and frontend services to Kubernetes

Create a deployment yaml file for the backend service.  You describe what you want Kubernetes to do through a YAML file.

## backend-deploy.yaml file

```
---
apiVersion: apps/v1
kind: Deployment
metadata:
  name: onlinestorebackend
spec:
  replicas: 1
  template:
    metadata:
      labels:
        app: onlinestorebackend
    spec:
      containers:
      - name: onlinestorebackend
        image: vivekmvp/onlinestorebackend:latest
        ports:
        - containerPort: 80
        env:
        - name: ASPNETCORE_URLS
          value: http://*:80
  selector:
    matchLabels:
      app: onlinestorebackend
---
apiVersion: v1
kind: Service
metadata:
  name: onlinestorebackend
spec:
  type: ClusterIP
  ports:
  - port: 80
  selector:
    app: onlinestorebackend
```

## frontend-deploy.yaml file

```
---
apiVersion: apps/v1
kind: Deployment
metadata:
  name: onlinestorefrontend
spec:
  replicas: 1
  template:
    metadata:
      labels:
        app: onlinestorefrontend
    spec:
      containers:
      - name: onlinestorefrontend
        image: vivekmvp/onlinestorefrontend:latest
        ports:
        - containerPort: 80
        env:
        - name: ASPNETCORE_URLS
          value: http://*:80
        - name: backendUrl
          value: http://onlinestorebackend
  selector:
    matchLabels:
      app: onlinestorefrontend
---
apiVersion: v1
kind: Service
metadata:
  name: onlinestorefrontend
spec:
  type: LoadBalancer
  ports:
  - port: 80
  selector:
    app: onlinestorefrontend
```    
