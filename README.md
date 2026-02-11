# TaskManagerPoC - .NET 8 Backend API 🚀

This repository is a Proof of Concept (PoC) for a RESTful Backend service built with C# and .NET 8. It was developed to demonstrate a solid understanding of modern backend architecture, containerization, and data interoperability.

## 🎯 About the Author & Project

I am a Software Developer and Master's Student in Water Resources, where I currently apply **Machine Learning (LSTM)** for river flow prediction. As a **Certified AWS Cloud Practitioner** and **Developer Girls Ambassador**, I built this project to expand my expertise from Python and PHP into the robust .NET ecosystem.

### Key Technical Achievements:

- **Clean CRUD Architecture**: Implemented with ASP.NET Core 8 and Entity Framework Core.
- **Automated Data Lifecycle**: Integrated auto-migrations for SQLite, ensuring the database is ready upon container startup.
- **Data Engineering Bridge**: Custom endpoint to export relational data to CSV, facilitating integration with data analysis pipelines.
- **DevOps Ready**: Fully orchestrated using Docker and Docker Compose.

## 🛠 Tech Stack

- **Framework**: ASP.NET Core 8.0 (Web API)
- **Language**: C# 12
- **ORM**: Entity Framework Core (EF Core)
- **Database**: SQLite (Portable & Local)
- **Documentation**: Swagger/OpenAPI
- **Environment**: Docker & Docker Compose

## 🚀 Getting Started

### Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) or Docker Engine.
- [Docker Compose](https://docs.docker.com/compose/).

### Running the Application

The easiest way to run the PoC is using Docker Compose, which handles networking, environment variables, and data persistence:

1.  **Clone the repository**:

    ```bash
    git clone [https://github.com/ana-lapas/task-manager-poc.git](https://github.com/ana-lapas/task-manager-poc.git)
    cd TaskManagerPoC
    ```

2.  **Start the environment**:

    ```bash
    docker-compose up -d
    ```

3.  **Access the API Documentation**:
    Open your browser and navigate to: `http://localhost:8080/swagger/index.html`

## 📁 Key Features

- **POST /api/Tasks**: Create new tasks (ID is auto-generated).
- **GET /api/Tasks/export**: Generate a CSV file of all tasks for data analysis.
- **Persistence**: Database state is preserved in the `./database` folder on the host machine via Docker Volumes.

---

**Connect with me:**

- **LinkedIn**: [https://www.linkedin.com.br/in/ana-paula-leao]
- **Developer Girls Community**: Ambassador.
