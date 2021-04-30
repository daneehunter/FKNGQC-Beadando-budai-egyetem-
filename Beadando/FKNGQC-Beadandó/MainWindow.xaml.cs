using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FKNGQC_Beadandó
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Lista létrehozása
        /// </summary>
        List<Szamlatulajdonos> Ember = new List<Szamlatulajdonos>();
        // Main kezdete
        //----------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// A MainWidow létrehozza nekünk az alap két db emberünket a listába 
        /// </summary>
        public MainWindow()
        {
            Ember.Add(
                new Szamlatulajdonos
                {
                    Neve = "Beta",
                    Egyenlege = 2500

                }
            );
            Ember.Add(
                new Szamlatulajdonos
                {
                    Neve = "Alfa",
                    Egyenlege = 3500
                }
            );
            InitializeComponent();
            // Itt teszem bele a Textekbe a nevet és hozzátartozó egyenleget
            //Bal tulajdonos
            szamlatulajaB.Text = Ember[0].Neve;
            szamlaegyenlegeB.Text = Convert.ToString(Ember[0].Egyenlege);
            //Jobb tulajdonos
            szamlatulajaJ.Text = Ember[1].Neve;
            szamlaegyenlegeJ.Text = Convert.ToString(Ember[1].Egyenlege);

        }
        // Main vége
        //----------------------------------------------------------------------------------------------------------------------------------------------


        // Feltöltés kezdete
        //----------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// A Bal oldali gomb megnyomosávával feltölti a számlát
        /// </summary>
        public void FeltoltesB(object sender, RoutedEventArgs e)
        {
           //Segédváltozó arra,hogy szám-e az adott dolog fontos,hogy INT
            int szam;
            //Segédváltozó a kiíratáshoz, mert nem tudom másképpen a számot kiírtani
            string segedvaltozo = bevitelimezoB.Text;
         
            //Ellenőrzöm,hogy az adott beviteli mezőm szám ,ha igen akkor lefut a feltöltés eventem amivel nézek minden hiba lehetőséget.
            if (Int32.TryParse(bevitelimezoB.Text, out szam) == true)
            {
                if (Convert.ToInt32(bevitelimezoB.Text) >= 0)
                {
                    Ember[0].Egyenlege += Convert.ToInt32(bevitelimezoB.Text);
                    szamlaegyenlegeB.Text = Convert.ToString(Ember[0].Egyenlege);
                    bevitelimezoB.Text = "";

                    MessageBox.Show("Sikeresen feltöltöttél: " + segedvaltozo + "Ft-ot");
                }

                else if (Convert.ToInt32(bevitelimezoB.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz feltölteni kevesebb összeget, mint 0!");
                }
            }
            else if (bevitelimezoB.Text == "")
            {
                MessageBox.Show("Nem lehet üres a Beviteli Mező!");
            }
            else
            {
                MessageBox.Show("Kérlek számot adj meg!");
            }

        }
        /// <summary>
        /// A jobb oldali gomb megnyomásával feltölti a számlát
        /// </summary>

        public void FeltoltesJ(object sender, RoutedEventArgs e)
        {
 
            int szam;
            string segedvaltozo = bevitelimezoJ.Text;

            if (Int32.TryParse(bevitelimezoJ.Text, out szam) == true)
            {
                if (bevitelimezoJ.Text != "" && Convert.ToInt32(bevitelimezoJ.Text) >= 0)
                {
                    Ember[1].Egyenlege += Convert.ToInt32(bevitelimezoJ.Text);
                    szamlaegyenlegeJ.Text = Convert.ToString(Ember[1].Egyenlege);
                    bevitelimezoJ.Text = "";

                    MessageBox.Show("Sikeresen feltöltöttél: " + segedvaltozo + "Ft-ot");
                }
                else if (bevitelimezoJ.Text == "")
                {
                    MessageBox.Show("Nem lehet üres a Beviteli Mező!");
                }
                else if (Convert.ToInt32(bevitelimezoJ.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz feltölteni kevesebb összeget, mint 0!");
                }
            }
            else
            {
                MessageBox.Show("Kérlek számot adj meg!");
            }

            
        }
   
        // Feltöltés vége
        //----------------------------------------------------------------------------------------------------------------------------------------------
        // Utalás kezdete
        //----------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// A Bal oldali gomb megnyomosávával átutal egyik számláról a másikra
        /// </summary>
        private void UtalasB(object sender, RoutedEventArgs e)
        {
            int szam;
            string segedvaltozo = bevitelimezoB.Text;

            if (Int32.TryParse(bevitelimezoB.Text, out szam) == true)
            {

                if (Convert.ToInt32(bevitelimezoB.Text) >= 0 && Convert.ToInt32(bevitelimezoB.Text) <= Ember[0].Egyenlege)
                {
                    Ember[1].Egyenlege += Convert.ToInt32(bevitelimezoB.Text);
                    Ember[0].Egyenlege -= Convert.ToInt32(bevitelimezoB.Text);
                    szamlaegyenlegeJ.Text = Convert.ToString(Ember[1].Egyenlege);
                    szamlaegyenlegeB.Text = Convert.ToString(Ember[0].Egyenlege);
                    bevitelimezoB.Text = "";

                    MessageBox.Show("Sikeresen átultaltál: " + segedvaltozo + "Ft-ot");
                }
                else if(Convert.ToInt32(bevitelimezoB.Text) > Ember[0].Egyenlege)
                {
                    MessageBox.Show("Nincs elég pénz a számládon");
                }
                else if (Convert.ToInt32(bevitelimezoB.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz utalni kevesebb összeget, mint 0!");
                }
            }
            else if (bevitelimezoB.Text == "")
            {
                MessageBox.Show("Nem lehet üres a Beviteli Mező!");
            }
            else
            {
                MessageBox.Show("Kérlek számot adj meg!");
            }

        }
        /// <summary>
        /// A jobb oldali gomb megnyomásával átutal egyik számláról a másikra
        /// </summary>
        private void UtalasJ(object sender, RoutedEventArgs e)
        {
            int szam;
            string segedvaltozo = bevitelimezoJ.Text;

            if (Int32.TryParse(bevitelimezoJ.Text, out szam) == true)
            {

                if (Convert.ToInt32(bevitelimezoJ.Text) >= 0 && Convert.ToInt32(bevitelimezoJ.Text) <= Ember[1].Egyenlege)
                {
                    Ember[0].Egyenlege += Convert.ToInt32(bevitelimezoJ.Text);
                    Ember[1].Egyenlege -= Convert.ToInt32(bevitelimezoJ.Text);
                    szamlaegyenlegeB.Text = Convert.ToString(Ember[0].Egyenlege);
                    szamlaegyenlegeJ.Text = Convert.ToString(Ember[1].Egyenlege);
                    bevitelimezoJ.Text = "";

                    MessageBox.Show("Sikeresen átultaltál: " + segedvaltozo + "Ft-ot");
                }
                else if (Convert.ToInt32(bevitelimezoJ.Text) > Ember[1].Egyenlege)
                {
                    MessageBox.Show("Nincs elég pénz a számládon");
                }
                else if (Convert.ToInt32(bevitelimezoJ.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz utalni kevesebb összeget, mint 0!");
                }
            }
            else if (bevitelimezoJ.Text == "")
            {
                MessageBox.Show("Nem lehet üres a Beviteli Mező!");
            }
            else
            {
                MessageBox.Show("Kérlek számot adj meg!");
            }
        }


        // Utalás vége
        //----------------------------------------------------------------------------------------------------------------------------------------------
        // Kivét kezdete
        //----------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// A Bal oldali gomb megnyomosávával kivesz a számláról
        /// </summary>
        private void KivetB(object sender, RoutedEventArgs e)
        {


            int szam;
            string segedvaltozo = bevitelimezoB.Text;

            if (Int32.TryParse(bevitelimezoB.Text, out szam) == true)
            {
                if (Convert.ToInt32(bevitelimezoB.Text) >= 0 && Convert.ToInt32(bevitelimezoB.Text) < Ember[0].Egyenlege)
                {
                    Ember[0].Egyenlege -= Convert.ToInt32(bevitelimezoB.Text);
                    szamlaegyenlegeB.Text = Convert.ToString(Ember[0].Egyenlege);
                    bevitelimezoB.Text = "";

                    MessageBox.Show("Sikeresen kivettél: " + segedvaltozo + "Ft-ot");
                }
                //Kis bónusz megerősítés a kivételre
                else if (Convert.ToInt32(bevitelimezoB.Text) == Ember[0].Egyenlege)
                {
                   
                        MessageBoxResult valasztas = MessageBox.Show("Biztos le szeretné venni az összes pénzt?", "Ellenrözés", MessageBoxButton.YesNo);
                        switch (valasztas)
                        {
                            case MessageBoxResult.Yes:
                                Ember[0].Egyenlege -= Convert.ToInt32(bevitelimezoB.Text);
                                szamlaegyenlegeB.Text = Convert.ToString(Ember[0].Egyenlege);
                                bevitelimezoB.Text = "";
                            break;
                            case MessageBoxResult.No:
                                MessageBox.Show("Sikeresen megszakította!");
                            break;
                        }
                
                }
                else if (Convert.ToInt32(bevitelimezoB.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz kivenni kevesebb összeget, mint 0!");
                }
                else if (Convert.ToInt32(bevitelimezoB.Text) > Ember[0].Egyenlege)
                {
                    MessageBox.Show("Nincs ennyi pénz a számládon");
                }
            }
            else if (bevitelimezoB.Text == "")
            {
                MessageBox.Show("Nem lehet üres a Beviteli Mező!");
            }
            else
            {
                MessageBox.Show("Kérlek számot adj meg!");
            }

        }
        /// <summary>
        /// A jobb oldali gomb megnyomásával kivesz a számláról
        /// </summary>
        private void KivetJ(object sender, RoutedEventArgs e)
        {
       

            int szam;
            string segedvaltozo = bevitelimezoJ.Text;
 
            if (Int32.TryParse(bevitelimezoJ.Text, out szam) == true)
            {
                if (Convert.ToInt32(bevitelimezoJ.Text) >= 0 && Convert.ToInt32(bevitelimezoJ.Text) < Ember[1].Egyenlege)
                {
                    Ember[1].Egyenlege -= Convert.ToInt32(bevitelimezoJ.Text);
                    szamlaegyenlegeJ.Text = Convert.ToString(Ember[1].Egyenlege);
                    bevitelimezoJ.Text = "";

                    MessageBox.Show("Sikeresen kivettél: " + segedvaltozo + "Ft-ot");
                }
                else if (Convert.ToInt32(bevitelimezoJ.Text) == Ember[1].Egyenlege)
                {

                    MessageBoxResult valasztas = MessageBox.Show("Biztos le szeretné venni az összes pénzt?", "Ellenrözés", MessageBoxButton.YesNo);
                    switch (valasztas)
                    {
                        case MessageBoxResult.Yes:
                            Ember[1].Egyenlege -= Convert.ToInt32(bevitelimezoJ.Text);
                            szamlaegyenlegeJ.Text = Convert.ToString(Ember[1].Egyenlege);
                            bevitelimezoJ.Text = "";
                            break;
                        case MessageBoxResult.No:
                            MessageBox.Show("Sikeresen megszakította!");
                            break;
                    }

                }

                else if (Convert.ToInt32(bevitelimezoJ.Text) < 0)
                {
                    MessageBox.Show("Nem tudsz kivenni kevesebb összeget, mint 0!");
                }
                else if (Convert.ToInt32(bevitelimezoJ.Text) > Ember[1].Egyenlege)
                {
                    MessageBox.Show("Nincs ennyi pénz a számládon");
                }
            }
            else if (bevitelimezoJ.Text == "")
            {
                MessageBox.Show("Nem lehet üres a Beviteli Mező!");
            }
            else
            {
                MessageBox.Show("Kérlek számot adj meg!");
            }
        }

        // Kivét vége
        //----------------------------------------------------------------------------------------------------------------------------------------------
        // Név váltás kezdete
        //----------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// A Bal oldali gomb megnyomosávával megváltoztatja a nevet
        /// </summary>
        private void NevvaltasB(object sender, RoutedEventArgs e)
        {
            int szam;
            if (Int32.TryParse(bevitelimezoB.Text, out szam) == false)
            {
                if (bevitelimezoB.Text != "")
                {
                    MessageBoxResult valasztas = MessageBox.Show("Biztos megszeretnéd változtatni a nevet?", "Ellenrözés", MessageBoxButton.YesNo);
                    switch (valasztas)
                    {
                        case MessageBoxResult.Yes:
                            Ember[0].Neve = bevitelimezoB.Text;
                            szamlatulajaB.Text = Ember[0].Neve;
                            bevitelimezoB.Text = "";
                            break;
                        case MessageBoxResult.No:
                            MessageBox.Show("Nem történt meg a név változtatás");
                            break;
                    }
                }
                else if (bevitelimezoB.Text == "")
                {
                    MessageBox.Show("Nem lehet üres a Beviteli Mező");
                }
            }
            else
            {
                MessageBox.Show("Kérlek nevet adj meg!");
            }
         
        }
        /// <summary>
        /// A jobb oldali gomb megnyomásával megváltoztatja a nevet
        /// </summary>
        private void NevvaltasJ(object sender, RoutedEventArgs e)
        {
            int szam;
            if (Int32.TryParse(bevitelimezoJ.Text, out szam) == false)
            {
                if (bevitelimezoJ.Text != "")
                {
                    MessageBoxResult valasztas = MessageBox.Show("Biztos megszeretnéd változtatni a nevet?", "Ellenrözés", MessageBoxButton.YesNo);
                    switch (valasztas)
                    {
                        case MessageBoxResult.Yes:
                            Ember[1].Neve = bevitelimezoJ.Text;
                            szamlatulajaJ.Text = Ember[1].Neve;
                            bevitelimezoJ.Text = "";
                            break;
                        case MessageBoxResult.No:
                            MessageBox.Show("Nem történt meg a név változtatás");
                            break;
                    }
                }
                else if (bevitelimezoJ.Text == "")
                {
                    MessageBox.Show("Nem lehet üres a Beviteli Mező");
                }
            }
            else
            {
                MessageBox.Show("Kérlek nevet adj meg!");
            }
        }

        // Név váltás vége
        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
