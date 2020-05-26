using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWork8
{
    public class TrueFalseBirths
    {
        public string fileName;
        List<Birthday> list;
        public string FileName
        {
            set { fileName = value; }
        }
        public TrueFalseBirths(string fileName)
        {
            this.fileName = fileName;
            list = new List<Birthday>();
        }
        public void Add(string text, DateTime date)
        {
            list.Add(new Birthday(text, date));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }
        public Birthday this[int index]
        {
            get { return list[index]; }
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Birthday>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
        public void SaveAs(string path)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Birthday>));
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Birthday>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Birthday>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        public int Count
        {
            get { return list.Count; }
        }
    }
}
