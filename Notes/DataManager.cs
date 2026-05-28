using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace Notes
{
    public static class DataManager
    {
        public static string FilePath { get; private set; } = "notes.json";

        public static List<Note> Load()
        {
            Logger.Log("Загрузка данных из файла");
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Deserialize<List<Note>>(json) ?? new List<Note>();
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Ошибки ввода/сохранения: " + ex.Message);
            }
            return new List<Note>();
        }

        public static void Save(List<Note> notes)
        {
            Logger.Log("Работа с файлом: сохранение данных");
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(notes);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Logger.Log("Ошибки ввода/сохранения: " + ex.Message);
            }
        }
    }
}
