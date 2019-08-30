using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebungDatum
{ 
  /*
     * Übungsvorschläge:
     * 
     *  (1) Implementierung von - analog zu 'NextDay()' - 2 Varianten
     *      einer Methode 'PrevDay()', die den Zustand eines 'Datum'-Objekts
     *      um einen Tag zurücksetzt
     *      
     *  (2) Ergänzung der 'AddDays(int anzahlTage)'-Methode, so dass für 'anzahlTage' auch
     *      negative Werte übergeben werden können
     *      
     *  (3) Implementierung einer 'AddDays()'-Methode "manuell", 
     *      d.h. ohne Zuhilfenahme der Methoden 'NextDay()' und 'PrevDay()'
     *      
     *  (4) Implementierung einer Methode 'static Datum Ostersonntag(int jahr)',
     *      welche nach der Gauss'schen Osterformel ein 'Datum'-Objekt erzeugt,
     *      das das Datum des Ostersonntag für die übergebene Jahreszahl
     *      repräsentiert und einen Verweis auf dieses zurückliefert
     */


    public class Datum
    {
        private int tag, monat, jahr;

        private readonly static int[] anzahlTageImMonat =
            { 0 /* nicht relevant */, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        // Standard-Konstruktor
        //
        public Datum()
        {
            tag = 1;
            monat = 1;
            jahr = 1583;
        }

        // Parametrisierter Konstruktor
        //
        public Datum(int tag, int monat, int jahr) : this()
        {
            SetDatum(tag, monat, jahr);
        }

        public static bool IstSchaltjahr(int jahr)
        {
            if (jahr % 4 != 0)
            {
                return false;
            }

            if (jahr % 100 == 0 && jahr % 400 != 0)
            {
                return false;
            }

            return true;
        }

        public bool SetDatum(int tag, int monat, int jahr)
        {
            if (tag < 1 ||
                monat < 1 || monat > 12 ||
                jahr < 1583 || jahr > 9999)
            {
                return false;
            }

    #if false
                switch (monat)
                {
                    case 2:
                        if (tag > 28 + Convert.ToInt32(IstSchaltjahr(jahr)))
                        {
                            return false;
                        }
                        break;

                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (tag > 30)
                        {
                            return false;
                        }
                        break;

                    default:
                        if (tag > 31)
                        {
                            return false;
                        }
                        break;
                }
    #else
            if (monat == 2)
            {
                if (tag > 28 + Convert.ToInt32(IstSchaltjahr(jahr)))
                {
                    return false;
                }
            }
            else
            {
                if (tag > anzahlTageImMonat[monat])
                {
                    return false;
                }
            }

    #endif

            // Datum korrekt => dem Objekt die Daten zuweisen
            //
            this.tag = tag;
            this.monat = monat;
            this.jahr = jahr;

            return true;
        }

        public int Tag { get { return tag; } }
        public int Monat { get { return monat; } }
        public int Jahr { get { return jahr; } }

        public string DatumAlsZeichenkette
        {
            get
            {
                return string.Format(
                    "{0:00}.{1:00}.{2}",
                    tag, monat, jahr);
            }
        }

        // zwei Implementierungsvarianten einer Methode 'NextDay()',
        // welche den Zustand eines 'Datum'-Objekts um einen Tag erhöht
        //
        // Variante 1:
        //
        public bool NextDay1()
        {
            if (tag == 31 && monat == 12 && jahr == 9999)
            {
                return false;
            }

            if (tag < anzahlTageImMonat[monat])
            {
                tag++;
            }
            else
            {
                if (tag == 28 &&
                    monat == 2 &&
                    IstSchaltjahr(jahr))
                {
                    tag = 29;
                }
                else
                {
                    tag = 1;
                    monat++;

                    // Silvester
                    //
                    if (monat > 12)
                    {
                        monat = 1;
                        jahr++;
                    }
                }
            }

            return true;
        }

        // Variante 2:
        //
        public bool NextDay2()
        {
            if (!SetDatum(tag + 1, monat, jahr))
            {
                if (!SetDatum(1, monat + 1, jahr))
                {
                    if (jahr == 9999)
                    {
                        return false;
                    }

                    SetDatum(1, 1, jahr + 1);
                }
            }

            return true;
        }


        //(1) Implementierung von - analog zu 'NextDay()' - 2 Varianten
        //einer Methode 'PrevDay()', die den Zustand eines 'Datum'-Objekts
        // um einen Tag zurücksetzt

        public bool PrevDay1()
        {
            if (tag == 1 && monat == 1 && jahr == 1583)
            {
                return false;
            }

            if (tag > 1)
            {
                tag--;
            }
            else
            {

                if (monat == 1)
                {
                    monat = 12;
                    jahr--;
                }
                else
                {
                    monat--;
                }

                if (monat == 2)
                {
                    tag = anzahlTageImMonat[monat] + Convert.ToInt32(IstSchaltjahr(jahr));
                }
                else
                {
                    tag = anzahlTageImMonat[monat];
                }
            }

            return true;
        }



        /*
        public bool PrevDay2()
        {
            if (!SetDatum(tag - 1, monat, jahr))
            {
               
                    // Spezialfall: Datum ist aktuell der 01.03. eines Monats
                    if(monat == 3)
                    {
                        SetDatum(28 + Convert.ToInt32(IstSchaltjahr(jahr)), 2, jahr);
                    }
                    else
                    {
                        if (!SetDatum(anzahlTageImMonat[monat - 1], monat - 1, jahr)) // raff ich grad nich
                    {
                        if(jahr == 1583)
                        {

                        }
                    }



                    }


                    if (jahr == 1583)
                    {
                        return false;
                    }

                    SetDatum(31, 12, jahr - 1);
                
            }

            return true;
        }
        */

/*
        public void AddDays(int AnzahlTage)
        {

            for (int i = 0; i<AnzahlTage; i++)
            {
                NextDay1(tag, monat, jahr);
            }


        }
        */




    }
}
