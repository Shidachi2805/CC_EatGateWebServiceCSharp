using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WWWBewertungPortal.Models.Datenbank;

namespace WWWBewertungPortal.Services
{
    public class WWWBewertungPortalRepository
    {
        internal class Bewertung {

            public string Uberschrift { get; set;}
            public string Voting { get; set; }
            public string Inhalt { get; set; }
            public string Erstellungsdatum { get; set; }
            public string Nickname { get; set; }
        }

        internal class FilePathDownload
        {
            public string Filepath { get; set; }
        }
        private WWWBewertungsModellContainer ThisContainer;
        private NLog.Logger logger;
        public WWWBewertungPortalRepository()
        {
            ThisContainer = new WWWBewertungsModellContainer();
            logger = NLog.LogManager.GetCurrentClassLogger();
        }
        
        // Save Data in Database
        public bool SaveBenutzer(JObject data)
        {
            string vorname = (string)data.GetValue("Vorname");
            string name = (string)data.GetValue("Name");
            string nickname = (string)data.GetValue("Nickname");
            string email = (string)data.GetValue("Email");
            string passwort = (string)data.GetValue("Passwort");
            string gender = (string)data.GetValue("Geschlecht");
            
            try
            {
                Tab_Benutzer benutzer = new Tab_Benutzer()
                {
                    Vorname = vorname,
                    Name = name,
                    Nickname = nickname,
                    Email = email,
                    Passwort = passwort,
                    Geschlecht = gender,
                    
                };
                // benutzer.Tab_Bewertung = null;
                // benutzer.Tab_Kommentar = null;
                logger.Info("AddBenutzer " + benutzer);
                ThisContainer.Tab_BenutzerSet.Add(benutzer);
                logger.Info("Save Benutzer" + ThisContainer.Database.Exists());
                ThisContainer.SaveChanges();
                logger.Info("After Change AddBenutzer " + ThisContainer.Database.Exists());
                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex.ToString());
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool SaveBewertung(JObject data)
        {
            string splace_id = (string) data.GetValue("Place_id");
            var rowPlace_ID = (from lokation in ThisContainer.Tab_LokationSet 
                               where lokation.Place_id == splace_id 
                               select lokation);
            int idBenutzer = 0;
            int idLok = 0;
            if (rowPlace_ID == null || rowPlace_ID.Count() == 0)
            {
                SaveLokation(data);
                var rowIdLok = (from lokation in ThisContainer.Tab_LokationSet 
                                where lokation.Place_id == splace_id
                                select lokation);
                foreach (var row in rowIdLok)
                {
                    idLok = row.Id;
                    break;
                }
                // TODO: CN Exception 
            }
            else
            {
                foreach(var row in rowPlace_ID)
                {
                    idLok = row.Id;
                    break;
                }
                
            }
            try
            {                
                //int idLok = (int)data.GetValue("idLok"); 
                idBenutzer = (int)data.GetValue("idBenutzer");
                Tab_Bewertung bewertung = new Tab_Bewertung()
                {

                    Ueberschrift = (string)data.GetValue("Ueberschrift"), 
                    Inhalt = (string)data.GetValue("Inhalt"),
                    Erstelltlungdatum = (string)data.GetValue("Erstelltlungdatum"),
                    Voting = (string)data.GetValue("Voting"),
                };
                bewertung.Tab_Lokation = ThisContainer.Tab_LokationSet.Find(idLok);
                bewertung.Tab_Benutzer = ThisContainer.Tab_BenutzerSet.Find(idBenutzer);
                logger.Info("AddBewertung " + bewertung);
                ThisContainer.Tab_BewertungSet.Add(bewertung);
                logger.Info("Save AddBewertung " + ThisContainer.Database.Exists());
                ThisContainer.SaveChanges();
                logger.Info("After Change AddBewertung " + ThisContainer.Database.Exists());
                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex.ToString());
                Console.WriteLine("Fehler JSON: " + ex.ToString());
                return false;
            }
        }
        public bool SaveLokation(JObject data)
        {
            try
            {
                Tab_Lokation lokation = new Tab_Lokation()
                {
                    Name = (string)data.GetValue("Name"),
                    Adresse = (string)data.GetValue("Adresse"),
                    Lat = (string)data.GetValue("Lat"),
                    Lng = (string)data.GetValue("Lng"),
                    Place_id = (string)data.GetValue("Place_id")
                };
                //lokation.Tab_Bewertung = ThisContainer.Tab_BewertungSet.Find(idBewertung);
                logger.Info("AddLokation " + lokation);
                ThisContainer.Tab_LokationSet.Add(lokation);
                logger.Info("Save AddLokation " + ThisContainer.Database.Exists());
                ThisContainer.SaveChanges();
                logger.Info("After Change AddLokation " + ThisContainer.Database.Exists());
                return true;
            }
            catch (Exception ex)
            {
                logger.Info(ex.ToString());
                Console.WriteLine("Fehler JSON: " + ex.ToString());
                return false;
            }
        }

