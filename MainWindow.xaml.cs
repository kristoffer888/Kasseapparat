using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;


namespace Kneebruh
{
    public partial class MainWindow : Window
    {
        string username;
        public int Tekstfelt = 0;
        public int amounts = 1;
        IList<double> SumPris = new List<double>();
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
            date.Text = DateTime.Now.ToString("M/d/yyyy");
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToShortTimeString();
        }

        #region visibillity
        private void Click_Pause(object sender, RoutedEventArgs e)
        {
            Tekstfelt = 3;
            Loginside.Visibility = Visibility.Collapsed;
            vareSide.Visibility = Visibility.Collapsed;
            pause.Visibility = Visibility.Visible;
            KøbeSide.Visibility = Visibility.Collapsed;
            AddGiftcard.Visibility = Visibility.Collapsed;
            ManualPrice.Visibility = Visibility.Collapsed;
            penge_tilbage.Visibility = Visibility.Collapsed;
        }
        private void Click_Logout(object sender, RoutedEventArgs e)
        {
            allClear();
            Tekstfelt = 0;
        }
        private void Click_ManualPrice(object sender, RoutedEventArgs e)
        {
            Tekstfelt = 6;
            Loginside.Visibility = Visibility.Collapsed;
            vareSide.Visibility = Visibility.Collapsed;
            pause.Visibility = Visibility.Collapsed;
            KøbeSide.Visibility = Visibility.Collapsed;
            ManualPrice.Visibility = Visibility.Visible;
            AddGiftcard.Visibility = Visibility.Collapsed;
            penge_tilbage.Visibility = Visibility.Collapsed;
            Vare_liste.Visibility = Visibility.Collapsed;
        }
        private void Giftcard_Click(object sender, RoutedEventArgs e)
        {
            Tekstfelt = 7;
            Loginside.Visibility = Visibility.Collapsed;
            vareSide.Visibility = Visibility.Collapsed;
            pause.Visibility = Visibility.Collapsed;
            KøbeSide.Visibility = Visibility.Collapsed;
            AddGiftcard.Visibility = Visibility.Visible;
            ManualPrice.Visibility = Visibility.Collapsed;
            penge_tilbage.Visibility = Visibility.Collapsed;
            Vare_liste.Visibility = Visibility.Collapsed;
        }

