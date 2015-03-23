using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WWWBewertungPortal.Models.Datenbank;

namespace WWWBewertungPortal.Services
{
    public class WWWBewertungPortalRepository
    {
        private WWWBewertungsModellContainer ThisContainer;

        public WWWBewertungPortalRepository()
        {
            ThisContainer = new WWWBewertungsModellContainer();
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
                ThisContainer.Tab_BenutzerSet.Add(benutzer);
                ThisContainer.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool SaveBewertung(JObject data)
        {
            data.GetValue("Ueberschrift");
            try
            {
                //dynamic json = data;
                int idLok = (int)data.GetValue("idLok"); 
                int idBenutzer = (int)data.GetValue("idBenutzer");
                Tab_Bewertung bewertung = new Tab_Bewertung()
                {

                    Ueberschrift = (string)data.GetValue("Ueberschrift"), 
                    Inhalt = (string)data.GetValue("Inhalt"),
                    Erstelltlungdatum = (string)data.GetValue("Erstelltlungdatum"),
                    Voting = (string)data.GetValue("Voting"),
                   // Tab_Lokation = ThisContainer.Tab_LokationSet.ElementAt((int)json.idLok),
                   // Tab_Benutzer = ThisContainer.Tab_BenutzerSet.ElementAt((int)json.idBenutzer)
                };
                bewertung.Tab_Lokation = ThisContainer.Tab_LokationSet.Find(idLok);
                bewertung.Tab_Benutzer = ThisContainer.Tab_BenutzerSet.Find(idBenutzer);
                ThisContainer.Tab_BewertungSet.Add(bewertung);
                ThisContainer.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
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
                ThisContainer.Tab_LokationSet.Add(lokation);
                ThisContainer.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler JSON: " + ex.ToString());
                return false;
            }
        }
    }
}