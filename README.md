# Hotel Booking API

## Overview
This **Hotel Booking API** is built using **ASP.NET Core** and **Entity Framework Core**.  
It provides a **RESTful API** for hotel room booking, ensuring:
- **A room cannot be double booked for any given night.**.
- **Any booking at the hotel must not require guests to change rooms at any point
during their stay**.
- **Booking numbers should be unique. There should not be overlapping at any
given time.
**.
- **A room cannot be occupied by more people than its capacity**.

## Project Structure
```
HotelBookingAPI/
Controllers/          ? API controllers (Hotel & Booking)
Data/                ? Database context & seeding logic
Migrations/          ? Entity Framework Core migrations
Models/              ? Entity models (Hotel, Room, Booking)
DTOs/                ? Data Transfer Objects (DTOs)
Services/            ? Business logic for hotel & booking operations
appsettings.json     ? API configuration settings
Program.cs           ? Application entry point
README.md            ? Project documentation (this file)

```

## Setup Instructions

### **Prerequisites**
Ensure you have:
- [.NET 7+ SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-configuration-manager)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)

### **Running the Project**
1. **Clone the repository**:
   ```sh
   git clone https://github.com/arshadte/HotelBookingAPI.git
   cd HotelBookingAPI
   ```

2. **Set up the database**:
   ```sh
   dotnet ef database update
   ```

3. **Run the API**:
   ```sh
   dotnet run
   ```

4. **Open the API in Swagger**:
   - Navigate to ?? `https://localhost:7088/swagger`

---

## **API Endpoints**
### **Hotels**
| Method | Endpoint | Description |
|--------|---------|-------------|
| `GET` | `/api/hotel/{name}` | Find a hotel by name |
| `GET` | `/api/hotel/{hotelId}/rooms` | Get available rooms in a hotel |

### **Bookings**
| Method | Endpoint | Description |
|--------|---------|-------------|
| `POST` | `/api/booking` | Create a booking |
| `GET` | `/api/booking/{bookingNumber}` | Get booking details |

### **Database Management**
| Method | Endpoint | Description |
|--------|---------|-------------|
| `POST` | `/api/management/seed` | Populate the database with test data |
| `POST` | `/api/management/reset` | Clear all data & reseed |

---

## **Testing the API**
### **Automated Testing**
To run **integration tests**, use:
```sh
dotnet test
```

---

### **Swagger**
Once the API is running:
1. Open **`https://localhost:7088/swagger`**
2. You will see a **web-based API documentation** with:
   - List of all **API endpoints**.
   - **Request & response examples**.
   - **"Try it out"** feature to test API calls.

---

## **Next Steps**
- **Improve API security (Authentication & Authorization)**
- **Add additional validation rules**
- **Add automated testing**
