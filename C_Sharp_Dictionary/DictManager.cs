using System.Xml;
using System.Text.Json;
using Newtonsoft.Json;

namespace C_Sharp_Dictionary_
{
    partial class DictManager
    {
        Dictionary<string, Dictionary<string, List<string>>> dictionaries;
        public List<string> DictionaryNamesList
        {
            get { return new List<string>(dictionaries.Keys); }
        }
       
        public DictManager()
        {
            dictionaries = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        public void EditWordData(string dictName) {
            bool exit = false;
            
            Console.WriteLine("Введіть слово яке хочете змінити:");
            string wordToEdit = Console.ReadLine();
            if (dictionaries[dictName].ContainsKey(wordToEdit)) {
                Console.WriteLine("1. Змінити саме слово\n2. Змінити переклад");
                int choice = int.Parse(Console.ReadLine()); 
                if (choice == 1) {
                    Console.WriteLine("Введіть нове слово:");
                    dictionaries[dictName][Console.ReadLine()] = dictionaries[dictName][wordToEdit];
                    dictionaries[dictName].Remove(wordToEdit);
                    Console.WriteLine($"Слово \"{wordToEdit} \" було змінене.");
                }
                else if(choice == 2)
                {
                    Console.WriteLine("1. Залишити переклад який був і додати новий\n2. Повністю змінити переклад");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        List<string> translations = dictionaries[dictName][wordToEdit];
                        while (!exit)
                        {
                            Console.Write("Введіть переклад вашого слова(Щоб принити ввід перекладу введіть\" 0 \"): ");
                            string wordTranslation = Console.ReadLine();
                            if (wordTranslation == "0" || string.IsNullOrWhiteSpace(wordTranslation))
                            {
                                exit = true;
                            }
                            else
                            {
                                translations.Add(wordTranslation);
                            }
                        }
                        dictionaries[dictName][wordToEdit] = translations;
                    }
                    else if (choice == 2)
                    {
                        List<string> translations = new List<string>();
                        while (!exit)
                        {
                            Console.Write("Введіть переклад вашого слова(Щоб принити ввід перекладу введіть\" 0 \"): ");
                            string wordTranslation = Console.ReadLine();
                            if (wordTranslation == "0" || string.IsNullOrWhiteSpace(wordTranslation))
                            {
                                exit = true;
                            }
                            else
                            {
                                translations.Add(wordTranslation);
                            }
                        }
                        dictionaries[dictName][wordToEdit] = translations;
                    }

                    else { 
                        Console.Clear();
                        Console.WriteLine("Не вірно вказаний вибір!");
                        Console.WriteLine(); }
                }
            }
            else Console.WriteLine($"Немає слова {wordToEdit} у словнику : {dictName}");
           
        }
        public void SearchForWord(string dictName)
        {
            Console.WriteLine("Введіть слово яке ви хочете знайти:");
            string word = Console.ReadLine() ;
            if (dictionaries[dictName].ContainsKey(word)) {
                Console.WriteLine($"{word} :");
                ShowTranslations(dictName, word);
                Console.WriteLine("----------------------");
            }
            else Console.WriteLine($"У словнику \"{dictName}\" немає слова {word}.");
        }

        void ShowTranslations(string dictName,string word)
        {
          
            int count = 1;
            foreach(string item in dictionaries[dictName][word])
            {
                Console.WriteLine($"{count}. {item};");
                count++;
            }
          
        }
        public void SortDictionaryByAlphabet(string dictName)
        {
            dictionaries[dictName] = dictionaries[dictName].OrderBy(pair => pair.Key, StringComparer.OrdinalIgnoreCase).ToDictionary(pair => pair.Key, pair => pair.Value); 
            Console.WriteLine("Словник було відсортовано за алфавітом!.");

        }

       
    
