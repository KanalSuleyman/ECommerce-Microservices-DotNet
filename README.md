# **DotNet Microservices Architecture**

This project is a modular eCommerce system built with **.NET Core**, showcasing multiple microservices, including **Catalog**, **Basket**, **Discount**, and **Ordering** services. The system leverages **CQRS**, **Vertical Slice Architecture**, and uses **PostgreSQL** with **Marten** to transform it into a **Document DB**. The project is containerized using **Docker** for scalability, and **Carter** is used for implementing minimal API endpoint definitions. **RabbitMQ** is integrated for messaging between microservices, and **YARP** is used as the API Gateway for routing client requests.

## **Table of Contents**

- [Architecture](#architecture)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Microservices Overview](#microservices-overview)
- [Database](#database)
- [Acknowledgments](#acknowledgments)

---

## **Architecture**

The project is built following a **microservices architecture** to ensure modularity, scalability, and maintainability. Each microservice is responsible for its domain and can be independently developed and deployed.

- **Vertical Slice Architecture:** Divides the system into features or slices, making it easier to maintain and test.
- **CQRS (Command Query Responsibility Segregation):** Separates read and write operations to optimize performance and scalability.
- **Marten**: Used to convert **PostgreSQL** into a **Document DB**.
- **Carter**: Simplifies the definition of minimal API endpoints, enhancing the modularity of services.
- **RabbitMQ**: Used as the messaging broker to handle asynchronous communication between microservices.
- **YARP API Gateway**: Handles routing client requests to different microservices, ensuring proper load balancing and security.
- **Dockerized Microservices:** Each microservice runs inside a Docker container for easy orchestration and deployment.

## **Features**

- **Catalog Microservice:** Manages product information with CQRS and Mediator patterns, while using **Marten** to store documents in PostgreSQL.
- **Basket Microservice:** Stores user-specific shopping cart information using Redis.
- **Discount Microservice:** Manages discount rules and coupon codes.
- **Ordering Microservice:** Handles order creation and processing with a clean architecture approach.
- **API Gateway (YARP):** Provides an entry point for client apps and routes requests to microservices.
- **RabbitMQ Messaging:** Facilitates communication between microservices in an asynchronous manner.
- **Client Applications:** ASP.NET Core API Gateway handles client requests to microservices.

## **Technologies Used**

- **.NET Core**: Backend framework for building microservices.
- **CQRS with MediatR**: For separation of commands and queries.
- **Vertical Slice Architecture**: Feature-focused structure for better separation of concerns.
- **Carter**: Minimal API endpoint definition for a cleaner microservice interface.
- **Marten**: Converts PostgreSQL to a document database for the **Catalog Microservice**.
- **PostgreSQL**: Relational database for persistent storage in **Catalog Microservice**.
- **Redis**: Used in Basket microservice for storing session-based data.
- **RabbitMQ**: Message broker for communication between microservices.
- **YARP (Yet Another Reverse Proxy)**: API Gateway for routing traffic between client apps and microservices.
- **Fluent Validation**: For validating incoming requests.
- **Docker**: Containerization of microservices for easy deployment.
- **Swagger**: API documentation and testing.

## **Microservices Overview**

### **Catalog Microservice**
- Uses **PostgreSQL** with **Marten** for document-based data storage.
- Exposes API endpoints for CRUD operations on products with **Carter**.
- Follows **Vertical Slice Architecture** for organizing code by features.
  
### **Basket Microservice**
- Uses **Redis** for session storage of basket data.
- Provides API endpoints to add/remove items from the basket.

### **Discount Microservice**
- Manages coupons and discount codes.
- Interacts with other services to apply discounts during checkout.

### **Ordering Microservice**
- Handles order creation, tracking, and processing.
- Uses **CQRS** to handle different query and command operations.
- Communicates with other microservices via **RabbitMQ**.

## **API Gateway (YARP)**

- **YARP (Yet Another Reverse Proxy)** is used as the API Gateway for routing incoming traffic to appropriate microservices. It ensures secure, efficient, and load-balanced communication between client applications and the back-end services.

## **Messaging (RabbitMQ)**

- **RabbitMQ** facilitates communication between microservices in an asynchronous and decoupled manner. It is used for handling tasks such as placing orders, inventory updates, and processing discount coupons in the background without blocking the main operations.

## **Database**

- **PostgreSQL with Marten**: Used for persistent data storage and document database conversion in the **Catalog Microservice**.
- **Redis**: In-memory data structure store for caching and session storage in the **Basket Microservice**.

## **Acknowledgments**

A huge shoutout to **[Mehmet Ozkaya](https://www.udemy.com/share/103fFg3@ZMK0DeIsW3tUqhTct69bdLVSkG0vbxlYLVeACZMR2CRm7xTFT-Q1JY_U9sCapxAXTQ==/)** and his excellent Udemy course **"Microservices Architecture and CQRS Patterns in .NET Core."** This project was built following the practices and teachings demonstrated in the course, which provided real-world examples and patterns for building scalable microservices.
