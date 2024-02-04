using System;
using System.Collections.Generic;
using System.IO;

namespace C_Sharp_Dictionary_
{

    internal class Program
    {
        class Menu
        {
            public void MainMenu()
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Створити словник");
                Console.WriteLine("2. Додати слово і його переклад");
                Console.WriteLine("3. Зміна слова або перекладу");
                Console.WriteLine("4. Видалення слова або перекладу");
                Console.WriteLine("5. Шукати переклад слова");
                Console.WriteLine("6. Експорт слова та перекладу до файлу");
                Console.WriteLine("0. Вихід");
            }
            public void MenuAdd()
            {
                Console.Clear();

            }
            public void MenuDel()
            {

            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DictManager dict = new DictManager();
            

        }
        
    }
}