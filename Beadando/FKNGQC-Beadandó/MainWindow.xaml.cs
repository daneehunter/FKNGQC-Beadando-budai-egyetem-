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
            /// <summary>
            /// Számla1 infók
            /// </summary>
            szamlatulajaB.Text = Ember[0].Neve;
            szamlaegyenlegeB.Text = Convert.ToString(Ember[0].Egyenlege);
            /// <summary>
            /// Számla2 infók
            /// </summary>
            szamlatulajaJ.Text = Ember[1].Neve;
            szamlaegyenlegeJ.Text = Convert.ToString(Ember[1].Egyenlege);

        }
        // Main vége
        //----------------------------------------------------------------------------------------------------------------------------------------------


        // Feltöltés kezdete
        //----------------------------------------------------------------------------------------------------------------------------------------------
        public void FeltoltesB(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Segéd változókat létrehozom a későbbiekben 
            /// </summary>

            int szam;
            string segedvaltozo = bevitelimezoB.Text;
            /// <summary>
            /// Ellenőrzöm,hogy az adott beviteli mezőm szám ,ha igen akkor lefut a feltöltés eventem amivel nézek minden hiba lehetőséget.
            /// </summary>
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

        public void FeltoltesJ(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Segéd változókat létrehozom a későbbiekben 
            /// </summary>
            int szam;
            string segedvaltozo = bevitelimezoJ.Text;
            /// <summary>
            /// Ellenőrzöm,hogy az adott beviteli mezőm szám ,ha igen akkor lefut a feltöltés eventem amivel nézek minden hiba lehetőséget.
            /// </summary>
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
        private void UtalasB(object sender, RoutedEventArgs e)
        {
            int szam;
            string segedvaltozo = bevitelimezoB.Text;
            /// <summary>
            /// Ellenőrzöm,hogy az adott beviteli mezőm szám ,ha igen akkor lefut a feltöltés eventem amivel nézek minden hiba lehetőséget .
            /// </summary>
            if (Int32.TryParse(bevitelimezoB.Text, out szam) == true)
            {
                /// <summary>
                /// If ágam akkor fut le,hogy ha nagyobb, mint 0 és a bevitelimezo textem kisebb mint az adott emberem egyenlege
                /// </summary>
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
        private void UtalasJ(object sender, RoutedEventArgs e)
        {
            int szam;
            string segedvaltozo = bevitelimezoJ.Text;
            /// <summary>
            /// Ellenőrzöm,hogy az adott beviteli mezőm szám ,ha igen akkor lefut a feltöltés eventem amivel nézek minden hiba lehetőséget .
            /// </summary>
            if (Int32.TryParse(bevitelimezoJ.Text, out szam) == true)
            {
                /// <summary>
                /// If ágam akkor fut le,hogy ha nagyobb, mint 0 és a bevitelimezo textem kisebb mint az adott emberem egyenlege
                /// </summary>
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
                    MessageBox.Show("Nem tudsz feltölteni kevesebb összeget, mint 0!");
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
        private void KivetB(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Segéd változókat létrehozom a későbbiekben 
            /// </summary>

            int szam;
            string segedvaltozo = bevitelimezoB.Text;
            /// <summary>
            /// Ellenőrzöm,hogy az adott beviteli mezőm szám ,ha igen akkor lefut a feltöltés eventem amivel nézek minden hiba lehetőséget.
            /// </summary>
            if (Int32.TryParse(bevitelimezoB.Text, out szam) == true)
            {
                if (Convert.ToInt32(bevitelimezoB.Text) >= 0 && Convert.ToInt32(bevitelimezoB.Text) < Ember[0].Egyenlege)
                {
                    Ember[0].Egyenlege -= Convert.ToInt32(bevitelimezoB.Text);
                    szamlaegyenlegeB.Text = Convert.ToString(Ember[0].Egyenlege);
                    bevitelimezoB.Text = "";

                    MessageBox.Show("Sikeresen kivettél: " + segedvaltozo + "Ft-ot");
                }
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
        private void KivetJ(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Segéd változókat létrehozom a későbbiekben 
            /// </summary>

            int szam;
            string segedvaltozo = bevitelimezoJ.Text;
            /// <summary>
            /// Ellenőrzöm,hogy az adott beviteli mezőm szám ,ha igen akkor lefut a feltöltés eventem amivel nézek minden hiba lehetőséget.
            /// </summary>
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
        private void NevvaltasB(object sender, RoutedEventArgs e)
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
        private void NevvaltasJ(object sender, RoutedEventArgs e)
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

        // Név váltás vége
        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
