using Application.Helpers;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeding;

public class UserSeeding : ISeeder<User>
{
    private static readonly List<User> sessions = new List<User>()
    {
        new User()
        {
            Id = 1,
            FirstName = "Alex",
            LastName = "Verenchuk",
            UserName = "alex21",
            Email = "alex21@example.com",
            Password = PasswordHasher.HashPassword("123456Aa@"),
            Role = "Admin"
        },
        new User()
        {
            Id = 2,
            FirstName = "Alice",
            LastName = "Smith",
            UserName = "asmith",
            Email = "asmith@example.com",
            Password = PasswordHasher.HashPassword("password2"),
            Role = "User"
        },
        new User()
        {
            Id = 3,
            FirstName = "Bob",
            LastName = "Johnson",
            UserName = "bobj",
            Email = "bobj@example.com",
            Password = PasswordHasher.HashPassword("password3"),
            Role = "User"
        },
        new User()
        {
            Id = 4,
            FirstName = "Emily",
            LastName = "Brown",
            UserName = "emilyb",
            Email = "emilyb@example.com",
            Password = PasswordHasher.HashPassword("password4"),
            Role = "User"
        },
        new User()
        {
            Id = 5,
            FirstName = "Michael",
            LastName = "Wilson",
            UserName = "michaelw",
            Email = "michaelw@example.com",
            Password = PasswordHasher.HashPassword("password5"),
            Role = "User"
        },
        new User()
        {
            Id = 6,
            FirstName = "Sophia",
            LastName = "Garcia",
            UserName = "sophiag",
            Email = "sophiag@example.com",
            Password = PasswordHasher.HashPassword("password6"),
            Role = "User"
        },
        new User()
        {
            Id = 7,
            FirstName = "David",
            LastName = "Martinez",
            UserName = "davidm",
            Email = "davidm@example.com",
            Password = PasswordHasher.HashPassword("password7"),
            Role = "User"
        },
        new User()
        {
            Id = 8,
            FirstName = "Olivia",
            LastName = "Lopez",
            UserName = "olivial",
            Email = "olivial@example.com",
            Password = PasswordHasher.HashPassword("password8"),
            Role = "User"
        },
        new User()
        {
            Id = 9,
            FirstName = "James",
            LastName = "Hernandez",
            UserName = "jamesh",
            Email = "jamesh@example.com",
            Password = PasswordHasher.HashPassword("password9"),
            Role = "User"
        },
        new User()
        {
            Id = 10,
            FirstName = "Emma",
            LastName = "Gonzalez",
            UserName = "emmag",
            Email = "emmag@example.com",
            Password = PasswordHasher.HashPassword("password10"),
            Role = "User"
        },
        new User { 
            Id = 11, 
            FirstName = "Olga", 
            LastName = "Petrenko", 
            UserName = "olga22", 
            Email = "olga22@example.com", 
            Password = PasswordHasher.HashPassword("123456Bb#"), 
            Role = "User" 
        },
        new User()
        {
            Id = 12,
            FirstName = "Olga",
            LastName = "Ivanova",
            UserName = "olga12",
            Email = "olga12@example.com",
            Password = PasswordHasher.HashPassword("123456Bb#"),
            Role = "User"
        },
        new User()
        {
            Id = 13,
            FirstName = "Ivan",
            LastName = "Ivanov",
            UserName = "ivan23",
            Email = "ivan23@example.com",
            Password = PasswordHasher.HashPassword("123456Cc$"),
            Role = "User"
        },
        new User()
        {
            Id = 14,
            FirstName = "Maria",
            LastName = "Shevchenko",
            UserName = "maria24",
            Email = "maria24@example.com",
            Password = PasswordHasher.HashPassword("123456Dd%"),
            Role = "User"
        },
        new User()
        {
            Id = 15,
            FirstName = "Petro",
            LastName = "Kovalenko",
            UserName = "petro25",
            Email = "petro25@example.com",
            Password = PasswordHasher.HashPassword("123456Ee^"),
            Role = "User"
        },
        new User()
        {
            Id = 16,
            FirstName = "Natalia",
            LastName = "Skrypka",
            UserName = "natalia26",
            Email = "natalia26@example.com",
            Password = PasswordHasher.HashPassword("123456Ff&"),
            Role = "User"
        },
        new User()
        {
            Id = 17,
            FirstName = "Sergiy",
            LastName = "Bondarenko",
            UserName = "sergiy27",
            Email = "sergiy27@example.com",
            Password = PasswordHasher.HashPassword("123456Gg*"),
            Role = "User"
        },
        new User()
        {
            Id = 18,
            FirstName = "Yulia",
            LastName = "Hrytsenko",
            UserName = "yulia28",
            Email = "yulia28@example.com",
            Password = PasswordHasher.HashPassword("123456Hh("),
            Role = "User"
        },
        new User()
        {
            Id = 19,
            FirstName = "Andriy",
            LastName = "Tkachuk",
            UserName = "andriy29",
            Email = "andriy29@example.com",
            Password = PasswordHasher.HashPassword("123456Ii)"),
            Role = "User"
        },
        new User()
        {
            Id = 20,
            FirstName = "Larysa",
            LastName = "Didenko",
            UserName = "larysa30",
            Email = "larysa30@example.com",
            Password = PasswordHasher.HashPassword("123456Jj_"),
            Role = "User"
        },
        new User()
        {
            Id = 21,
            FirstName = "Anna",
            LastName = "Kravchenko",
            UserName = "anna31",
            Email = "anna31@example.com",
            Password = PasswordHasher.HashPassword("123456Kk!"),
            Role = "User"
        },
        new User()
        {
            Id = 22,
            FirstName = "Viktor",
            LastName = "Sydorenko",
            UserName = "viktor32",
            Email = "viktor32@example.com",
            Password = PasswordHasher.HashPassword("123456Ll#"),
            Role = "User"
        },
        new User()
        {
            Id = 23,
            FirstName = "Daria",
            LastName = "Moroz",
            UserName = "daria33",
            Email = "daria33@example.com",
            Password = PasswordHasher.HashPassword("123456Mm$"),
            Role = "User"
        },
        new User()
        {
            Id = 24,
            FirstName = "Bohdan",
            LastName = "Rudenko",
            UserName = "bohdan34",
            Email = "bohdan34@example.com",
            Password = PasswordHasher.HashPassword("123456Nn%"),
            Role = "User"
        },
        new User()
        {
            Id = 25,
            FirstName = "Halyna",
            LastName = "Zinchenko",
            UserName = "halyna35",
            Email = "halyna35@example.com",
            Password = PasswordHasher.HashPassword("123456Oo^"),
            Role = "User"
        },
        new User()
        {
            Id = 26,
            FirstName = "Roman",
            LastName = "Melnyk",
            UserName = "roman36",
            Email = "roman36@example.com",
            Password = PasswordHasher.HashPassword("123456Pp&"),
            Role = "User"
        },
        new User()
        {
            Id = 27,
            FirstName = "Tetiana",
            LastName = "Tkachenko",
            UserName = "tetiana37",
            Email = "tetiana37@example.com",
            Password = PasswordHasher.HashPassword("123456Qq*"),
            Role = "User"
        },
        new User()
        {
            Id = 28,
            FirstName = "Yaroslav",
            LastName = "Marchenko",
            UserName = "yaroslav38",
            Email = "yaroslav38@example.com",
            Password = PasswordHasher.HashPassword("123456Rr("),
            Role = "User"
        },
        new User()
        {
            Id = 29,
            FirstName = "Mykola",
            LastName = "Horodetsky",
            UserName = "mykola39",
            Email = "mykola39@example.com",
            Password = PasswordHasher.HashPassword("123456Ss)"),
            Role = "User"
        },
        new User()
        {
            Id = 30,
            FirstName = "Valeria",
            LastName = "Litvin",
            UserName = "valeria40",
            Email = "valeria40@example.com",
            Password = PasswordHasher.HashPassword("123456Tt_"),
            Role = "User"
        },
        new User()
        {
            Id = 31,
            FirstName = "Oksana",
            LastName = "Poltava",
            UserName = "oksana41",
            Email = "oksana41@example.com",
            Password = PasswordHasher.HashPassword("123456Uu!"),
            Role = "User"
        },
        new User()
        {
            Id = 32,
            FirstName = "Vladyslav",
            LastName = "Bondar",
            UserName = "vladyslav42",
            Email = "vladyslav42@example.com",
            Password = PasswordHasher.HashPassword("123456Vv#"),
            Role = "User"
        },
        new User()
        {
            Id = 33,
            FirstName = "Svitlana",
            LastName = "Lysenko",
            UserName = "svitlana43",
            Email = "svitlana43@example.com",
            Password = PasswordHasher.HashPassword("123456Ww$"),
            Role = "User"
        },
        new User()
        {
            Id = 34,
            FirstName = "Artem",
            LastName = "Levchenko",
            UserName = "artem44",
            Email = "artem44@example.com",
            Password = PasswordHasher.HashPassword("123456Xx%"),
            Role = "User"
        },
        new User()
        {
            Id = 35,
            FirstName = "Iryna",
            LastName = "Sokolova",
            UserName = "iryna45",
            Email = "iryna45@example.com",
            Password = PasswordHasher.HashPassword("123456Yy^"),
            Role = "User"
        },
        new User()
        {
            Id = 36,
            FirstName = "Denys",
            LastName = "Chernysh",
            UserName = "denys46",
            Email = "denys46@example.com",
            Password = PasswordHasher.HashPassword("123456Zz&"),
            Role = "User"
        },
        new User()
        {
            Id = 37,
            FirstName = "Vasyl",
            LastName = "Hryhorovych",
            UserName = "vasyl47",
            Email = "vasyl47@example.com",
            Password = PasswordHasher.HashPassword("123456Ab@"),
            Role = "User"
        },
        new User()
        {
            Id = 38,
            FirstName = "Hanna",
            LastName = "Semenivna",
            UserName = "hanna48",
            Email = "hanna48@example.com",
            Password = PasswordHasher.HashPassword("123456Bc#"),
            Role = "User"
        },
        new User()
        {
            Id = 39,
            FirstName = "Viktor",
            LastName = "Mykhailovych",
            UserName = "viktor49",
            Email = "viktor49@example.com",
            Password = PasswordHasher.HashPassword("123456Cd$"),
            Role = "User"
        },
        new User()
        {
            Id = 40,
            FirstName = "Maryna",
            LastName = "Oleksandrivna",
            UserName = "maryna50",
            Email = "maryna50@example.com",
            Password = PasswordHasher.HashPassword("123456De%"),
            Role = "User"
        }
    };

    public void Seed(EntityTypeBuilder<User> builder) => builder.HasData(sessions);
}
