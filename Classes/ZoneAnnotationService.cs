using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;

namespace ZlizEQMap
{
    public class ZoneAnnotationService
    {
        public List<ZoneAnnotation> ZoneAnnotations { get; set; }

        public bool NotesFileExists
        {
            get { return File.Exists(Paths.NotesFilePath); }
        }

        public ZoneAnnotationService()
        {
            LoadNotesFromFile();
        }

        public List<ZoneAnnotation> GetAllZoneAnnotations()
        {
            return ZoneAnnotations;
        }

        public List<ZoneAnnotation> GetFilteredZoneAnnotations(string mapShortName, int subMapIndex)
        {
            return ZoneAnnotations.Where(x => x.MapShortName == mapShortName && x.SubMap == subMapIndex).ToList();
        }

        private void LoadNotesFromFile()
        {
            if (NotesFileExists)
            {
                using (StreamReader r = new StreamReader(Paths.NotesFilePath))
                {
                    string json = r.ReadToEnd();
                    ZoneAnnotations = JsonConvert.DeserializeObject<List<ZoneAnnotation>>(json);
                };

                if (ZoneAnnotations == null)
                {
                    ZoneAnnotations = new List<ZoneAnnotation>();
                }
            }
        }

        public void SaveNotesToFile()
        {
            using (StreamWriter r = new StreamWriter(Paths.NotesFilePath))
            {
                r.Write(JsonConvert.SerializeObject(ZoneAnnotations));
            }

            Console.WriteLine($"CURRENT LIST: {ZoneAnnotations.Count}");
            foreach (var item in ZoneAnnotations)
            {
                Console.WriteLine($"{item.X} {item.Y} {item.Note}");
            }

        }

        internal void AddNote(ZoneAnnotation zoneAnnotation)
        {
            ZoneAnnotations.Add(zoneAnnotation);
        }
    }
}
