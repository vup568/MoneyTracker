# FinanceTracker Master Roadmap

> **2026-07-11 update:** The product is now `PersonalLifeOS`, with Finance as its first bounded module. The active learning and delivery order is maintained in [P1_PRODUCT_PLAN.md](P1_PRODUCT_PLAN.md). P1-00 (Clean Architecture lite transition) is complete; P1-01 (Identity and user ownership) is next. The legacy roadmap below is retained as long-term learning context, not as the active implementation order.

## Vision

Build a production-like Personal Finance Management System while mastering:

* ASP.NET Core Web API
* Flutter
* SQL Server
* RESTful API
* OData
* JWT Authentication
* gRPC
* Microservices
* Docker
* CI/CD
* Cloud Deployment
* Monitoring

End Goal:

FinanceTracker

├── FinanceTracker.API
├── FinanceTracker.Mobile
├── Docker
├── GitHub Actions
├── CI/CD
├── Deployment
├── Monitoring
└── Microservices

---

# STAGE 1 - Backend Foundation

Status: IN PROGRESS

Goal:

Build a complete RESTful API.

Technologies:

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server

Topics:

* RESTful API
* Entity
* DbContext
* Migration
* Dependency Injection
* Routing
* IActionResult
* CRUD

Features:

## Category

* Create Category
* Get Categories
* Get Category By Id
* Delete Category

## Transaction

* Create Transaction
* Get Transactions
* Update Transaction
* Delete Transaction

Deliverable:

FinanceTracker.API v1

---

# STAGE 2 - Advanced Backend

Goal:

Build enterprise-level API features.

Topics:

* Content Negotiation
* XML Formatter
* OData
* Validation
* DTO
* Repository Pattern

Features:

* Filtering
* Sorting
* Pagination
* Validation Rules

Examples:

GET /odata/transactions?$filter=Amount gt 100000

Deliverable:

FinanceTracker.API v2

---

# STAGE 3 - Security

Goal:

Secure the system.

Topics:

* JWT
* Authentication
* Authorization
* Claims

Entities:

* User
* Role

Features:

* Register
* Login
* JWT Token
* Protected APIs

Deliverable:

FinanceTracker.API v3

---

# STAGE 4 - Business Features

Goal:

Complete FinanceTracker core functionality.

Features:

## Dashboard

* Current Balance
* Monthly Income
* Monthly Expense
* Saving Summary

## Saving Goal

* Create Goal
* Update Goal
* Track Progress

## Reports

* Weekly Report
* Monthly Report
* Yearly Report

Deliverable:

FinanceTracker.API v4

---

# STAGE 5 - Flutter Foundation

Goal:

Build FinanceTracker Mobile Client.

Technologies:

* Flutter
* Dart

Topics:

* Widgets
* Navigation
* State Management
* Responsive UI

Screens:

* Splash Screen
* Login Screen
* Dashboard Screen

Deliverable:

FinanceTracker.Mobile v1

---

# STAGE 6 - Flutter + API Integration

Goal:

Connect Flutter to Web API.

Topics:

* HTTP
* JSON
* Async/Await

Features:

* Login
* Category Management
* Transaction Management

Deliverable:

FinanceTracker.Mobile v2

---

# STAGE 7 - Mobile Production Features

Goal:

Complete mobile application.

Topics:

* Local Storage
* Session Management
* Offline Data

Features:

* Remember Login
* Cache Data
* Dark Mode

Deliverable:

FinanceTracker.Mobile v3

---

# STAGE 8 - Software Engineering

Goal:

Refactor project using industry practices.

Topics:

* Clean Architecture
* Repository Pattern
* Unit Of Work
* CQRS
* MediatR

Deliverable:

FinanceTracker.API v5

---

# STAGE 9 - Docker

Goal:

Containerize the system.

Topics:

* Docker
* Dockerfile
* Images
* Containers

Tasks:

* Dockerize API
* Dockerize Database

Deliverable:

Dockerized FinanceTracker

---

# STAGE 10 - Docker Compose

Goal:

Run the whole system locally.

Services:

* API
* SQL Server

Tasks:

* docker-compose.yml

Deliverable:

One-command startup

docker compose up

---

# STAGE 11 - CI

Goal:

Automate build process.

Technology:

* GitHub Actions

Tasks:

* Restore
* Build
* Test

Trigger:

git push

Deliverable:

Automatic Build Pipeline

---

# STAGE 12 - CD

Goal:

Automatic deployment.

Targets:

* Azure
* VPS
* Railway
* Render

Tasks:

* Publish
* Deploy

Deliverable:

Online FinanceTracker

---

# STAGE 13 - Monitoring

Goal:

Observe application health.

Topics:

* Serilog
* Seq
* Grafana
* Prometheus

Tasks:

* Request Logging
* Error Tracking
* Performance Metrics

Deliverable:

Production Monitoring

---

# STAGE 14 - gRPC

Goal:

Learn service-to-service communication.

Tasks:

* Monthly Summary Service
* Dashboard Summary Service

Deliverable:

gRPC Integration

---

# STAGE 15 - Microservices

Goal:

Transform monolithic architecture.

Services:

* Auth Service
* Transaction Service
* Report Service
* Notification Service

Infrastructure:

* API Gateway

Deliverable:

Microservices Architecture

---

# STAGE 16 - Portfolio Ready

Goal:

Prepare for internship and job applications.

Requirements:

* Documentation
* Architecture Diagram
* API Documentation
* Deployment Guide
* Demo Video

Final Product:

Production-like FinanceTracker Ecosystem
