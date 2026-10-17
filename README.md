Markdown
<div align="center">

# 🏛️ Local Information System
### *Локална Информационна Система*

Уеб приложение за управление, съхранение и предоставяне на локална информация за регион, институция или организация.

[![.NET](https://img.shields.io/badge/.NET-6.0%20%7C%207.0%20%7C%208.0%20%7C%209.0%20%7C%2010.0-512BD4?style=flat-square&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=flat-square&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-Database-512BD4?style=flat-square&logo=.net&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![MS SQL Server](https://img.shields.io/badge/MS%20SQL-Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/en-us/sql-server)

</div>

---

## 📌 Основни функционалности

* **Управление на съдържанието (CRUD):** Пълен жизнен цикъл за добавяне, редактиране, преглед и изтриване на информационни записи и статии.
* **Интелигентно филтриране:** Бързо търсене, сортиране и организиране по категории и тагове.
* **Съвременен интерфейс:** Напълно отзивчив (responsive) дизайн, оптимизиран за мобилни устройства, таблети и десктоп екрани.

---

## 🛠️ Използвани технологии

| Категория | Технологии |
| :--- | :--- |
| **Backend** | C# / .NET Core (ASP.NET Core MVC / Web API) |
| **Database & ORM** | MS SQL Server, Entity Framework Core |
| **Frontend** | HTML5, CSS3, JavaScript, Bootstrap / Tailwind CSS |
| **Environment** | Visual Studio 2022 / VS Code, .NET SDK |

---

## 🚀 Инсталация и стартиране

### Предварителни изисквания
Уверете се, че разполагате със следния софтуер на вашата машина:
* [.NET SDK](https://dotnet.microsoft.com/) (6.0 до 10.0)
* [MS SQL Server](https://www.microsoft.com/en-us/sql-server) или LocalDB
* [Visual Studio 2022](https://visualstudio.microsoft.com/) или [Visual Studio Code](https://code.visualstudio.com/)

### 1. Клониране на хранилището
```bash
git clone [https://github.com/Tsvetelinmarinov/ProjectLocalInformationSystem.git](https://github.com/Tsvetelinmarinov/ProjectLocalInformationSystem.git)
cd ProjectLocalInformationSystem
2. Настройка на базата данни
Отворете файла appsettings.json в кореновата директория и актуализирайте ConnectionString според вашата SQL Server инстанция:

JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;Encrypt=false;"
  }
}
💡 Забележка: Миграциите се прилагат автоматично и базата данни се създава при първоначалното стартиране на приложението.

3. Стартиране на приложението
Фрагмент от код
dotnet run
Приложението ще се стартира и ще бъде достъпно на https://localhost:5001 (или на посочения в конзолата адрес).

📁 Структура на проекта
Plaintext
ProjectLocalInformationSystem/
├── Controllers/        # Контролери за обработка на HTTP заявки
├── Models/             # Бизнес модели и ViewModels
├── Views/              # UI изгледи (Razor Views)
├── Data/               # ApplicationDbContext и база данни миграции
├── Services/           # Бизнес логика и услуги на приложението
└── wwwroot/            # Статични ресурси (CSS стилове, JS скриптове, медия)
👨‍💻 Автор
Цветелин Маринов — Tsvetelinmarinov