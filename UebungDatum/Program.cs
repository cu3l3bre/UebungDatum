using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebungDatum
{
    /*
     * Aufgabe: Entwerfen und implementieren Sie ein nach ihrem Ermessen 
     *          sinnvolles Konzept für eine Klasse 'Datum'. 
     *
     *          Beachten Sie dabei folgende Vorgaben:
     *
     *            - ein Datum besteht aus drei Werten: 'int tag, monat, jahr;'
     *            - kleinstes Datum: '01.01.1583' (Defaultwert)
     *              (in Anlehnung an die Einführung des Gregorianischen Kalenders am 15.10.1582)
     *            - größstes Datum:  '31.12.9999'
     *            - bei den Werten für 'tag' ist die Schaltjahr-Problematik,
     *              also gibt es den 29.Februar oder nicht, sowie die Anzahl
     *              von Tagen eines Monats miteinzubeziehen
     *			  - definieren Sie eine Schreibmethode 'SetDatum(int tag, int monat, int jahr)',
     *              welche drei Werte für Tag, Monat und Jahr entgegennimmt, jedoch nur dann
     *              den Zustand des aufrufenden Objekts ändert, wenn die Kombination dieser
     *              Werte ein gültiges Datum ergibt
     *
     *          Hinweis: Ein Jahr ist ein Schaltjahr, wenn es ganzzahlig durch 4,
     *                   aber nicht ganzzahlig durch 100 teilbar ist, es sein denn,
     *                   es ist ganzzahlig durch 400 teilbar.
     *
     *          Implementieren Sie des Weiteren zwei Methoden 'NextDay()' 
     *          und 'PrevDay()' innerhalb Ihrer Datumsklasse, die das Datum, 
     *          welches durch den aktuellen Objektzustand repräsentiert wird,
     *          um einen Tag erhöht bzw. erniedrigt.
     *
     *          Testen Sie mittels einer Schleife, ob Sie durch ein ganzes Jahr 
     *          beim richtigen Datum des nächsten bzw. letzten Jahres ankommen.
     *
     *          Fügen Sie Ihrer Klassendefinition des Weiteren noch eine Methode 
     *          'AddDays(int anzahl)' hinzu, mithilfe derer der aktuelle Zustand 
     *          des aufrufenden 'Datum'-Objekts um eine beliebige Zahl von Tagen 
     *          in die Zukunft bzw. in die Vergangenheit versetzt werden kann.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n1900 Schaltjahr? -> {0}", Datum.IstSchaltjahr(1900));
            Console.WriteLine("2000 Schaltjahr? -> {0}", Datum.IstSchaltjahr(2000));
            Console.WriteLine("2020 Schaltjahr? -> {0}\n", Datum.IstSchaltjahr(2020));

            Datum heute = new Datum(31, 12, 9999);

            Console.WriteLine("Datum: {0:00}.{1:00}.{2}", heute.Tag, heute.Monat, heute.Jahr);
            Console.WriteLine("Datum: {0}\n", heute.DatumAlsZeichenkette);


            heute.NextDay1();
            Console.WriteLine("Datum: {0} (naechster Tag)\n", heute.DatumAlsZeichenkette);


            //while (heute.NextDay1());
            //Console.WriteLine("Datum: {0} (letztes Datum)\n", heute.DatumAlsZeichenkette);


            Console.WriteLine();



            Datum meinDatum = new Datum(1, 3, 2020);
            Console.WriteLine("Datum: {0} (Datum Jetzt Tag)\n", meinDatum.DatumAlsZeichenkette);
            meinDatum.PrevDay2();
            Console.WriteLine("Datum: {0} (vorheriger Tag)\n", meinDatum.DatumAlsZeichenkette);

            Console.ReadKey();

        }
    }
}