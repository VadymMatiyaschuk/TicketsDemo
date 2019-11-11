using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace TicketsDemo.XML
{
    public class HolidayRepository : IHolidayRepository
    {
        public List<Holiday> GetHolidaysList()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Holiday>));
            List<Holiday> holidays;

            using (FileStream fs = new FileStream(GetXmlPath(), FileMode.Open))
            {
                holidays = (List<Holiday>)serializer.Deserialize(fs);
            }
            return holidays;
        }

        public void CreateHoliday(Holiday holiday)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Holiday));
            using (FileStream fs = new FileStream(GetXmlPath(), FileMode.Append))
            {
                serializer.Serialize(fs, holiday);
            }
        }

        //public void UpdateTrain(Train train)
        //{
        //    List<Train> trains = GetAllTrains();
        //    Train trainToRemove = trains.Single(x => x.Id == train.Id);
        //    trains.Remove(trainToRemove);
        //    trains.Add(train);
        //    SerializeListOfTrain(trains);
        //}
        //public void DeleteTrain(Train train)
        //{
        //    XDocument xDoc = XDocument.Load(GetXmlPath());
        //    foreach (XElement xelem in xDoc.Root.Elements("Train"))
        //    {
        //        if (xelem.Element("Id").Value == train.Id.ToString())
        //        {
        //            xelem.Remove();
        //        }
        //    }
        //    xDoc.Save(GetXmlPath());
        //}

        //public void SerializeListOfTrain(List<Train> trains)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Train>));
        //    using (FileStream fs = new FileStream(GetXmlPath(), FileMode.Create))
        //        serializer.Serialize(fs, trains);
        //}

        public string GetXmlPath()
        {
            return "D:\\Proga\\TicketsDemo\\TicketsDemo.XML\\XmlHolidayRepository.xml";
        }
    }
}
