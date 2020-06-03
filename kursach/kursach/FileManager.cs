using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace kursach
{
    class FileManager
    {
        public void Pack(Record r)
        {
            List<Record> records = Unpack();
            records.Add(r);
            // передаем в конструктор тип класса
            var formatter = new XmlSerializer(typeof(List<Record>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("records.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, records);
            }

        }

        public List<Record> Unpack(){
            var formatter = new XmlSerializer(typeof(List<Record>));
            using (FileStream fs = new FileStream("records.xml", FileMode.OpenOrCreate))
            {
                List<Record> newRecords = (List<Record>)formatter.Deserialize(fs);
                return newRecords;
            }
        }

    }
}