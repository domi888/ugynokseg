using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ugynokseg
{
  public partial class Form1 : Form
  {
    //14.	A főprogramban vegyen fel egy listát, ami Ingatlan-ok tárolására alkalmas, majd grafikus felületen végezze el az alábbi műveleteket!
    List<Ingatlan> ingatlanok = new List<Ingatlan>();
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      //14.1	Az ingatlanok.xls fájl adatai segítségével (készíthet belőle txt fájlt is), készítsen objektumokat és ezekkel töltse fel a listát. showdialog() hozza elő azt ahonnan kiválaszthatod azt a fájlt amit beolvastatsz
      var dlg = new OpenFileDialog();
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      else
      {
        var sorok = System.IO.File.ReadAllLines(dlg.FileName).Skip(1);
        foreach (var sor in sorok)
        {
          try//ide kell a try catch   védett blokk mert beolvasás közben egyes sorok hibákat dobnak ezért kellettek azok az egyedi hibajelzések (throw new Exception)
          {
            /*
             14.2, Először olvassa be, hogy milyen típusú ingatlant szeretne felvenni (telek, vagy kertes ház), majd olvassa be az adott típusú ingatlanhoz tartozó összes adatot. Ezek után már létrehozhatók az objektum példányok és ezeket kell a listában elhelyezni.
             */
            string[] d = sor.Split(';');
            if (d[0] == "telek")
            {
              ingatlanok.Add(new Telek(d[1], Convert.ToInt32(d[2]), (d[4] == "igen") ? true : false, Convert.ToInt32(d[3])));
            }
            else
            {
              ingatlanok.Add(new Kerteshaz("Kertesház", d[1], Convert.ToInt32(d[2]), Convert.ToInt32(d[5]), Convert.ToInt32(d[3])));
            }
          }
          catch (Exception)
          {

            //üresen hagyjuk mert nem kell a feladathoz ha jól emlékeszem a tanárnő csinált itt valamit de Ő egyébként sem a feladatokat csinálta (legalábbis itt a végén nem)
          }
        }


        //14.3, Listázza ki az összes olyan eladó ingatlan adatait, melyek irányára 5 és 10 millió Ft közt van.
        listBox1.Items.Add("Listázza ki az összes olyan eladó ingatlan adatait, melyek irányára 5 és 10 millió Ft közt van");
        foreach (var ingatlan in ingatlanok)
        {
          if(ingatlan.Iranyar > 5000000 && ingatlan.Iranyar < 10000000)
          {
            listBox1.Items.Add(ingatlan.ToString());
          }
        }

        //Végül pedig határozza meg a legnagyobb kertméretű kertes házat, és a legnagyobb beépíthető telket. Jelenítse meg az így meghatározott ingatlanok összes adatát!
        //14.3.1 lol
        listBox2.Items.Add("határozza meg a legnagyobb kertméretű kertes házat:");
        int szamlalo = 0;
        int max = 0;
        int maxId = 0;
        foreach (var ingatlan in ingatlanok)
        {
          if((ingatlan as Kerteshaz) != null)//megpróbáljuk átkasztolni ha !=null akkor az adott ingatlan az Kertesház
          {
            if(max < (ingatlan as Kerteshaz).KertTerulet)
            {
              max = (ingatlan as Kerteshaz).KertTerulet;
              maxId = szamlalo;//szimpla maximum kiválasztás
            }
          }
          szamlalo++;
        }
        listBox2.Items.Add(ingatlanok[maxId].ToString());

        //14.3.2 lol
        //legnagyobb beépíthető telek
        listBox2.Items.Add("legnagyobb beépíthető telket:");
        int szamlalo2 = 0;
        int max2 = 0;
        int maxId2 = 0;
        foreach (var ingatlan in ingatlanok)
        {
          if ((ingatlan as Telek).Beepithetoe == true)//megpróbáljuk átkasztolni ha !=null akkor az adott ingatlan az Telek
          {
            if(max2 < (ingatlan as Telek).Telekmeret)
            {
              max2 = (ingatlan as Telek).Telekmeret;
              maxId2 = szamlalo2;//szimpla maximum kiválasztás
            }
          }
          szamlalo2++;
        }
        listBox2.Items.Add(ingatlanok[maxId2].ToString());
      }
    }
  }
}