        public void DeleteWordOrTranslation(string dictName)
        {
            Console.WriteLine("1. Видалити слово повністю\n2. Видалити переклад слова");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть слово яке ви хочете видалити:");
            string wordToDel = Console.ReadLine();
            if (choice == 1) {
                
               
                if (dictionaries[dictName].ContainsKey(wordToDel)) {
                    dictionaries[dictName].Remove(wordToDel);
                    Console.WriteLine($"Слово {wordToDel} було видалено зі словника.");
                }
                else Console.WriteLine($"У даному словнику немає слова \"{wordToDel}\".");
            }
            else if(choice == 2)
            {
                if (dictionaries[dictName].ContainsKey(wordToDel))
                {
                    if (dictionaries[dictName][wordToDel].Count == 1) Console.WriteLine("Ви не можете видалити останній переклад слова.");
                    else
                    {
                        Console.WriteLine($"Оберіть переклад слова який ви хочете видалити:");
                        ShowTranslations(dictName, wordToDel);
                        try
                        {
                            choice = int.Parse(Console.ReadLine());
                            if (choice < 1 || choice > dictionaries[dictName][wordToDel].Count) Console.WriteLine($"Немає слів з індексом {choice}.");
                            else
                            {
                                dictionaries[dictName][wordToDel].Remove(dictionaries[dictName][wordToDel][choice - 1]);
                            }


                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                }
                else Console.WriteLine($"У даному словнику немає слова \"{wordToDel}\".");
            }
           
          
         }
        public void AddWordToDictionary(string dictName)
        {

            bool exit = false;
            
            
            Console.WriteLine("Введіть слово яке ви хочете додати:");
            string word = Console.ReadLine();
            if (!dictionaries[dictName].ContainsKey(word))
            {
       
                List<string> translations = new List<string>();

                while (!exit)
                {
                    Console.Write("Введіть переклад вашого слова(Щоб принити ввід перекладу введіть\" 0 \"): ");
                    string wordTranslation = Console.ReadLine();
                    if (wordTranslation == "0"|| string.IsNullOrWhiteSpace(wordTranslation))
                    {
                        exit = true;
                    }
                    else
                    {
                        translations.Add(wordTranslation);
                    }
                }
                dictionaries[dictName].Add(word, translations);

                Console.WriteLine($"Слово '{word}' Та я його переклад додано до словника: '{dictName}'.");
            }
            else
            {
                Console.WriteLine($"Слово '{word}' Уже існує у словнику: '{dictName}'.");
            }
        }
        public string ChooseDictionary()
        {
            string name;
            int choice;
            int count = 1;
            if (dictionaries.Keys.Count!=0)
            {
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
            }
            else Console.WriteLine("У вас немає словників з якими ви можете працювати!");

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
                    
                }
                Console.WriteLine();
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
        public void SaveDictionariesListToFile()
        {
            try
            {
               
                string json = JsonConvert.SerializeObject(dictionaries.Keys, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("Dictionaries.json", json);
                Console.WriteLine($"Список словників збережено до файлу 'Dictionaries.json'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка збереження словників до файлу: {ex.Message}");
            }
        }
        public List<string> LoadDictionariesListFromFile()
        {
            try
            {
                if (File.Exists("Dictionaries.json"))
                {
                    string json = File.ReadAllText("Dictionaries.json");
                    return JsonConvert.DeserializeObject<List<string>>(json);
                }
                else
                {
                    Console.WriteLine($"Файлу \"Dictionaries.json\" не існує.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка загрузки словників із файлу: {ex.Message}");
            }

            return null;
        }
        public void SaveDictionaryToFile(string dictName, string fileName)
        {
            if (dictionaries.ContainsKey(dictName))
            {
                try
                {
                    string json = JsonConvert.SerializeObject(dictionaries[dictName], Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(fileName, json);
                    Console.WriteLine($"Словник '{dictName}' було збережено до файлу '{dictName}.txt'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка зберігання словника до файлу: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Словника з ім'ям '{dictName}' не існує.");
            }
        }
        public void LoadDictionaryFromFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string json = File.ReadAllText(fileName);
                    
                    dictionaries.Add(fileName.Substring(0, fileName.Length - 5), JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json));
                }
                else
                {
                    Console.WriteLine($"Файла з назвою '{fileName}' не існує.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка загрузки словника із файлу: {ex.Message}");
            }

           
        }
        public void ExportWordToFile(string dictName, string word)
        {
            if (dictionaries[dictName].ContainsKey(word))
            {
                try
                {
                    Dictionary<string, List<string>> exportData = new Dictionary<string, List<string>>
                {
                    { word, dictionaries[dictName][word] }
                };

                    string json = JsonConvert.SerializeObject(exportData, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText($"{word}.json", json);
                    Console.WriteLine($"Слово '{word}' з словника '{dictName}' було експортовано до '{word}.json'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка експортування слова: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Слова '{word}' не існує у словнику: '{dictName}'.");
            }
        }

       
    }
}
