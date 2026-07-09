# Enterprise AI Nexus - Architecture

## Architecture Goal

Enterprise AI Nexus is designed as an industry-inspired smart manufacturing platform that connects ERP, MES, SCADA, AI, dashboards, and reporting.

## High-Level Flow

Customer Order
↓
ERP Module
↓
Production Order
↓
MES Module
↓
Work Order
↓
SCADA Module
↓
Machine Sensor Data
↓
AI Module
↓
Prediction and Insights
↓
Executive Dashboard

## Core System Components

### 1. Angular Frontend
Provides dashboards and user screens for executives, managers, supervisors, and engineers.

### 2. ASP.NET Core Web API
Handles business logic, APIs, authentication, authorization, and communication between modules.

### 3. SQL Server Database
Stores business, production, machine, inventory, quality, HR, finance, and reporting data.

### 4. Entity Framework Core
Used for application data access, relationships, migrations, and CRUD operations.

### 5. Dapper / Optimized SQL
Planned for complex reports and high-performance dashboard queries.

### 6. Python FastAPI AI Service
Provides AI predictions for machine maintenance, inventory forecasting, and quality risk.

## Version 1 Scope

- ERP basics
- MES basics
- SCADA sensor simulation
- AI prediction concept
- Executive dashboard
- Reporting foundation
