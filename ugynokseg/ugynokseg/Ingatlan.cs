using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugynokseg
{
  //1.	Hozza létre az Ingatlan nevű osztályt (ez legyen absztrakt!).
  abstract class Ingatlan //<--- abstract (azt jelenti hogy ebből nem lehet példányt létrehozni tehát pl: (Ingatlan ingatlan1) ilyet nem lehet csinálni vele ebből csak örököltetni lehet)
  {
    protected string tipus;
    string cim;
    int telekmeret;
    int iranyar;

    //2.	A cím tagváltozóhoz készítsen írható-olvasható tulajdonságot, jellemzőt (Cim).
    public string Cim
    {
      get
      {
        return cim;
      }
      set
      {
        cim = value;
      }
    }
    //2-es feladat vége


    /*
     3.	Az Iranyar írható-olvasható tulajdonság csak akkor engedje az iranyar tagváltozót beállítani, ha a megadott érték nagyobb, mint 100.000 Ft. Amennyiben rossz értéket adtak meg, dobjon kivétel, és állítsa be a kivétel üzenetét, melyben leírja, miért volt rossz a megadott érték.
     */
    public int Iranyar
    {
      get
      {
        return iranyar;
      }
      set
      {
        if (value > 100000)//itt a feltétel később a konstruktorban ezt az Iranyar-nak fogunk értéket adni nem a kisbetüs "iranyar"-nak, ez fontos!!
        {
          iranyar = value;
        }
        else
        {
          throw new Exception("Rossz irányár");
        }
      }
    }

    /*
     4.	A telekméret lekérdezéséhez és beállításához készítse el a Telekmeret írható-olvasható tulajdonságot, melyet a forráskód bármely részéről el tudunk érni. A telekméretnek legalább 10 m2 területűnek kell lenni. Ha kisebb területet adtak meg, dobjon kivételt, és a kivétel üzenetében utaljon a hiba okára.
     */
    public int Telekmeret
    {
      get
      {
        return telekmeret;
      }
      set
      {
        if (value > 10)//ugyan az mint a 3-as feladat
        {
          telekmeret = value;
        }
        else
        {
          throw new Exception("Nem megfelelő telekméret");
        }
      }
    }

    //5.	Az osztálynak legyen két konstruktora

    //5.1
    /*
     5.1, az egyik konstruktora, paraméterében kapja a _cim, _telekmeret, és _iranyar paramétereket. Ezekkel inicializálja a megfelelő adatmezők értékeit, az irányár és telekméret beállításához használja a már elkészített tulajdonságokat.
     */
    public Ingatlan(string _cim, int _telekmeret, int _iranyar)
    {
      cim = _cim;
      Iranyar = _iranyar;
      Telekmeret = _telekmeret;
    }

    /*
     5.2, a másik konstruktor, csak a _cim, _telekmeret paramétereket fogadja. Ezekkel inicializálja a megfelelő adatmezők értékeit, a telekméret beállításához használja a már elkészített tulajdonságot, az irányárat ilyenkor állítsa 1.000.000 Ft-ra alapértelmezettként.
     */
    public Ingatlan(string _cim, int _telekmeret)
    {
      iranyar = 10000000;
      cim = _cim;
      Telekmeret = _telekmeret;
    }


    /*
     6.	Végül definiálja felül a System.Object osztálytól örökölt ToString() metódust, úgy hogy az általa visszaadott szöveg formázottan tartalmazza az objektum összes tagváltozó értékét. Pl.:
    "Budapest, III. kerület-i, 75 m2-es panellakás eladó 10.000.000 Ft-ért."
     */
    public override string ToString()
    {
      return cim + ", " + telekmeret + " " + tipus + " eladó " + iranyar+" FT-ért";
    }
  }
}
