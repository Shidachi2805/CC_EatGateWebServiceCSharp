
//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WWWBewertungPortal.Models.Datenbank
{

using System;
    using System.Collections.Generic;
    
public partial class Tab_Lokation
{

    public Tab_Lokation()
    {

        this.Tab_Bewertung = new HashSet<Tab_Bewertung>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public string Adresse { get; set; }

    public string Lat { get; set; }

    public string Lng { get; set; }

    public string Place_id { get; set; }



    public virtual ICollection<Tab_Bewertung> Tab_Bewertung { get; set; }

}

}
