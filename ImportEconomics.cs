using System;
using System.Collections.Generic;
using System.Text;
using Economic.Api;
using Economic.Api.Data;
using Economic.Api.Exceptions;
using System.IO;
using System.Data;
using System.Windows.Forms;


namespace RBOS
{
    
    
    class ImportEconomics
    {

        private int EconomicsContractID;
        private string EconomicsUserID;
        private string EconomicsPassword;
        #region METHOD: ImportDebitor
        /// <summary>
        /// </summary>
        /// <param name="SenesteDatoHentet">Sæt til DateTime.MinValue hvis alle data skal hentes.</param>
        public int ImportDebitor(DateTime SenesteDatoHentet)
        {
            /*
            int i = 0;
            SenesteDatoHentet = SenesteDatoHentet.Date;

            GetEconomicsLogonInformation();
            string myIdentifier = "Retail-BOS/2.01.071(http://danskretail.dk/; peter.nielsen@danskretail.dk)";
            string LocalToken = db.GetConfigString("TokenLocal");
            string DRSToken = db.GetConfigString("TokenDRS");
            EconomicSession session = new EconomicSession(myIdentifier);            
            
            try
            {
                if (LocalToken == "")
                  session.Connect(EconomicsContractID, EconomicsUserID, EconomicsPassword);
                else
                    session.ConnectWithToken(LocalToken, DRSToken);
                
            }
            catch
            {
                
                return (-1);
            }
                IDebtor[] debtors;

                if (SenesteDatoHentet == DateTime.MinValue)
                    debtors = session.Debtor.GetAll();
                else
                    debtors = session.Debtor.GetAllUpdated(SenesteDatoHentet.AddDays(-1), false);

                // gem dags dato som seneste hentet
                db.SetConfigString("ImportEconomics.SenesteDatoHentet", DateTime.Now.Date);

                int AntalDebitorer = debtors.Length;
                if (debtors.Length > 0)
                {
                    string arriveDir;
                    ProgressForm Progress = new ProgressForm("importerer debitorer");
                    arriveDir = db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\";
                    arriveDir += "RRDebitorData.rrd";
                    System.IO.StreamWriter file = new System.IO.StreamWriter(arriveDir,false,tools.Encoding());
                    ManualUpdatesForm ManUpdForm = new ManualUpdatesForm();
                    ManUpdForm.SetupProgressBar("Importerer debitorer",AntalDebitorer);
                    Progress.ProgressMax = AntalDebitorer;

                    Progress.Show();

                    string filecontent = "";

                    while (i < AntalDebitorer)
                    {
                        string Att;

                        if (debtors[i].Attention == null)
                            Att = "";
                        else
                        {

                            IDebtorContact[] debtorscontact = session.DebtorContact.FindByName(debtors[i].Attention.Name);
                            Att = debtorscontact[0].Name;


                        }

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(debtors[i].Number + "||" +
                        debtors[i].Name + "||||" +
                        debtors[i].Address + "||||" +
                        debtors[i].PostalCode + "||" +
                        debtors[i].City + "||");
                        sb.Append(Att + "||" +
                        debtors[i].TelephoneAndFaxNumber + "||||||||||||" +
                        debtors[i].Email + "||" +
                        debtors[i].Website + "||");
                        string outputtxt = sb.ToString();
                        file.WriteLine(outputtxt);

                        i++;
                    }
                    file.Write(filecontent);
                    file.Close();
                    session.Disconnect();
                    Progress.Close();
                    ManUpdForm.UpdateRRDebitorData();
                    return (i);

                }
                else return (0);
            */
            return (0);
          
            
        }
        

        #endregion
        #region Method: GetEconomicsLogonInformation
        private void GetEconomicsLogonInformation()
        {
            try
            {
                EconomicsContractID = AdminDataSet.SiteInformationDataTable.GetEconomicsContractID();
                EconomicsUserID = AdminDataSet.SiteInformationDataTable.GetEconomicsUserID();
                EconomicsPassword = AdminDataSet.SiteInformationDataTable.GetEconomicsUserPassword();   
                
            }
            catch (Exception e) { throw (e); }
        }
        #endregion
    }
}