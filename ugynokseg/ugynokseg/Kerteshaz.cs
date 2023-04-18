using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugynokseg
{
  //10.	Hozza létre az Kertesház nevű osztályt, ami a Telek osztályból származik.
  class Kerteshaz :Telek
  {
    int lakoterulet;

    /*
     Ennek kezeléséhez is készítsen egy írható-olvasható tulajdonságot, ez is legyen korlátlanul hozzáférhető. Beállításkor csak akkor lehessen új értéket megadni, ha az érték nagyobb 10-nél és kisebb a teljes telekméret 80%-ánál. Ellenkező esetben dobjon kivételt, melynek üzenetében írja le a hiba okát.
     */
    public int Lakoterulet
    {
      get
      {
        return lakoterulet;
      }
      set
      {
        if(value > 10 && value < Telekmeret * 0.8)
        {
          lakoterulet = value;
        }
        else
        {
          throw new Exception("Nem megfelelő lakoterulet méret!");
        }
      }
    }

    /*
     11.	Készíts egy másik, csak olvasható tulajdonságot is, melynek neve legyen KertTerulet, és adja vissza a kiszámított kert területet. A kert területe kiszámítható, ha a telekméretből levonjuk a lakóterület méretét (mindkettő m2-ben van értelmezve).
     */
    public int KertTerulet
    {
      get
      {
        return (Telekmeret - Lakoterulet);
      }
    }


    /*
     12.	Legyen egy konstruktora, ami megkapja a _tipus, _cim, _telekmeret, _lakoterulet és a _negyzetmeterenkenti_ar paramétereket. A konstruktor ezeket részben adja tovább az ősosztály konstruktorának, és végezze el a lakoterulet és tipus tagváltozók beállítását is.
     */
    public Kerteshaz(string _tipus, string _cim, int _telekmeret, int _lakoterulet, int _negyzetmeterenkenti_ar) :base(_cim, _telekmeret, true, _negyzetmeterenkenti_ar)
    {
      Lakoterulet = _lakoterulet;
      tipus = _tipus;
    }


    /*
     13.	Itt is definiálja felül a ToString() metódust, hogy az újabb lakóterület tagváltozó tartalma is bekerüljön a visszaadott sztringbe.
     */
    public override string ToString()
    {
      return base.ToString()+ " Lakoterület: "+Lakoterulet;
    }
  }
}
