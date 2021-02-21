using System;
using System.Collections.Generic;
using System.Linq;

namespace Module22
{
    class Program
    {
        static void Main(string[] args)
        {          
            var phoneBook = new List<Contact>();
            
            phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com", 12));
            phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com", 15));
            phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com", 32));
            phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com", 24));
            phoneBook.Add(new Contact("Сергей", 799900000013, "serg@example.com", 16));
            phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com", 35));

            while (true)
            {                
                var input = Console.ReadKey().KeyChar;             
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                // если не соответствует критериям - показываем ошибку
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                // если соответствует - запускаем вывод
                else
                {
                    var sorted = phoneBook.OrderBy(s => s.Name).ThenBy(s => s.Age);
                   
                    var pageContent = sorted.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

      
                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + ": " + entry.Age + " - " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, long phoneNumber, String email, int age) 
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Age = age;
        }

        public String Name { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
        public int Age { get; }
    }
}
    

