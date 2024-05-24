using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpaceWar.Classes
{
    public  class FileManager
    {
        string path = "text.txt";
        public FileManager(string path)
        {
            this.path = path;
        }
        public void Write(string text)
        {
           

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                //Открыть стрим
                byte[] info = new UTF8Encoding(true).GetBytes(text);

                stream.Write(info, 0, info.Length);
                // Закрыть
            }
        }
        public void WriteJson(object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, jsonString);
        }
        public object ReadJson() 
        {
           string str =  File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<SaveData>>(str);
        }
        public string ReadScore()
        {
            string text;
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                byte[] info = new byte[16];
                stream.Read(info, 0, info.Length);

                UTF8Encoding decoder = new UTF8Encoding();
                text = decoder.GetString(info);
                string[] array = text.Split('\0');
                text = array[0];
            }
            return text;
        }
    }
}
