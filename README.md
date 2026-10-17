Local Information System (Локална Информационна Система)

Проектът Local Information System е уеб/софтуерно приложение, създадено за управление, съхранение и предоставяне на локална информация за регион, институция или организация.

📌 Основни функционалности

Управление на съдържанието (CRUD):

Добавяне, редактиране, преглед и изтриване на информационни записи/статии.

филтриране по категории и тагове.

Интерфейс:

Удобен и отзивчив (responsive) дизайн, подходящ за мобилни устройства и десктоп.

🛠️ Използвани технологии

Backend: C# / .NET Core (ASP.NET Core MVC / Web API)

ORM / База Данни: Entity Framework Core и MS SQL Server

Frontend: HTML5, CSS3, JavaScript, Bootstrap / Tailwind

🚀 Инсталация и стартиране

Предварителни изисквания

.NET SDK 6.0 / 7.0 / 8.0, 9.0, 10.0

MS SQL Server или LocalDB

Visual Studio 2022 или Visual Studio Code

Клониране на хранилището

git clone https://github.com/Tsvetelinmarinov/ProjectLocalInformationSystem.git
cd ProjectLocalInformationSystem


Настройка на базата данни

Отворете файла appsettings.json и актуализирайте ConnectionString според вашата инстанция на SQL Server:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;Enrypt=false;"
}

Миграцийте се прилагат автоматично и базата се създава при стартиране.

Стартиране на приложението

dotnet run


Приложението ще стартира на https://localhost:5001 (или на посочения в конзолата адрес).

📁 Структура на проекта

ProjectLocalInformationSystem/
├── Controllers/       # Контролери за обработка на заявки
├── Models/            # Модели на данните и ViewModel-и
├── Views/             # UI изгледи (Razor Views)
├── Data/              # ApplicationDbContext и миграции
├── Services/          # Бизнес логика и услуги
└── wwwroot/           # Статични ресурси (CSS, JS, изображения)


👨‍💻 Автор

Цветелин Маринов