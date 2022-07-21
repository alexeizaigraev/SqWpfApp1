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
using System.Windows.Shapes;

namespace SqWpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WindowTerm.xaml
    /// </summary>
    public partial class WindowTerm : Window
    {
        public WindowTerm()
        {
            InitializeComponent();

            #region

            textBoxProducer.Text = "ДАТЕКС ООД";
            textBoxToRro.Text = "ТОВ ПОС";
            textBoxTicketArhiv.Text = "Активний";
            textBoxOroNumber.Text = "1";
            textBoxTicketNumber.Text = "1";

            cmbModel.ItemsSource = DbTerm.GetModels();
            cmbOwner.ItemsSource = DbTerm.GetOwners();
            cmbSoft.ItemsSource = DbTerm.GetSofts();
            cmbSeal.ItemsSource = DbTerm.GetSeals();
            cmbTicketArhiv.ItemsSource = DbTerm.GetStatusList();
            #endregion
        }

        private void ComboBoxModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region
            textBoxModel.Text = cmbModel.SelectedItem.ToString();
            #endregion
        }

        private void ComboBoxOwner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region
            textBoxOwnerRro.Text = cmbOwner.SelectedItem.ToString();
            #endregion
        }

        private void ComboBoxSoft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region
            textBoxSoft.Text = cmbSoft.SelectedItem.ToString();
            #endregion
        }

        private void ComboBoxSeal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region
            textBoxSealing.Text = cmbSeal.SelectedItem.ToString();
            #endregion
        }

        private void ComboBoxTicketArhiv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBoxTicketArhiv.Text = cmbTicketArhiv.SelectedItem.ToString();
        }

        private void ClearMe()
        {
            #region
            textBoxDepartment.Text = "";
            textBoxTermial.Text = "";
            textBoxModel.Text = "";
            textBoxSerialNumber.Text = "";
            textBoxDateManufacture.Text = "";
            textBoxSoft.Text = "";
            textBoxProducer.Text = "ДАТЕКС ООД";
            textBoxRneRro.Text = "";
            textBoxSealing.Text = "";
            textBoxFiscalNumber.Text = "";
            textBoxOroSerial.Text = "";
            textBoxOroNumber.Text = "1";
            textBoxTicketSerial.Text = "";
            textBoxTicket1Sheet.Text = "";
            textBoxTicketNumber.Text = "1";
            textBoxSending.Text = "";
            textBoxToRro.Text = "ТОВ ПОС";
            textBoxOwnerRro.Text = "";
            textBoxRegister.Text = "";
            textBoxFinish.Text = "";
            textBoxBookApyiv.Text = "";
            textBoxTicketArhiv.Text = "Активний";

            textBoxFind.Text = "";

            textBoxAddress.Text = "";
            labeKoatu.Content = "";
            labeKoatu2.Content = "";
            labeTaxId.Content = "";
            labeInfo.Content = "";

            cmbModel.SelectedIndex = 0;
            cmbOwner.SelectedIndex = 0;
            cmbSoft.SelectedIndex = 0;
            cmbSeal.SelectedIndex = 0;
            cmbTicketArhiv.SelectedIndex = 0;
            #endregion
        }

        private void WinTermClear_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
        }

        private List<string> GetCurrentData()
        {
            #region
            List<string> vec = new List<string>()
                {
                    textBoxDepartment.Text,
                    textBoxTermial.Text,
                    textBoxModel.Text,
                    textBoxSerialNumber.Text,
                    textBoxDateManufacture.Text,
                    textBoxSoft.Text,
                    textBoxProducer.Text,
                    textBoxRneRro.Text,
                    textBoxSealing.Text,
                    textBoxFiscalNumber.Text,
                    textBoxOroSerial.Text,
                    textBoxOroNumber.Text,
                    textBoxTicketSerial.Text,
                    textBoxTicket1Sheet.Text,
                    textBoxTicketNumber.Text,
                    textBoxSending.Text,
                    textBoxBookApyiv.Text,
                    textBoxTicketArhiv.Text,
                    textBoxToRro.Text,
                    textBoxOwnerRro.Text,
                    textBoxRegister.Text,
                    textBoxFinish.Text
                };
            if (vec[6] == "") vec[6] = "ДАТЕКС ООД";
            if (vec[18] == "") vec[18] = "ТОВ ПОС";
            vec = Papa.GoodVec(vec);
            return vec;
            #endregion
        }



        private void WinTermFind_Click(object sender, RoutedEventArgs e)
        {
            #region
            string term = "";

            try { term = textBoxFind.Text; }
            catch { MessageBox.Show("Напиши терминал в окошко"); }

            if (term != "")
            {
                try { Show(term); }
                catch { }
                //catch { MessageBox.Show("Напиши правильно терминал"); }
            }
            //else { MessageBox.Show("Напиши отделение в окошко"); }
            #endregion
        }

        private void Show(string term)
        {
            #region
            var data = DbTerm.GetOneTermData(term);
            if (data[6] == "") data[6] = "ДАТЕКС ООД";
            if (data[18] == "") data[18] = "ТОВ ПОС";
            ClearMe();

            textBoxDepartment.Text = data[0];
            textBoxTermial.Text = data[1];
            textBoxModel.Text = data[2];
            textBoxSerialNumber.Text = data[3];
            textBoxDateManufacture.Text = data[4];
            textBoxSoft.Text = data[5];
            textBoxProducer.Text = data[6];
            textBoxRneRro.Text = data[7];
            textBoxSealing.Text = data[8];
            textBoxFiscalNumber.Text = data[9];
            textBoxOroSerial.Text = data[10];
            textBoxOroNumber.Text = data[11];
            textBoxTicketSerial.Text = data[12];
            textBoxTicket1Sheet.Text = data[13];
            textBoxTicketNumber.Text = data[14];
            textBoxSending.Text = data[15];
            textBoxBookApyiv.Text = data[16];
            textBoxTicketArhiv.Text = data[17];
            textBoxToRro.Text = data[18];
            textBoxOwnerRro.Text = data[19];
            textBoxRegister.Text = data[20];
            textBoxFinish.Text = data[21];

            textBoxAddress.Text = DbTerm.GetAddress(data[0]);

            try { labeKoatu.Content = DbTerm.GetKoatu(data[0]); }
            catch { labeKoatu.Content = ""; }
            try { labeKoatu2.Content = DbTerm.GetKoatu2(data[0]); }
            catch { labeKoatu.Content = ""; }
            try { labeTaxId.Content = DbTerm.GetTaxId(data[0]); }
            catch { labeKoatu.Content = ""; }
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            labeKoatu2.Content = DbTerm.GetKoatu2(data[0]);
            #endregion
        }

        private void WinTermAdd_Click(object sender, RoutedEventArgs e)
        {
            #region
            List<string> vec = GetCurrentData();
            try
            {
                //PgBase.TermAddOne(vec);
                DbTerm.AddTerm(vec);
                labeInfo.Content = vec[1];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            #endregion
        }

        private void WinTermDel_Click(object sender, RoutedEventArgs e)
        {
            #region
            bool flag = false;
            string term = "";
            if (textBoxTermial.Text != "" && textBoxFind.Text == "")
            {
                term = textBoxTermial.Text;
                flag = true;
            }
            if (textBoxTermial.Text == "" && textBoxFind.Text != "")
            {
                term = textBoxFind.Text;
                flag = true;
            }
            if (flag)
            {
                try { DbTerm.DelTerm(term); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
            else
            {
                MessageBox.Show("Выбери терминал, олух");
            }
            #endregion
        }

        private void WinTermUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (textBoxTermial.Text != "") { flag = true; }
            if (flag)
            {
                List<string> vec = GetCurrentData();
                try { DbTerm.AddTerm(vec); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                labeInfo.Content = Papa.info;
            }
        }

        private void WinTermForward_Click(object sender, RoutedEventArgs e)
        {
            #region
            string term = textBoxTermial.Text;
            string next = DbTerm.NextTerm(term);
            Show(next);
            #endregion
        }

        private void WinTermBack_Click(object sender, RoutedEventArgs e)
        {
            #region
            try
            {
                string term = textBoxTermial.Text;
                string pred = DbTerm.PredTerm(term);
                Show(pred);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            #endregion
        }


        private void ButtonOtborInputZn_Click(object sender, RoutedEventArgs e)
        {
            var input = textBoxFind.Text;
            try
            {
                string term = DbTerm.SerialToTermOne(input);
                Show(term);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ButtonOtborInputFiscal_Click(object sender, RoutedEventArgs e)
        {
            var input = textBoxFind.Text;
            try
            {
                string term = DbTerm.FiscalToTermOne(input);
                Show(term);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void ButtonFindAny_Click(object sender, RoutedEventArgs e)
        {
            List<string> terms = DbTerm.GetTermList();
            List<string> serials = DbTerm.GetSerialList();
            List<string> fiscals = DbTerm.GetFiscalList();

            var input = textBoxFind.Text;

            if (terms.IndexOf(input) > -1)
            {
                try { Show(input); }
                catch { }
            }
            else if (serials.IndexOf(input) > -1)
            {
                try
                {
                    string term = DbTerm.SerialToTermOne(input);
                    Show(term);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else if (fiscals.IndexOf(input) > -1)
            {
                try
                {
                    string term = DbTerm.FiscalToTermOne(input);
                    Show(term);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }


    }
}
