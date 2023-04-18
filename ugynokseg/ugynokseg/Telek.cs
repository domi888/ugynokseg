using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugynokseg
{
  //7.	Hozza létre a Telek nevű osztályt, ami az Ingatlan osztályból származik.
  class Telek :Ingatlan//származtatás valamiből az mindig : utána pedig amiből származtatunk
  {
    bool beepithetoe;
    public bool Beepithetoe
    {
      get
      {
        return beepithetoe;
      }
      set
      {
        beepithetoe = value;
      }
    }

    //8.	Legyen egy konstruktora, melynek paraméterei: _cim, _telekmeret, _beepitheto_e és a _negyzetmeterenkenti_ar.

    /*
     A konstruktor hívja meg az ősosztály konstruktorát a megfelelő paraméterek továbbadásával. Az iranyar-at állítsa be a telekméret * négyzetméterenkénti ár képlet alapján, a tipus pedig legyen mindig "Telek". 

    a :base()-el adod tovább az ősosztálynak a paramétereket
     */
    public Telek(string _cim, int _telekmeret, bool _beepithetoe, int _negyzetmeterenkenti_ar):base(_cim, _telekmeret, (_telekmeret*_negyzetmeterenkenti_ar))
    {
      beepithetoe = _beepithetoe;
    }



    /*
     9.	Továbbá definiálja felül az osztály a ToString() metódust úgy, hogy a visszaadott sztring-be kerüljön be az is, hogy a telek beépíthető-e. Pl.:
    "Pécel-i, 500 m2-es telek eladó 8.000.000 Ft-ért (BEÉPÍTHETŐ)."
     */
    public override string ToString()
    {
      return base.ToString()+" ("+beepithetoe+")";
    }
  }
}
