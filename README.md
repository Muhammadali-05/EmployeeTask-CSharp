# Employee Task — C#

Тестовое задание, реализованное на C# с использованием Entity Framework Core и Microsoft SQL Server.

## Используемые технологии

- C#
- .NET 10
- Entity Framework Core
- Microsoft SQL Server
- LINQ

## База данных

Приложение работает с базой данных `EmployeeTaskDB2`.

Основные таблицы:

- `Employ`
- `Userr`
- `Contact`

## Выполненные задания

### 1. Сотрудники и логины

Вывод имён всех сотрудников и их логинов.

Для реализации используется аналог `LEFT JOIN` с помощью LINQ.

### 2. Сотрудники без логина

Поиск сотрудников, у которых отсутствует логин.

### 3. Количество контактов

Подсчёт количества контактов для каждого сотрудника.

### 4. Последний вход в систему

Поиск сотрудников, которые не входили в систему более 6 месяцев или вообще никогда не входили.

### 5. Активация пользователей

Поиск неактивных пользователей и изменение значения `IsActive` на `true`.

## Структура проекта

```text
EmployeeTaskCSharp/
├── Data/
│   └── EmployeeTaskDbContext.cs
├── Models/
│   ├── Contact.cs
│   ├── Employ.cs
│   └── Userr.cs
├── Program.cs
├── EmployeeTaskCSharp.csproj
├── appsettings.json
└── .gitignore