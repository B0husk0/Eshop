# 🛒 Eshop API

A modern REST API for managing products and categories in an e-shop application.  
The project features **API versioning (v1, v2)**, **RabbitMQ messaging**, and **SQLite database** with data persistence.

---

## ✨ Features

- 🔄 **API Versioning** - Supports v1 and v2 endpoints
- 🐰 **RabbitMQ Integration** - Asynchronous messaging for product updates
- 💾 **SQLite Database** - Lightweight, persistent data storage
- 📚 **Swagger Documentation** - Interactive API documentation
- 🐳 **Docker Support** - Easy deployment with Docker Compose
- 🧪 **Unit Testing** - Comprehensive test coverage
- 📊 **Background Processing** - Queue-based operations

---

## 📋 Prerequisites

Before running the project, ensure you have:

- [Docker](https://docs.docker.com/get-docker/) (20.x or later)
- [Docker Compose](https://docs.docker.com/compose/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (for local development)
- Optional: [Postman](https://www.postman.com/) or `curl` for API testing

---

## 🚀 Quick Start

### 1. Run with Docker Compose (Recommended)

```bash
git clone <repository-url>
cd Eshop
docker compose up -d
```

This will start:
- **API** → Available at http://localhost:5000
- **RabbitMQ** → Port 5672, Management UI at http://localhost:15672
- **SQLite** → Database persisted as `eshop.db` in Docker volume

**Swagger UI:** 👉 http://localhost:5000/swagger

### 2. Run Locally (Development)

For local development without Docker:

```bash
cd Eshop.Api
dotnet restore
dotnet build
dotnet run
```

**API will be available at:** 👉 http://localhost:5000/swagger

---

## 🧪 Running Tests

Execute the test suite:

```bash
dotnet test
```

For detailed test results with coverage:

```bash
dotnet test --verbosity normal --collect:"XPlat Code Coverage"
```

---

## 📡 API Usage Examples
### V1 API - Basic Operations

#### Get all products
```bash
curl http://localhost:5000/api/v1/Products
```

#### Get product by ID
```bash
curl http://localhost:5000/api/v1/Products/1
```

#### Create a new product
```bash
curl -X POST http://localhost:5000/api/v1/Products \
  -H "Content-Type: application/json" \
  -d '{
    "name": "iPhone 16",
    "description": "Latest Apple smartphone",
    "price": 1199.99,
    "quantity": 10,
    "categoryId": 1
  }'
```

#### Update a product
```bash
curl -X PUT http://localhost:5000/api/v1/Products/1 \
  -H "Content-Type: application/json" \
  -d '{
    "id": 1,
    "name": "iPhone 16 Pro",
    "description": "Premium Apple smartphone",
    "price": 1399.99,
    "quantity": 5,
    "categoryId": 1
  }'
```

#### Delete a product
```bash
curl -X DELETE http://localhost:5000/api/v1/Products/1
```

### V2 API - With RabbitMQ Messaging

#### Update product stock (via RabbitMQ)
```bash
curl -X PATCH http://localhost:5000/api/v2/Products/rabbit/1/stock \
  -H "Content-Type: application/json" \
  -d '{"quantity": 15}'
```

#### RabbitMQ Management
View messages and queues in the Management UI:
- **URL:** 👉 http://localhost:15672
- **Credentials:** `guest` / `guest`

---

## 📁 Project Structure

```
Eshop/
├── Eshop.Api/                 # Main API project (.NET 8)
│   ├── Controllers/           # API controllers (v1, v2)
│   ├── Data/                  # EF Core DbContext & SQLite setup
│   ├── Models/                # Data models & DTOs
│   ├── Services/              # Business logic services
│   ├── Messaging/             # RabbitMQ producers & consumers
│   ├── Queue/                 # Background workers & job processing
│   ├── Middleware/            # Custom middleware components
│   ├── Configuration/         # App configuration & settings
│   └── Dockerfile             # Docker configuration
├── Eshop.Tests/               # Unit & integration tests
├── docker-compose.yml         # Docker Compose setup
├── .gitignore                 # Git ignore rules
└── README.md                  # This file
```

---

## 🔧 Configuration

### Environment Variables

| Variable | Description | Default |
|----------|-------------|---------|
| `ASPNETCORE_ENVIRONMENT` | Application environment | `Development` |
| `RABBITMQ_HOST` | RabbitMQ server host | `localhost` |
| `RABBITMQ_PORT` | RabbitMQ server port | `5672` |
| `DATABASE_PATH` | SQLite database path | `./eshop.db` |

### Docker Compose Environment

The `docker-compose.yml` file includes:
- **API Service** - Eshop API application
- **RabbitMQ Service** - Message broker with management UI
- **Volume** - Persistent SQLite database storage

---

## 🐛 Troubleshooting

### Common Issues

**Port Already in Use**
```bash
# Check what's using port 5000
netstat -ano | findstr :5000
# Kill the process or use different port
```

**RabbitMQ Connection Issues**
```bash
# Check RabbitMQ container logs
docker logs eshop-rabbitmq-1
```

**Database Issues**
```bash
# Reset database (removes all data)
docker compose down -v
docker compose up -d
```

---

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 📞 Support

For support and questions:
- 📧 Create an issue in the repository
- 📖 Check the [documentation](docs/)
- 💬 Join our community discussions
