# FinanceTracker Project Tracking

## Current Status

Project Name: FinanceTracker

Current Version: v0.3

Current Stage:

🟡 Stage 2 - MVC Client Integration (Hybrid Client)

Current Focus:

* ASP.NET Core MVC Client (consuming RESTful API)
* Hybrid Client Architecture (Razor loading + Javascript AJAX modifications)
* Handling CORS, API redirect blocks, and state synchronization

Current Task:

* [x] Integrate Category CRUD with AJAX (List, Add, Delete, Edit)
* [x] Integrate Transaction CRUD with AJAX (List, Add, Delete, Edit) - In Progress
* [ ] Add Net Balance and summary cards to Transactions View - In Progress

Current Learning Progress:

### Web API & Client

Completed Chapters:

* Chapter 1 - RESTful Service
* Chapter 2 - Models and EF Core
* Chapter 3 - Content Negotiation & OData
* Chapter 4 - DTO & AutoMapper
* Chapter 5 - MVC Client Integration (Categories CRUD)

Current Chapter:

* Chapter 6 - Hybrid Client & AJAX State Updates (Transactions & Balance)

Next Chapter:

* Chapter 3 - Media Formatters & Content Negotiation

### Flutter

Current Module On Class:

* Module 9 - Local Storage

Project Status:

* Not Started Yet

Reason:

* Backend Foundation must be completed first.

---

# Stage 1 - Backend Foundation

Goal:

Build a fully functional FinanceTracker RESTful API.

Status:

🟡 In Progress

---

## Requirement Analysis

* [x] Define Project Scope
* [x] Create SRS
* [x] Define Core Features

---

## Database Design

* [x] Design Category Entity
* [x] Design Transaction Entity
* [x] Design Relationships

---

## EF Core Setup

* [x] Install EF Core Packages
* [x] Create FinanceDbContext
* [x] Configure SQL Server Connection
* [x] Configure Fluent API
* [x] Create Initial Migration
* [x] Update Database

---

## Entities

* [x] Category
* [x] Transaction
* [x] TransactionType Enum
* [ ] SavingGoal

---

## Category Module

### API Development

* [x] GET All Categories
* [x] GET Category By Id
* [x] POST Category
* [x] DELETE Category

### Testing

* [ ] Swagger Testing
* [ ] Postman Testing

Status:

🟡 Code Complete - Testing Pending

---

## Transaction Module

### API Development

* [x] GET All Transactions
* [x] GET Transaction By Id
* [x] POST Transaction
* [x] PUT Transaction
* [x] DELETE Transaction

### Testing

* [ ] Swagger Testing
* [ ] Postman Testing

Status:

🟡 Code Complete - Testing Pending

---

# Upcoming Stages

## Stage 2 - Multi-Wallet System (Hệ thống đa ví)

* [ ] Design Wallet Entity (Id, Name, InitialBalance, CurrentBalance)
* [ ] Create Migration and update Database
* [ ] Update Transaction Entity: Add relationship (Transaction belongs to one Wallet)
* [ ] Update DB context and configure cascade delete / restrict behavior
* [ ] Write Wallet CRUD APIs
* [ ] Implement Wallet auto-balance updates in Transactions Controller (Creating/Editing/Deleting transactions updates Wallet balance)
* [ ] MvcClient Integration:
  * [ ] Wallet Management View (AJAX list/create/edit/delete)
  * [ ] Update Transactions View to support Wallet dropdown selection
  * [ ] Implement Overall Portfolio Summary (Total Balance = Sum of all Wallet balances)

Status:

⚪ Not Started

---

## Stage 2A - Advanced Backend

* Content Negotiation
* XML Formatter
* OData
* DTO
* Validation
* Repository Pattern

Status:

⚪ Not Started

---

## Stage 3 - Security

* Authentication
* Authorization
* JWT

Status:

⚪ Not Started

---

## Stage 4 - Business Features

* Dashboard
* Saving Goal
* Reports

Status:

⚪ Not Started

---

## Stage 5 - Flutter Foundation

* Widgets
* Navigation
* State Management

Status:

⚪ Not Started

---

## Stage 6 - Flutter + API Integration

* HTTP Requests
* JSON Parsing
* API Consumption

Status:

⚪ Not Started

---

## Stage 7 - Mobile Production Features

* Local Storage
* Session Management
* Offline Data

Status:

⚪ Not Started

---

## Stage 8 - Software Engineering

* Clean Architecture
* CQRS
* MediatR
* Unit Of Work

Status:

⚪ Not Started

---

## Stage 9 - Docker

* Dockerfile
* Containerization

Status:

⚪ Not Started

---

## Stage 10 - Docker Compose

* API + Database Integration

Status:

⚪ Not Started

---

## Stage 11 - CI

* GitHub Actions
* Automated Build

Status:

⚪ Not Started

---

## Stage 12 - CD

* Automatic Deployment
* Cloud Hosting

Status:

⚪ Not Started

---

## Stage 13 - Monitoring

* Serilog
* Seq
* Grafana
* Prometheus

Status:

⚪ Not Started

---

## Stage 14 - gRPC

* Service Communication

Status:

⚪ Not Started

---

## Stage 15 - Microservices

* Auth Service
* Transaction Service
* Report Service
* API Gateway

Status:

⚪ Not Started

---

## Stage 16 - Portfolio Ready

* Documentation
* Architecture Diagram
* Deployment Guide
* Demo Video

Status:

⚪ Not Started