        public JArray ReadBewertung(JObject data)
        {
            // Abfrage nach Name via Place_id in Tab_LokationSet
            string placeID = (string)data.GetValue("Place_id");
            var rowLok = (from row in ThisContainer.Tab_LokationSet
                          where row.Place_id == placeID
                          select row).Single();
            string placeName = rowLok.Name;
            int idLok = rowLok.Id;
            // Finde alle Bewertungen in Tab_BewertungSet mit Place_id == placeID 
            var rows = (from row in ThisContainer.Tab_BewertungSet
                          where row.Tab_Lokation.Id == idLok
                          select row);
            // Finde die Autor zur Bewertung in Tab_BewertungSet mit Place_id = placeID
            var rowJoin = (from users in ThisContainer.Tab_BenutzerSet
                           join beitrag in rows on
                            users.Id equals beitrag.Tab_Benutzer.Id into userBew
                           from item in userBew
                           select new { Nickname = users.Nickname, 
                                        Beitrag = item.Inhalt, 
                                        Ueberschrift = item.Ueberschrift,
                                        Voting = item.Voting,
                                        Erstellungsdatum = item.Erstelltlungdatum});
            logger.Info("Lesen von DB" + rowJoin);
            List<Bewertung> bewertungListe = new List<Bewertung>();
            foreach (var row in rowJoin)
            {
                Bewertung tempBewertung = new Bewertung();
                tempBewertung.Uberschrift = row.Ueberschrift;
                tempBewertung.Voting = row.Voting;
                tempBewertung.Inhalt = row.Beitrag;
                tempBewertung.Erstellungsdatum = row.Erstellungsdatum;
                tempBewertung.Nickname = row.Nickname;
                bewertungListe.Add(tempBewertung);
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(bewertungListe, Newtonsoft.Json.Formatting.None);
            logger.Info("JSon Objekt gefassen" + json);
            JArray jsonArray = JArray.Parse(json);            
            return jsonArray;
        }

        public JArray DownloadPhoto(JObject data)
        {
            
            // Abfrage nach Name via Place_id in Tab_LokationSet
            string placeID = (string)data.GetValue("Place_id");
            var rowLok = (from row in ThisContainer.Tab_LokationSet
                          where row.Place_id == placeID
                          select row).Single();
            int idLok = rowLok.Id;
            // Finde alle Bewertungen in Tab_BewertungSet mit Place_id == placeID 
            var rows = (from row in ThisContainer.Tab_Lokation_PhotoSet
                        where row.Tab_Lokation.Id == idLok
                        select row);
            
            logger.Info("Lesen von DB" + rows);
            List<FilePathDownload> filepathListe = new List<FilePathDownload>();
            foreach (var row in rows)
            {
                FilePathDownload tempFilepath = new FilePathDownload();
                tempFilepath.Filepath = row.Uri;
                filepathListe.Add(tempFilepath);
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(filepathListe, Newtonsoft.Json.Formatting.None);
            logger.Info("JSon Objekt gefassen" + json);
            JArray jsonPhotoArray = JArray.Parse(json);
            return jsonPhotoArray;
        }
    }
}