# 📚 BookVault

> *Your digital library, one login away.*

A sleek, modern library management system built with .NET Core MVC and secured with Google Authentication.

## ⚡ Quick Start

```bash
# Clone the knowledge repository
git clone https://github.com/yourusername/bookvault.git

# Set up Google Auth credentials in appsettings.json
# (See "Configuration" section below)

# Launch your library
dotnet run
```

## 🔖 Features

- **Google-Powered Login** - Secure access with just one click
- **Digital Bookshelf** - Track and manage your entire collection
- **Loan Management** - Monitor borrowed books and due dates
- **Member Portal** - Self-service reservation system
- **Smart Search** - Find books by title, author, genre, or ISBN
- **Reading Stats** - Visualize reading habits and preferences

## ⚙️ Authentication Setup

Add your Google credentials to `appsettings.json`:

```json
"Authentication": {
  "Google": {
    "ClientId": "YOUR_CLIENT_ID_HERE",
    "ClientSecret": "YOUR_CLIENT_SECRET_HERE"
  }
}
```

## 🛠️ Built With

- .NET Core 6.0
- ASP.NET Core MVC
- Entity Framework Core
- Google Authentication
- SQL Server / PostgreSQL
- Bootstrap 5

## 💡 Why BookVault?

Traditional library systems are complex and cumbersome. BookVault brings simplicity without sacrificing functionality. With Google Authentication, your patrons can start borrowing books within seconds of their first visit.

## 🔐 Role-Based Access

- **Visitors** - Browse the catalog
- **Members** - Borrow books and manage reservations
- **Librarians** - Process loans and returns
- **Administrators** - Manage users and system settings

---

*Bringing libraries into the digital age, one book at a time.*
