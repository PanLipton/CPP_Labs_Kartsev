using System;

   namespace LabSelector
   {
       class Program
       {
           static void Main(string[] args)
           {
               while (true)
               {
                   Console.WriteLine("Виберіть лабораторну роботу (1-3) або 'q' для виходу:");
                   string choice = Console.ReadLine();

                   if (choice.ToLower() == "q")
                   {
                       break;
                   }

                   switch (choice)
                   {
                       case "1":
                           Lab1.Program.Main(new string[] { });
                           break;
                       case "2":
                           Lab2.Program.Main(new string[] { });
                           break;
                       case "3":
                           Lab3.Program.Main(new string[] { });
                           break;
                       default:
                           Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                           break;
                   }

                Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
                Console.ReadLine();
               }
           }
       }
   }