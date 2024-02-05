using System;
using System.Collections.Generic;
using System.IO;

namespace C_Sharp_Dictionary_
{

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DictManager dict = new DictManager();
            Menu menu= new Menu();
            bool exit = false;
            bool back = false;
            try
            {
                List<string> dicts = dict.LoadDictionariesListFromFile();
                foreach (var item in dicts)
                {
                    dict.LoadDictionaryFromFile($"{item}.json");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
            while (!exit)
            {
                
                    menu.MenuStart();
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                        Console.Clear();
                        
                            string dictName = dict.ChooseDictionary();

                        if (dictName != null)
                        {
                            back = false;
                            while (!back)
                            {
                                Console.Clear();
                                menu.MenuMain(dictName);
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        
                                        dict.AddWordToDictionary(dictName);
                                        menu.Clear();
                                        break;
                                    case "2":
                                        
                                        dict.EditWordData(dictName);
                                        menu.Clear();
                                        break;

                                    case "3":
                                        
                                        dict.SearchForWord(dictName);
                                        menu.Clear();
                                        break;
                                    case "4":
                                        
                                        dict.DeleteWordOrTranslation(dictName);
                                        menu.Clear();
                                        break;

                                    case "5":
                                        dict.ShowDictionary(dictName);
                                        menu.Clear();
                                        break;
                                    case "6":
                                        
                                        Console.WriteLine("Введіть слово яке ви хочете Експортувати в окремий файл");
                                        string word = Console.ReadLine();
                                        dict.ExportWordToFile(dictName, word);
                                        menu.Clear();
                                        break;
                                    case "9":
                                        Console.Clear();
                                        back = true;
                                        break;
                                    case "0":
                                        back = true;
                                        exit = true;
                                        Console.WriteLine("Всі зміни буду збережено.\nГарного вам дня!");
                                        break;
                                    default:
                                        Console.WriteLine("Не коректно вказаний пункт меню!");
                                        break;
                                }

                            }
                        }
                        
                            break;
                        case "2":
                        

                        dict.CreateDictionary();
                        menu.Clear();
                        break;

                        case "0": Console.WriteLine("Всі зміни буду збережено.\nГарного дня"); Console.ReadKey(); break;

                        default:
                            Console.WriteLine("Не коректно вказаний пункт меню!");
                            Console.ReadKey();
                            break;

                    }                           
            }
            dict.SaveDictionariesListToFile();
            foreach(var item in dict.DictionaryNamesList) 
            {
                dict.SaveDictionaryToFile(item, $"{item}.json");
            }
        }        
    }
}