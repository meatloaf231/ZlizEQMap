using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;

namespace ZlizEQMap
{
    public static class ZoneAnnotationManager
    {

        public static List<ZoneAnnotation> ZoneAnnotations { get; set; } = new List<ZoneAnnotation>();
        public static string notesContents { get; set; } = "";


        public static bool NotesFileExists
        {
            get { return File.Exists(Paths.NotesFilePath); }
        }

        public static void InitializeZoneAnnotationManager()
        {
            LoadNotes();
        }

        public static void LoadNotes()
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

        public static void SaveNotes()
        {
            using (StreamWriter r = new StreamWriter(Paths.NotesFilePath))
            {
                r.Write(JsonConvert.SerializeObject(ZoneAnnotations));
            }
        }

        internal static void AddNote(ZoneAnnotation zoneAnnotation)
        {
            ZoneAnnotations.Add(zoneAnnotation);
        }
    }
}
