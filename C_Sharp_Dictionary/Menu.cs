using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Dictionary_
{
    partial class Menu
    {

        public void MenuStart()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("" +
                "1. Обрати словник з яким ви хочете працювати:\n" +
                "2. Створити Новий словник");
            Console.WriteLine("0. Вихід");
        }
        public void MenuMain(string dictName)
        {
            Console.WriteLine($"Ви працюєте із словником: \"{dictName}\"!\n\n" + $"Оберіть дію яку ви хочете виконати:\n" +
                $"1. Додати нове слово\n" +
                $"2. Замінити слово або його переклад\n" +
                $"3. Шукати переклад слова \n" +
                $"4. Видалити слово або його переклад\n" +
                $"5. Показати весь словник\n" +
                $"6. Експортувати слово в окремий файл\n" +
                $"7. Сортувати словник за алфавітом\n" +
                $"9. Обрати інший словник\n" +
                $"0. Вийти з програми");

        }
        public void Clear()
        {
            Console.WriteLine("\n\nНатисніть будь-яку кнопку щоб продовжити...\n");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
