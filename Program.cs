using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EmployeeTaskCSharp.Data;
using EmployeeTaskCSharp.Models;


var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

services.AddDbContext<EmployeeTaskDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection")));

var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();


//ЗАДАНИЕ 1
//Вывести имена всех сотрудников и их логины.

var db = scope.ServiceProvider.GetRequiredService <EmployeeTaskDbContext>();
var employeeLogins = db.Employ
    .GroupJoin(
        db.Userr,
        e => e.EmployeeId,
        u => u.EmployeeId,
        (e,users) => new
        {
            Employ = e,
            Users = users
        }
        )
    .SelectMany(
    employeeData => employeeData.Users.DefaultIfEmpty(),
    (employeeData, user) => new
    {
        FullName = employeeData.Employ.FullName,
        Login = user == null? null: user.Login
    }
);

Console.WriteLine("Имена сотрудников и их логины : ");

foreach (var item in employeeLogins)
{
    Console.WriteLine($"\t{item.FullName} - {item.Login}");
}
Console.WriteLine();


//ЗАДАНИЕ 2
//Найти сотрудников, у которых нет логина.

var withoutLogin = employeeLogins.Where(x => x.Login == null);

Console.WriteLine("Сотрудники без логина : ");

foreach (var item in withoutLogin)
{
    Console.WriteLine($"\t{item.FullName}");
}

Console.WriteLine();


//ЗАДАИЕ 3
//Посчитать количество контактов для каждого сотрудника.

var contactCount = db.Employ
    .GroupJoin(
    db.Contact,
    e => e.EmployeeId,
    c => c.EmployeeId,
    (e, contacts) => new
    {
        FullName = e.FullName,
        ContactCount = contacts.Count()
    }
    );


Console.WriteLine("Количество контактов каждого сотрудника : ");

foreach(var item in contactCount)
{
    Console.WriteLine($"\t{item.FullName} - {item.ContactCount}");
}

Console.WriteLine();


//ЗАДАНИЕ 4
//Найти сотрудников, которые не входили
//в систему больше 6 месяцев или вообще никогда не входили.

var employeeLastLogin = db.Employ
    .GroupJoin(
    db.Userr,
    e => e.EmployeeId,
    u => u.EmployeeId,
    (e, users) => new
    {
        FullName = e.FullName,
         Users = users
    }
    )
    .SelectMany(
   employeeData => employeeData.Users.DefaultIfEmpty(),
   (employeeData, user) => new
   {
       FullName = employeeData.FullName,
       LastLoginDate = user == null? null: user.LastLoginDate
   });

DateTime sixMonthsAgo = DateTime.Now.AddMonths(-6);
var filtered = employeeLastLogin.Where(x => x.LastLoginDate == null || x.LastLoginDate < sixMonthsAgo);

Console.WriteLine("Сотрудники которые не совершали вход больше 6 месяц(либо воопще не совершали вход) : ");
foreach (var item in filtered)
{
    Console.WriteLine($"\t{item.FullName} - {item.LastLoginDate}");
}
Console.WriteLine();


//ЗАДАНИЕ 5
//Активировать неактивных пользователей.

var inactiveUsers = db.Userr.Where(x => x.IsActive == false);

foreach (var user in inactiveUsers)
{
    user.IsActive = true;
}

db.SaveChanges();


Console.WriteLine("Активные сотрудники : ");
var users = db.Userr.ToList();
foreach (var user in users)
{
    Console.WriteLine($"\t{user.Login} - {user.IsActive}");
}