        private void Back_M_Click(object sender, RoutedEventArgs e)
        {
            if (Manual_Price.Text != "")
            {
                string Man = "Name: Manual price" + " \t\t\t" + " Price: " + Manual_Price.Text + "KR";
                vareListe.Items.Add(Man);
                SumPris.Add(Convert.ToDouble(Manual_Price.Text));
                SetSum();
            }
            CSide();
            Manual_Price.Text = "";
        }
        private void Back_G_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(GiftCard.Text) >= 100)
                {
                    string Gift = "Name: Giftcard" + " \t\t\t" + " Price: " + GiftCard.Text + "KR";
                    vareListe.Items.Add(Gift);
                    SumPris.Add(Convert.ToDouble(GiftCard.Text));
                    SetSum();
                    CSide();
                    GiftCard.Text = "";
                }
                else
                {
                    MessageBox.Show("Giftcards can't be under 100KR");
                }
            }
            catch
            {
                if (GiftCard.Text == "")
                {
                    CSide();
                    GiftCard.Text = "";
                }
            }
        }
        private void Sum_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SumPris.Sum() != 0)
            {
                Tekstfelt = 4;
                Loginside.Visibility = Visibility.Collapsed;
                vareSide.Visibility = Visibility.Collapsed;
                pause.Visibility = Visibility.Collapsed;
                KøbeSide.Visibility = Visibility.Visible;
                AddGiftcard.Visibility = Visibility.Collapsed;
                ManualPrice.Visibility = Visibility.Collapsed;
                penge_tilbage.Visibility = Visibility.Collapsed;
                Vare_liste.Visibility = Visibility.Collapsed;
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CSide();
        }
        #endregion
        #region Main_Buttons
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main_Buttons("1");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main_Buttons("2");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main_Buttons("3");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Main_Buttons("4");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Main_Buttons("5");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Main_Buttons("6");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Main_Buttons("7");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Main_Buttons("8");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Main_Buttons("9");
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            Main_Buttons("0");
        }

        private void Button_Click_00(object sender, RoutedEventArgs e)
        {
            Main_Buttons("00");
        }
        private void Button_Click_comma(object sender, RoutedEventArgs e)
        {
            Main_Buttons(",");
        }

        private void Click_delete(object sender, RoutedEventArgs e)
        {
            if (Tekstfelt == 0)
            {
                Usernamebox.Text = "";
                SetSum();
            }
            else if (Tekstfelt == 1)
            {
                Password.Password = "";
                SetSum();
            }
            else if (Tekstfelt == 2)
            {
                VareNR.Text = "";
                SetSum();
            }
            else if (Tekstfelt == 3)
            {
                aPassword.Password = "";
                SetSum();
            }
            else if (Tekstfelt == 4)
            {
                Penge.Text = "";
                SetSum();
            }
            else if (Tekstfelt == 6)
            {
                Manual_Price.Text = "";
                SetSum();
            }
            else if (Tekstfelt == 7)
            {
                GiftCard.Text = "";
            }
        }
        private void Delete_Last_Click(object sender, RoutedEventArgs e)
        {
            if (Tekstfelt == 2 && VareNR.Text.Length > 0)
                VareNR.Text = VareNR.Text.Remove(VareNR.Text.Length - 1, 1);
            else if (Tekstfelt == 4 && Penge.Text.Length > 0)
                Penge.Text = Penge.Text.Remove(Penge.Text.Length - 1, 1);
        }


        #endregion
        #region Tekstfelt
        private void Username_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tekstfelt = 0;
            if (Usernamebox.Text == "Username")
                Usernamebox.Text = "";
        }

        private void Password_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tekstfelt = 1;
        }

        private void VareNR_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tekstfelt = 2;
        }

        private void aPassword_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tekstfelt = 3;
        }

        private void Penge_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tekstfelt = 4;
        }

        private void SøgVare_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tekstfelt = 5;
        }

        private void Manual_Price_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tekstfelt = 6;
        }

        private void GiftCard_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Tekstfelt = 7;
        }
        #endregion
        #region sedler
        private void seddel_500_Click(object sender, RoutedEventArgs e)
        {
            sedler(500);
        }

        private void seddel_200_Click(object sender, RoutedEventArgs e)
        {
            sedler(200);
        }

        private void seddel_1000_Click(object sender, RoutedEventArgs e)
        {
            sedler(1000);
        }

        private void seddel_100_Click(object sender, RoutedEventArgs e)
        {
            sedler(100);
        }

        private void seddel_50_Click(object sender, RoutedEventArgs e)
        {
            sedler(50);
        }
        #endregion
        #region diverse_buttons
        private void Click_Pause_login(object sender, RoutedEventArgs e)
        {

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\krist\source\repos\Kneebruh\LoginDonkey.mdf;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    string query = @"SELECT * FROM[Table] WHERE Username = '" + username + "' AND Password = '" + aPassword.Password + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    do
                    {
                        if (dr.HasRows == true)
                        {
                            CSide();
                            aPassword.Password = "";
                        }
                        else
                        {

                        }
                    } while (dr.Read());
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void Click_OK(object sender, RoutedEventArgs e)
        {

            username = Usernamebox.Text;

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\krist\source\repos\Kneebruh\LoginDonkey.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    string query = @"SELECT * FROM[Table] WHERE Username = '" + username + "' AND Password = '" + Password.Password + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    do
                    {
                        if (dr.HasRows == true)
                        {
                            CSide();
                            Usernamebox.Text = "";
                            Password.Password = "";

                        }
                        else
                        {

                        }
                    } while (dr.Read());
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception: " + ex.Message);
            }

        }
        private void Forgot_Password(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Too bad");
        }

        private void Søg_PLU(object sender, RoutedEventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\krist\source\repos\Kneebruh\LoginDonkey.mdf;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    string query = @"SELECT * FROM[Ware] WHERE PLU = '" + VareNR.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dAdapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        string navn = dr["Name"].ToString();
                        string pris = dr["Pris"].ToString();
                        string vare = "Name: " + navn + " \t\t\t" + " Price: " + pris + " KR";
                        for (int i = 0; i < amounts; i++)
                        {
                            vareListe.Items.Add(vare);
                            SumPris.Add(Double.Parse(pris));
                            SetSum();
                        }
                        VareNR.Text = "";
                        amounts = 1;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception: " + ex.Message);
            }


        }

        private void Søg_EAN(object sender, RoutedEventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\krist\source\repos\Kneebruh\LoginDonkey.mdf;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    string query = @"SELECT * FROM[Ware] WHERE EAN = '" + VareNR.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dAdapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        string navn = dr["Name"].ToString();
                        string pris = dr["Pris"].ToString();
                        string vare = "Name: " + navn + " \t\t\t" + " Price: " + pris + " KR";
                        for (int i = 0; i < amounts; i++)
                        {
                            vareListe.Items.Add(vare);
                            SumPris.Add(int.Parse(pris));
                            SetSum();
                        }
                        VareNR.Text = "";
                        amounts = 1;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void Vare_delete_Click(object sender, RoutedEventArgs e)
        {
            if (vareListe.SelectedIndex <= -1)
            {
                vareListe.SelectedIndex = 0;
            }
            if (vareListe.SelectedIndex > -1)
            {
                Console.WriteLine(vareListe.SelectedItem.ToString());
                string a = vareListe.SelectedItem.ToString();
                try
                {
                    Double x = Convert.ToDouble(Regex.Match(a, @"\d+\,*\d+").Value);
                    SumPris.Remove(x);
                    SetSum();
                    vareListe.Items.RemoveAt
                        (vareListe.Items.IndexOf(vareListe.SelectedItem));
                }
                catch
                {
                    Double x = Convert.ToDouble(Regex.Match(a, @"\d+\,*").Value);
                    SumPris.Remove(x);
                    SetSum();
                    vareListe.Items.RemoveAt
                        (vareListe.Items.IndexOf(vareListe.SelectedItem));
                }
            }
        }

        private void Small_bag_Click(object sender, RoutedEventArgs e)
        {
            qItems("Small bag", Convert.ToDouble("1,5"));
        }

        private void Large_bag_Click(object sender, RoutedEventArgs e)
        {
            qItems("Large bag", Convert.ToDouble("2"));
        }

        private void Beer_crate_Click(object sender, RoutedEventArgs e)
        {
            qItems("Beer crate", Convert.ToDouble("12,5"));
        }

        private void Bought_Click(object sender, RoutedEventArgs e)
        {
            allClear();
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            if (Penge.Text != "")
            {
                SumPris.Add(Convert.ToDouble(Penge.Text) * -1);
                SetSum();
                købeliste.Items.Add(Convert.ToDouble(Penge.Text) * -1);
                Penge.Text = "";
            }
            else { }
            if (SumPris.Sum() == 0)
            {
                allClear();
            }
            else if (SumPris.Sum() < 0)
            {
                byttePenge.Content = "Penge tilbage: " + SumPris.Sum() + " KR";
                Loginside.Visibility = Visibility.Collapsed;
                vareSide.Visibility = Visibility.Collapsed;
                pause.Visibility = Visibility.Collapsed;
                KøbeSide.Visibility = Visibility.Collapsed;
                AddGiftcard.Visibility = Visibility.Collapsed;
                ManualPrice.Visibility = Visibility.Collapsed;
                penge_tilbage.Visibility = Visibility.Visible;
                Vare_liste.Visibility = Visibility.Collapsed;

            }
        }

        private void amount_Click(object sender, RoutedEventArgs e)
        {
            if (VareNR.Text != "")
            {
                amounts = int.Parse(VareNR.Text);
                VareNR.Clear();
            }
        }

        private void Ware_Click(object sender, RoutedEventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\krist\source\repos\Kneebruh\LoginDonkey.mdf;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    string query = @"SELECT * FROM[Ware]";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dAdapter.Fill(dt);
                    if (Box.Items.IsEmpty)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string navn = dr["Name"].ToString();
                            string EAN = dr["EAN"].ToString();
                            string PLU = dr["PLU"].ToString();
                            string wares = "Name: " + navn + " \t\t\t" + " EAN: " + EAN + " \t\t\t" + " PLU: " + PLU;
                            Box.Items.Add(wares);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception: " + ex.Message);
            }
            Loginside.Visibility = Visibility.Collapsed;
            vareSide.Visibility = Visibility.Collapsed;
            pause.Visibility = Visibility.Collapsed;
            KøbeSide.Visibility = Visibility.Collapsed;
            ManualPrice.Visibility = Visibility.Collapsed;
            AddGiftcard.Visibility = Visibility.Collapsed;
            penge_tilbage.Visibility = Visibility.Collapsed;
            Vare_liste.Visibility = Visibility.Visible;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (købeliste.SelectedIndex <= -1)
            {
                købeliste.SelectedIndex = 0;
            }
            if (købeliste.SelectedIndex > -1)
            {
                double a = Convert.ToDouble(købeliste.SelectedItem.ToString());
                SumPris.Add(a * -1);
                SetSum();
                købeliste.Items.RemoveAt
                        (købeliste.Items.IndexOf(købeliste.SelectedItem));
            }
        }
        #endregion
        #region Funktioner


        void Main_Buttons(string x)
        {
            if (Tekstfelt == 0)
                Usernamebox.Text += x;
            else if (Tekstfelt == 1)
                Password.Password += x;
            else if (Tekstfelt == 2)
                VareNR.Text += x;
            else if (Tekstfelt == 3)
                aPassword.Password += x;
            else if (Tekstfelt == 4)
                Penge.Text += x;
            else if (Tekstfelt == 6)
                Manual_Price.Text += x;
            else if (Tekstfelt == 7)
                GiftCard.Text += x;
        }


        void qItems(string name, Double price)
        {

            string item = "Name: " + name + "\t\t\t" + "Price: " + price + " KR";
            vareListe.Items.Add(item);
            SumPris.Add(price);
            SetSum();
        }
        
        void sedler(int x)
        {
            købeliste.Items.Add(-x);
            SumPris.Add(-x);
            SetSum();
            if (SumPris.Sum() == 0)
            {
                allClear();
            }
            else if (SumPris.Sum() < 0)
            {
                byttePenge.Content = "Penge tilbage: " + SumPris.Sum() + " KR";
                Loginside.Visibility = Visibility.Collapsed;
                vareSide.Visibility = Visibility.Collapsed;
                pause.Visibility = Visibility.Collapsed;
                KøbeSide.Visibility = Visibility.Collapsed;
                AddGiftcard.Visibility = Visibility.Collapsed;
                ManualPrice.Visibility = Visibility.Collapsed;
                penge_tilbage.Visibility = Visibility.Visible;
                Vare_liste.Visibility = Visibility.Collapsed;
            }
        }

        void SetSum()
        {
            Sum.Content = SumPris.Sum() + " KR";
            aSum.Content = SumPris.Sum() + " KR";
        }
        
        void CSide()
        {
            Tekstfelt = 2;
            Loginside.Visibility = Visibility.Collapsed;
            vareSide.Visibility = Visibility.Visible;
            pause.Visibility = Visibility.Collapsed;
            KøbeSide.Visibility = Visibility.Collapsed;
            AddGiftcard.Visibility = Visibility.Collapsed;
            ManualPrice.Visibility = Visibility.Collapsed;
            penge_tilbage.Visibility = Visibility.Collapsed;
            Vare_liste.Visibility = Visibility.Collapsed;
        }

        void allClear()
        {
            købeliste.Items.Clear();
            Sum.Content = "";
            aSum.Content = "";
            SumPris.Clear();
            Usernamebox.Clear();
            Password.Clear();
            VareNR.Text = "";
            aPassword.Clear();
            Penge.Text = "";
            Manual_Price.Clear();
            GiftCard.Clear();
            vareListe.Items.Clear();
            CSide();
        }
        #endregion
    }
}