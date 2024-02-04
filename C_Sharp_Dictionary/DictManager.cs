namespace C_Sharp_Dictionary_
{
    partial class DictManager
    {
        Dictionary<string, Dictionary<string, List<string>>> dictionaries;
        public DictManager()
        {
            dictionaries = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        public string ChooseDictionary()
        {
            string name;
            int choice;
            int count = 1;
            foreach (string item in dictionaries.Keys)
            {
                Console.WriteLine($"{count}. {item}");
                count++;
            }
            choice = int.Parse(Console.ReadLine());
            if (dictionaries.Count > count || dictionaries.Count < 1)
            {
                Console.WriteLine("Wrong choice!");
                return null;
            }

            count = 1;
            foreach (string item in dictionaries.Keys)
            {
                if (count == choice) return item;
                else count++;
            }
            return null;
        }
        public void ShowDictionary(string dictName)
        {
            foreach(var item in dictionaries[dictName])
            {
                Console.Write($"{item.Key} - ");
                foreach(string i in item.Value)
                {
                    Console.Write($"{i}, ");
                    Console.WriteLine();
                }
            }
        }
        public void CreateDictionary()
        {
            Console.WriteLine("Введіть назву словника:");
            string dictionaryName = Console.ReadLine();

            if (!dictionaries.ContainsKey(dictionaryName))
            {
                dictionaries[dictionaryName] = new Dictionary<string, List<string>>();
                Console.WriteLine($"Створено словник '{dictionaryName}'.");
            }
            else
            {
                Console.WriteLine("Словник з такою назвою вже існує.");
            }
        }
    }
}
