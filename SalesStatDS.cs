using System;
using System.Data;
using System.Collections.Generic;

namespace RBOS
{
    namespace SalesStatDSTableAdapters
    {
        partial class SalesStatRptTableAdapter
        {
            #region ColumnNumbers enum
            enum ColumnNumbers
            {
                TotalShop = 1,
                TotalBenzin = 2,
                TotalDiesel = 3,
                Custom1 = 4,
                Custom2 = 5,
                Custom3 = 6
            }
            #endregion

            #region UnitOrAmount enum
            // Enum that corresponds to the data
            // in table LookupUnitOrAmount
            enum UnitOrAmount
            {
                Unknown = 0,
                Unit = 1,       // liter
                Amount = 2      // beløb
            }
            #endregion

            #region CollectedData class
            /// <summary>
            /// Helper class for the parent class's FillWithCollectedData method.
            /// </summary>
            private class CollectedData
            {
                #region Private variables

                DataTable metaData = null;
                List<DataTable> colData = null;
                Dictionary<DateTime, int> customerCounts = null;

                #endregion

                #region Constructor
                public CollectedData(DateTime FirstDateInMonth, DateTime EndDate)
                {
                    metaData = LoadColumnsMetaData();
                    colData = new List<DataTable>();
                    colData.Add(LoadColumnData(ColumnNumbers.TotalShop, FirstDateInMonth.Date, EndDate.Date));
                    colData.Add(LoadColumnData(ColumnNumbers.TotalBenzin, FirstDateInMonth.Date, EndDate.Date));
                    colData.Add(LoadColumnData(ColumnNumbers.TotalDiesel, FirstDateInMonth.Date, EndDate.Date));
                    colData.Add(LoadColumnData(ColumnNumbers.Custom1, FirstDateInMonth.Date, EndDate.Date));
                    colData.Add(LoadColumnData(ColumnNumbers.Custom2, FirstDateInMonth.Date, EndDate.Date));
                    colData.Add(LoadColumnData(ColumnNumbers.Custom3, FirstDateInMonth.Date, EndDate.Date));
                    customerCounts = LoadCustomerCounts(FirstDateInMonth.Date, EndDate.Date);
                }
                #endregion

                #region GetFieldData
                public double GetFieldData(ColumnNumbers ColumnNo, DateTime BookDate)
                {
                    int idx = (int)ColumnNo - 1;
                    if ((idx < colData.Count) && (idx >= 0))
                    {
                        DataRow[] rows = colData[idx].Select(string.Format("BookDate = '{0}'", BookDate.ToString("dd-MM-yyyy")));
                        DataRow[] rowsMeta = metaData.Select(string.Format("ColumnNo = {0}", (int)ColumnNo));
                        if ((rows.Length > 0) && (rowsMeta.Length > 0))
                            return tools.object2double(rows[0]["UnitOrAmount"]);
                    }
                    return 0;
                }
                #endregion

                #region GetCustomerCount
                public int GetCustomerCount(DateTime BookDate)
                {
                    if (customerCounts.ContainsKey(BookDate))
                        return customerCounts[BookDate];
                    else
                        return 0;
                }
                #endregion

                #region GetColumnTotal
                public double GetColumnTotal(ColumnNumbers ColumnNo)
                {
                    double result = 0;
                    int idx = (int)ColumnNo - 1;
                    if ((idx < colData.Count) && (idx >= 0))
                    {
                        foreach (DataRow row in colData[idx].Rows)
                            result += tools.object2double(row["UnitOrAmount"]);
                    }
                    return result;
                }
                #endregion

                #region GetTotalCustomerCount
                /// <summary>
                /// Sums all the loaded customercounts.
                /// </summary>
                public int GetTotalCustomerCount()
                {
                    int result = 0;
                    foreach (int count in customerCounts.Values)
                        result += count;
                    return result;
                }
                #endregion

                #region GetColumnHeaderText
                /// <summary>
                /// Gets the column header text for the 3 system columns
                /// and the 3 user defined columns
                /// </summary>
                public string GetColumnHeaderText(ColumnNumbers ColumnNo)
                {
                    int idx = (int)ColumnNo - 1;
                    if ((idx >= 0) && (idx < metaData.Rows.Count))
                        return tools.object2string(metaData.Rows[idx]["HeaderText"]);
                    else
                        return "";
                }
                #endregion

                #region GetColumnUnitOrAmountDesc
                public string GetColumnUnitOrAmountDesc(ColumnNumbers ColumnNo)
                {
                    if (GetColumnUnitOrAmount(ColumnNo) == UnitOrAmount.Amount)
                        return "KR.";
                    else if (GetColumnUnitOrAmount(ColumnNo) == UnitOrAmount.Unit)
                        return "LTR";
                    else
                        return "";
                }
                #endregion

                #region GetColumnUnitOrAmount
                public UnitOrAmount GetColumnUnitOrAmount(ColumnNumbers ColumnNo)
                {
                    DataRow[] rowsMeta = metaData.Select(string.Format("ColumnNo = {0}", (int)ColumnNo));
                    if (rowsMeta.Length > 0)
                    {
                        if ((tools.object2int(rowsMeta[0]["UnitOrAmount"]) == (int)UnitOrAmount.Amount))
                            return UnitOrAmount.Amount;
                        else
                            return UnitOrAmount.Unit;
                    }
                    return UnitOrAmount.Unknown;
                }
                #endregion

                #region GetAvgColumnNo
                public ColumnNumbers GetAvgColumnNo()
                {
                    // figure out what column is average
                    DataRow[] rows = metaData.Select("Average = 1");


                    if (rows.Length > 0)
                        return (ColumnNumbers)tools.object2int(rows[0]["ColumnNo"]);
                    else
                        return 0;
                }
                #endregion

                #region GetAvgColumnSales
                /// <summary>
                /// Returns the average column's sales for the specified date.
                /// The result is then divided by CustomerCount to make it average per customer.
                /// If CustomerCount is 0, 0 is returned to protect against 0 division.
                /// </summary>
                public double GetAvgColumnSales(DateTime BookDate, int CustomerCount)
                {
                    // check for 0 division
                    if (CustomerCount == 0)
                        return 0;

                    // get the sales value from the average column on the specified date
                    int idx = ((int)GetAvgColumnNo()) - 1;
                    double sales = 0;
                    DataRow[] rows = colData[idx].Select(string.Format("BookDate = '{0}'", BookDate.ToString("dd-MM-yyyy")));
                    if (rows.Length > 0)
                        sales = tools.object2double(rows[0]["UnitOrAmount"]);

                    // calculate and return the average value
                    return (sales / CustomerCount);
                }
                #endregion

                #region GetAvgColumnSales
                /// <summary>
                /// Returns the average column's sales.
                /// The result is then divided by CustomerCount to make it average per customer.
                /// </summary>
                public double GetAvgColumnSales(int CustomerCount)
                {
                    return GetColumnTotal(GetAvgColumnNo());
                }
                #endregion

                #region GetVPowerPct
                /// <summary>
                /// Beregning af hvor stor en andel (pct) udgør V-Power litre af det samlede benzinsalg.
                /// </summary>
                public double GetVPowerPct(DateTime BookDate, double TotalBenzinSalg)
                {
                    if (TotalBenzinSalg == 0) return 0; // check for 0 division
                    double VPowerLitre = EODDataSet.EOD_SalesDataTable.GetVPowerSalesLitres(BookDate.Date);
                    return ((VPowerLitre / TotalBenzinSalg) * 100);
                }
                #endregion

                #region GetVPowerPctTotal
                public double GetVPowerPctTotal(DateTime FirstDateInMonth, DateTime EndDate)
                {
                    double VPowerLitreTotal = 0;
                    for (DateTime dt = FirstDateInMonth.Date; dt.Date <= EndDate.Date; dt = dt.AddDays(1))
                        VPowerLitreTotal += EODDataSet.EOD_SalesDataTable.GetVPowerSalesLitres(dt);
                    double GrandTotalBenzinSalg = GetColumnTotal(ColumnNumbers.TotalBenzin);
                    return ((VPowerLitreTotal / GrandTotalBenzinSalg) * 100);
                }
                #endregion

                #region GetVPowerLiterOverUnder
                /// <summary>
                /// Beregning af hvor mange litre V-Power der skulle
                /// have været solgt mere af, for at opnå det budgetterede
                /// antal litre for V-Power. Negativt tal returneret
                /// betyder hvor mange litre, der mangler, mens positivt
                /// tal returneret, betyder hvor mange litre, der er blevet
                /// solgt over budgettet.
                /// </summary>
                public double GetVPowerLiterOverUnder(DateTime BookDate, double TotalBenzinSalg)
                {
                    /// Beregningseksempel:
                    /// 
                    /// Budgetteret benzinsalg: 100 liter
                    /// Budgetteret V-Power salg: 10 liter
                    /// Budgetteret V-Power andel: 10%
                    /// 
                    /// Faktisk benzinsalg: 50 liter
                    /// Faktisk V-Power salg: 4 liter
                    /// 
                    /// Benzinsalget er på 50 og da V-Power skal være 10% af det,
                    /// skal V-Power være 5 liter. Men der blev kun solgt
                    /// 4 liter V-Power, dvs. 4 - 5 = -1 giver, at der skulle
                    /// have været solgt 1 liter mere, for at budgettet for
                    /// V-Power var nået. Tallet -1 returneres.

                    double BudgetteretBenzinSalg = EODDataSet.GLBudgetDataTable.GetBudget(
                        BookDate.Year,
                        BookDate.Month,
                        GetGLCodesForColumn(ColumnNumbers.TotalBenzin),
                        EODDataSet.GLBudgetDataTable.BudgetUnit.Volume);

                    // check for division by 0
                    if (BudgetteretBenzinSalg != 0)
                    {
                        double BudgetteretVPowerSalg =
                            EODDataSet.GLBudgetDataTable.GetVPowerBudget(BookDate.Year, BookDate.Month);
                        double BudgetteretVPowerAndel = ((BudgetteretVPowerSalg / BudgetteretBenzinSalg));

                        double FaktiskBenzinSalg = TotalBenzinSalg;
                        double FaktiskVPowerSalg = EODDataSet.EOD_SalesDataTable.GetVPowerSalesLitres(BookDate.Date);

                        double VPowerSkalVaere = FaktiskBenzinSalg * BudgetteretVPowerAndel;
                        return (FaktiskVPowerSalg - VPowerSkalVaere);
                    }
                    return 0;
                }
                #endregion

                #region GetVPowerLiterOverUnderTotal
                public double GetVPowerLiterOverUnderTotal(DateTime FirstDateInMonth, DateTime EndDate)
                {
                    double VPowerLiterOverUnderTotal = 0;
                    for (DateTime dt = FirstDateInMonth.Date; dt.Date <= EndDate.Date; dt = dt.AddDays(1))
                    {
                        double TotalBenzinSalg = GetFieldData(ColumnNumbers.TotalBenzin, dt.Date);
                        VPowerLiterOverUnderTotal += GetVPowerLiterOverUnder(dt.Date, TotalBenzinSalg);
                    }
                    return VPowerLiterOverUnderTotal;
                }
                #endregion

                #region GetVPowerPctBudget
                /// <summary>
                /// Finder % andelen af V-Power budgettet i forhold til benzin budgettet
                /// for den angivne måned.
                /// </summary>
                public double GetVPowerPctBudget(DateTime EndDate)
                {
                    double VPowerBudget = EODDataSet.GLBudgetDataTable.GetVPowerBudget(EndDate.Year, EndDate.Month);
                    List<string> tmp = GetGLCodesForColumn(ColumnNumbers.TotalBenzin);
                    double BenzinBudget = EODDataSet.GLBudgetDataTable.GetBudget(
                        EndDate.Year, EndDate.Month, tmp, EODDataSet.GLBudgetDataTable.BudgetUnit.Volume);
                    return ((VPowerBudget / BenzinBudget) * 100);
                }
                #endregion

                #region GetColumnBudgetPerDay
                /// <summary>
                /// Henter kolonnens budget pr. dag, dvs. hvad budgettet
                /// er når man kigger i GLBudget tabellen for en
                /// måned og udregner hvad én dags budget er.
                /// </summary>
                public double GetColumnBudgetPerDay(ColumnNumbers ColumnNo, DateTime EndDate)
                {
                    EndDate = EndDate.Date;

                    // UnitOrAmount enum værdierne skal mappes til GLBudgetData.BudgetUnit værdierne
                    EODDataSet.GLBudgetDataTable.BudgetUnit BudgetUnit =
                        EODDataSet.GLBudgetDataTable.BudgetUnit.Amount;
                    if (GetColumnUnitOrAmount(ColumnNo) == UnitOrAmount.Unit)
                        BudgetUnit = EODDataSet.GLBudgetDataTable.BudgetUnit.Volume;

                    // hent budgettet for den angivne kolonne for den angivne måned
                    double Budget = EODDataSet.GLBudgetDataTable.GetBudget(
                        EndDate.Year,
                        EndDate.Month,
                        GetGLCodesForColumn(ColumnNo),
                        BudgetUnit);

                    // returnér budgettet pr. dag
                    return (Budget / DateTime.DaysInMonth(EndDate.Year, EndDate.Month));
                }
                #endregion

                #region GetGLCodesForColumn
                /// <summary>
                /// Ud fra tabellen SalesStatDailyColumns bygges en liste
                /// af konti (GLCode værdier), der er bundet op på den angivne kolonne.
                /// </summary>
                private List<string> GetGLCodesForColumn(ColumnNumbers ColumnNo)
                {
                    // hent fra/til konti, der er valg til den angivne kolonne.
                    DataTable table = db.GetDataTable(string.Format(@"
                        select accounts.AccountFrom,accounts.AccountTo
                        from SalesStatDailyAccounts accounts
                        inner join SalesStatDailyColumns columns
                        on (accounts.ColumnID = columns.ID)
                        where (columns.ColumnNo = {0})
                        ", (int)ColumnNo));

                    // byg en liste mellem fra/til konti, begge inklusive, for alle sæt fundet
                    List<string> list = new List<string>();
                    foreach (DataRow row in table.Rows)
                    {
                        int fra = tools.object2int(row["AccountFrom"]);
                        int til = tools.object2int(row["AccountTo"]);
                        for (int i = fra; i <= til; i++)
                            list.Add(i.ToString());
                    }
                    return list;
                }
                #endregion

                #region LoadColumnData
                private DataTable LoadColumnData(
                    ColumnNumbers ColumnNo,
                    DateTime StartDate,
                    DateTime EndDate)
                {
                    return db.GetDataTable(string.Format(@"
select
  sales.BookDate,

  Case T2.UnitOrAmount
		   When 1 Then Sum(sales.NumberOf)  
		   Else
		   Sum(sales.Amount/ ((vat.TaxPct + 100) / 100)) 		 
		 End
		 as UnitOrAmount 
from (((SalesStatDailyAccounts accounts
left join SalesStatDailyColumns AS T2
  on accounts.ColumnID = T2.ID)
left join SubCategory subcat
  on subcat.GLCode >= accounts.AccountFrom
  and subcat.GLCode <= accounts.AccountTo)
left join EOD_Sales sales
  on subcat.SubCategoryID = sales.SubCategory)
left join LookupTaxID vat
  on subcat.VatRate = vat.TaxID
where (subcat.GLCode IS NOT NULL)
and (sales.BookDate >= '{0}')
and (sales.BookDate <= '{1}')
and (T2.ColumnNo = {2})
group by
  sales.BookDate,T2.UnitOrAmount 

order by
  sales.BookDate,T2.UnitOrAmount ", StartDate.Date,
                       EndDate.Date,
                       (int)ColumnNo,
                       tools.DeductVATsqlString("sales.Amount", "vat.TaxPct")));
                }

                #endregion

                #region LoadColumnsMetaData

                private DataTable LoadColumnsMetaData()
                {
                    return db.GetDataTable(string.Format(@"

select distinct
  columns.ID,
  columns.ColumnNo,
  columns.HeaderText,
  columns.Average,
  columns.SystemColumn,
  units.Description as UnitOrAmountDesc,
  columns.UnitOrAmount
from (SalesStatDailyAccounts accounts
left join SalesStatDailyColumns columns
  on accounts.ColumnID = columns.ID)
left join LookupUnitOrAmount units
  on columns.UnitOrAmount = units.ID
where (columns.ColumnNo  IS NOT NULL) and (columns.ColumnNo <> 0)
order by columns.ColumnNo

"));
                }

                #endregion

                #region LoadCustomerCounts
                private Dictionary<DateTime, int> LoadCustomerCounts(DateTime FirstDateInMonth, DateTime EndDate)
                {
                    DataTable table = db.GetDataTable(string.Format(@"
                        select BookDate, CustomerCount
                        from EODReconcileEx
                        where (BookDate >= '{0}')
                        and (BookDate <= '{1}')
                        order by BookDate
                        ", FirstDateInMonth.Date, EndDate.Date));
                    Dictionary<DateTime, int> result = new Dictionary<DateTime, int>();
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(
                            tools.object2datetime(row["BookDate"]),
                            tools.object2int(row["CustomerCount"]));
                    }
                    return result;
                }
                #endregion
            }
            #endregion

            public void EmptyTableOnDisk()
            {
                db.ExecuteNonQuery("delete from SalesStatRpt");
            }

            #region FillWithCollectedData
            /// <summary>
            /// Fills the provided table with data collected from various sources.
            /// This is here where we find out what columns the user has selected
            /// for the report and builds a table with data for print.
            /// </summary>
            public void FillWithCollectedData(
                RBOS.SalesStatDS.SalesStatRptDataTable Table,
                Dictionary<string, string> ColumnHeaders,
                Dictionary<string, string> ColumnUnitOrAmount,
                DateTime EndDate)
            {
                if (ClearBeforeFill)
                    Table.Clear();


                // get the first and last date in the month
                EndDate = EndDate.Date;
                DateTime FirstDateInMonth = tools.GetFirstDateInMonth(EndDate);
                DateTime LastDateInMonth = tools.GetLastDateInMonth(EndDate);

                CollectedData data = new CollectedData(FirstDateInMonth, EndDate);
                int SortOrder = 0;

                // add data for printsection DATA
                // loop all days in the entire month
                int counter = 0;
                for (DateTime dt = FirstDateInMonth.Date; dt <= LastDateInMonth.Date; dt = dt.AddDays(1).Date)
                {
                    SalesStatDS.SalesStatRptRow row = Table.NewSalesStatRptRow();

                    counter++;
                    row.PrintSection = "1-DATA";
                    row.RowText = dt.ToString("d, ddd");
                    row.BookDate = dt;

                    if (dt.Date <= EndDate.Date)
                    {
                        // if the date being processed is within the range
                        // we have data, we want to fill in the columns
                        row.TotalShop = data.GetFieldData(ColumnNumbers.TotalShop, dt);
                        row.TotalBenzin = data.GetFieldData(ColumnNumbers.TotalBenzin, dt);
                        row.TotalDiesel = data.GetFieldData(ColumnNumbers.TotalDiesel, dt);
                        row.Custom1 = data.GetFieldData(ColumnNumbers.Custom1, dt);
                        row.Custom2 = data.GetFieldData(ColumnNumbers.Custom2, dt);
                        row.Custom3 = data.GetFieldData(ColumnNumbers.Custom3, dt);
                        row.AntalKunder = data.GetCustomerCount(dt);
                        row.GnsSalgKolPrKunde = data.GetAvgColumnSales(dt, row.AntalKunder);
#if !DETAIL
                        row.VPowerPct = Math.Round(data.GetVPowerPct(dt, row.TotalBenzin), 1);
                        row.VPowerLiter = data.GetVPowerLiterOverUnder(dt, row.TotalBenzin);
#endif
                    }

                    // add the created row to the table
                    row.SortOrder = ++SortOrder;
                    Table.AddSalesStatRptRow(row);
                }

                // add data for printsection TOTALER Måned
                SalesStatDS.SalesStatRptRow rowTotalsMonth = Table.NewSalesStatRptRow();
                rowTotalsMonth.PrintSection = "2-TOTALER";
                rowTotalsMonth.RowText = "Måned";
                rowTotalsMonth.TotalShop = data.GetColumnTotal(ColumnNumbers.TotalShop);
                rowTotalsMonth.TotalBenzin = data.GetColumnTotal(ColumnNumbers.TotalBenzin);
                rowTotalsMonth.TotalDiesel = data.GetColumnTotal(ColumnNumbers.TotalDiesel);
                rowTotalsMonth.Custom1 = data.GetColumnTotal(ColumnNumbers.Custom1);
                rowTotalsMonth.Custom2 = data.GetColumnTotal(ColumnNumbers.Custom2);
                rowTotalsMonth.Custom3 = data.GetColumnTotal(ColumnNumbers.Custom3);
                rowTotalsMonth.AntalKunder = data.GetTotalCustomerCount();
#if !DETAIL                
                rowTotalsMonth.VPowerPct = Math.Round(data.GetVPowerPctTotal(FirstDateInMonth, EndDate), 1);
                rowTotalsMonth.VPowerLiter = data.GetVPowerLiterOverUnderTotal(FirstDateInMonth, EndDate);
#endif
                rowTotalsMonth.SortOrder = ++SortOrder;
                Table.AddSalesStatRptRow(rowTotalsMonth);

                // add data for printsection TOTALER Gns. pr. dag
                SalesStatDS.SalesStatRptRow rowTotalsAvg = Table.NewSalesStatRptRow();
                rowTotalsAvg.PrintSection = "2-TOTALER";
                rowTotalsAvg.RowText = "Gns./dag";
                rowTotalsAvg.TotalShop = rowTotalsMonth.TotalShop / EndDate.Day;
                rowTotalsAvg.TotalBenzin = rowTotalsMonth.TotalBenzin / EndDate.Day;
                rowTotalsAvg.TotalDiesel = rowTotalsMonth.TotalDiesel / EndDate.Day;
                rowTotalsAvg.Custom1 = rowTotalsMonth.Custom1 / EndDate.Day;
                rowTotalsAvg.Custom2 = rowTotalsMonth.Custom2 / EndDate.Day;
                rowTotalsAvg.Custom3 = rowTotalsMonth.Custom3 / EndDate.Day;
                rowTotalsAvg.AntalKunder = rowTotalsMonth.AntalKunder / EndDate.Day;
                rowTotalsAvg.GnsSalgKolPrKunde = (rowTotalsAvg.AntalKunder != 0 ?
                    (data.GetColumnTotal(data.GetAvgColumnNo()) / EndDate.Day / rowTotalsAvg.AntalKunder) : 0);
                rowTotalsAvg.SortOrder = ++SortOrder;
                Table.AddSalesStatRptRow(rowTotalsAvg);

                // add data for printsection SALGSMAAL Pr. dag
                // (pr. dag udregnes før måned, da måned blot er pr. dag ganget op med dage)
                SalesStatDS.SalesStatRptRow rowSalgsmaalPrDag = Table.NewSalesStatRptRow();
                rowSalgsmaalPrDag.PrintSection = "3-SALGSMAAL";
                rowSalgsmaalPrDag.RowText = "Pr. dag";
                rowSalgsmaalPrDag.TotalShop = data.GetColumnBudgetPerDay(ColumnNumbers.TotalShop, EndDate);
                rowSalgsmaalPrDag.TotalBenzin = data.GetColumnBudgetPerDay(ColumnNumbers.TotalBenzin, EndDate);
                rowSalgsmaalPrDag.TotalDiesel = data.GetColumnBudgetPerDay(ColumnNumbers.TotalDiesel, EndDate);
                rowSalgsmaalPrDag.Custom1 = data.GetColumnBudgetPerDay(ColumnNumbers.Custom1, EndDate);
                rowSalgsmaalPrDag.Custom2 = data.GetColumnBudgetPerDay(ColumnNumbers.Custom2, EndDate);
                rowSalgsmaalPrDag.Custom3 = data.GetColumnBudgetPerDay(ColumnNumbers.Custom3, EndDate);
                rowSalgsmaalPrDag.SortOrder = (SortOrder += 2);
                Table.AddSalesStatRptRow(rowSalgsmaalPrDag);

                // add data for printsection SALGSMAAL MÅned (baseret på Pr. dag)
                SalesStatDS.SalesStatRptRow rowSalgsmaalMaaned = Table.NewSalesStatRptRow();
                rowSalgsmaalMaaned.PrintSection = "3-SALGSMAAL";
                rowSalgsmaalMaaned.RowText = "Måned";
                rowSalgsmaalMaaned.TotalShop = rowSalgsmaalPrDag.TotalShop * EndDate.Day;
                rowSalgsmaalMaaned.TotalBenzin = rowSalgsmaalPrDag.TotalBenzin * EndDate.Day;
                rowSalgsmaalMaaned.TotalDiesel = rowSalgsmaalPrDag.TotalDiesel * EndDate.Day;
                rowSalgsmaalMaaned.Custom1 = rowSalgsmaalPrDag.Custom1 * EndDate.Day;
                rowSalgsmaalMaaned.Custom2 = rowSalgsmaalPrDag.Custom2 * EndDate.Day;
                rowSalgsmaalMaaned.Custom3 = rowSalgsmaalPrDag.Custom3 * EndDate.Day;
#if !DETAIL                
                rowSalgsmaalMaaned.VPowerPct = Math.Round(data.GetVPowerPctBudget(EndDate), 1);
#endif
                rowSalgsmaalMaaned.SortOrder = --SortOrder;
                Table.AddSalesStatRptRow(rowSalgsmaalMaaned);
                ++SortOrder;

                // add data for printsection FORSKEL måned
                SalesStatDS.SalesStatRptRow rowForskelMaaned = Table.NewSalesStatRptRow();
                rowForskelMaaned.PrintSection = "4-FORSKEL";
                rowForskelMaaned.RowText = "Måned";
                rowForskelMaaned.TotalShop = rowTotalsMonth.TotalShop - rowSalgsmaalMaaned.TotalShop;
                rowForskelMaaned.TotalBenzin = rowTotalsMonth.TotalBenzin - rowSalgsmaalMaaned.TotalBenzin;
                rowForskelMaaned.TotalDiesel = rowTotalsMonth.TotalDiesel - rowSalgsmaalMaaned.TotalDiesel;
                rowForskelMaaned.Custom1 = rowTotalsMonth.Custom1 - rowSalgsmaalMaaned.Custom1;
                rowForskelMaaned.Custom2 = rowTotalsMonth.Custom2 - rowSalgsmaalMaaned.Custom2;
                rowForskelMaaned.Custom3 = rowTotalsMonth.Custom3 - rowSalgsmaalMaaned.Custom3;
#if !DETAIL                
                rowForskelMaaned.VPowerPct = Math.Round(rowTotalsMonth.VPowerPct - rowSalgsmaalMaaned.VPowerPct, 1);
#endif
                rowForskelMaaned.SortOrder = ++SortOrder;
                Table.AddSalesStatRptRow(rowForskelMaaned);

                // add data for printsection FORSKEL pr. dag
                SalesStatDS.SalesStatRptRow rowForskelPrDag = Table.NewSalesStatRptRow();
                rowForskelPrDag.PrintSection = "4-FORSKEL";
                rowForskelPrDag.RowText = "Pr. dag";
                rowForskelPrDag.TotalShop = rowTotalsAvg.TotalShop - rowSalgsmaalPrDag.TotalShop;
                rowForskelPrDag.TotalBenzin = rowTotalsAvg.TotalBenzin - rowSalgsmaalPrDag.TotalBenzin;
                rowForskelPrDag.TotalDiesel = rowTotalsAvg.TotalDiesel - rowSalgsmaalPrDag.TotalDiesel;
                rowForskelPrDag.Custom1 = rowTotalsAvg.Custom1 - rowSalgsmaalPrDag.Custom1;
                rowForskelPrDag.Custom2 = rowTotalsAvg.Custom2 - rowSalgsmaalPrDag.Custom2;
                rowForskelPrDag.Custom3 = rowTotalsAvg.Custom3 - rowSalgsmaalPrDag.Custom3;
                rowForskelPrDag.SortOrder = ++SortOrder;
                Table.AddSalesStatRptRow(rowForskelPrDag);

                // get the dynamic column headers
                // note that "-" are replaced with " " in the 6 columns
                // and in the average column it is replaced with ""
                ColumnHeaders["TotalShop"] = data.GetColumnHeaderText(ColumnNumbers.TotalShop);
                ColumnHeaders["TotalBenzin"] = data.GetColumnHeaderText(ColumnNumbers.TotalBenzin);
                ColumnHeaders["TotalDiesel"] = data.GetColumnHeaderText(ColumnNumbers.TotalDiesel);
                ColumnHeaders["Custom1"] = data.GetColumnHeaderText(ColumnNumbers.Custom1);
                ColumnHeaders["Custom2"] = data.GetColumnHeaderText(ColumnNumbers.Custom2);
                ColumnHeaders["Custom3"] = data.GetColumnHeaderText(ColumnNumbers.Custom3);
                ColumnHeaders["GnsSalgKolPrKunde"] = data.GetColumnHeaderText(data.GetAvgColumnNo());

                // get the dynamic column unit or amount
                ColumnUnitOrAmount["Dato"] = "";
                ColumnUnitOrAmount["TotalShop"] = data.GetColumnUnitOrAmountDesc(ColumnNumbers.TotalShop);
                ColumnUnitOrAmount["TotalBenzin"] = data.GetColumnUnitOrAmountDesc(ColumnNumbers.TotalBenzin);
                ColumnUnitOrAmount["TotalDiesel"] = data.GetColumnUnitOrAmountDesc(ColumnNumbers.TotalDiesel);
                ColumnUnitOrAmount["Custom1"] = data.GetColumnUnitOrAmountDesc(ColumnNumbers.Custom1);
                ColumnUnitOrAmount["Custom2"] = data.GetColumnUnitOrAmountDesc(ColumnNumbers.Custom2);
                ColumnUnitOrAmount["Custom3"] = data.GetColumnUnitOrAmountDesc(ColumnNumbers.Custom3);
                ColumnUnitOrAmount["AntalKunder"] = "ANTAL";
                ColumnUnitOrAmount["GnsSalgKolPrKunde"] = data.GetColumnUnitOrAmountDesc(data.GetAvgColumnNo());
                ColumnUnitOrAmount["VPowerPct"] = "Andel %";
                ColumnUnitOrAmount["VPowerOU"] = "+/- Liter";
            }
            #endregion
        }
    }

    partial class SalesStatDS
    {
        partial class SalesStatRptDataTable
        {
        }

        partial class SalesStatDailyAccountsDataTable
        {
            #region Event for OnColumnChanged errors, to communicate to the GUI

            public delegate void FieldChangedError(string ErrorMessage);
            /// <summary>
            /// Event is fired whenever an error occurs when setting a field.
            /// This could for instance be a validation error. Usually the GUI
            /// just needs to respond to this event by displaying the ErrorMessage
            /// to the user.
            /// </summary>
            public event FieldChangedError OnFieldChangedError
                = new FieldChangedError(OnFieldChangedErrorDummy);
            private static void OnFieldChangedErrorDummy(string ErrorMessage) { }

            #endregion

            #region OnColumnChanging
            /// <summary>
            /// Used for avoiding the OnColumnChanging event is
            /// called subsequently when setting fields inside the event.
            /// </summary>
            private bool _ChangingColumnInProgress = false;
            /// <summary>
            /// Custom code written to handle stuff whenever updating a field.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                if (!_ChangingColumnInProgress)
                {
                    _ChangingColumnInProgress = true;

                    if (!tools.IsNullOrDBNull(e.ProposedValue))
                    {
                        if (e.Column == AccountFromColumn)
                        {
                            string ProposedAccountFrom = tools.object2string(e.ProposedValue);
                            string dbAccountTo = tools.object2string(e.Row[AccountToColumn]);

                            // check if proposed accountfrom is higher than accountto
                            if ((dbAccountTo != "") && (ProposedAccountFrom.CompareTo(dbAccountTo) > 0))
                            {
                                OnFieldChangedError(db.GetLangString("SalesStatDailyAccountsTable.StartAccoutTooHigh"));
                                e.ProposedValue = e.Row[AccountFromColumn]; // keep the old value
                                _ChangingColumnInProgress = false;
                                return;
                            }

                            // check if proposed accountfrom has already been used
                            if (DoesAccountIntervalOverlapAnother(ProposedAccountFrom, dbAccountTo, e.Row))
                            {
                                OnFieldChangedError(db.GetLangString("SalesStatDailyAccountsTable.AccountAlreadyUsed"));
                                e.ProposedValue = e.Row[AccountFromColumn]; // keep the old value
                                _ChangingColumnInProgress = false;
                                return;
                            }

                            // if setting accountfrom and accountto is null,
                            // set accountto to the same value as accountfrom is set to
                            if (dbAccountTo == "")
                            {
                                e.Row[AccountToColumn] = dbAccountTo = ProposedAccountFrom;
                            }
                        }
                        else if (e.Column == AccountToColumn)
                        {
                            string ProposedAccountTo = tools.object2string(e.ProposedValue);
                            string dbAccountFrom = tools.object2string(e.Row[AccountFromColumn]);

                            // check if proposed accountto is lower than accountfrom
                            if ((dbAccountFrom != "") && (ProposedAccountTo.CompareTo(dbAccountFrom) < 0))
                            {
                                OnFieldChangedError(db.GetLangString("SalesStatDailyAccountsTable.EndAccountTooLow"));
                                e.ProposedValue = e.Row[AccountToColumn]; // keep the old value
                                _ChangingColumnInProgress = false;
                                return;
                            }

                            // check if proposed accountto has already been used
                            if (DoesAccountIntervalOverlapAnother(dbAccountFrom, ProposedAccountTo, e.Row))
                            {
                                OnFieldChangedError(db.GetLangString("SalesStatDailyAccountsTable.AccountAlreadyUsed"));
                                e.ProposedValue = e.Row[AccountToColumn]; // keep the old value
                                _ChangingColumnInProgress = false;
                                return;
                            }

                            // if setting accountto and accountfrom is null,
                            // set accountfrom to the same value as accountto is set to
                            if (dbAccountFrom == "")
                            {
                                e.Row[AccountFromColumn] = dbAccountFrom = ProposedAccountTo;
                            }
                        }
                    }

                    _ChangingColumnInProgress = false;
                    base.OnColumnChanging(e);
                }
            }
            #endregion

            #region IsAccountAlreadyUsed
            /// <summary>
            /// Checks the currently loaded table of data
            /// to see if the provided Account has already been used.
            /// The row RowAttemptingToUpdate passed in is not checked.
            /// </summary>
            private bool DoesAccountIntervalOverlapAnother(
                string AccountFrom,
                string AccountTo,
                DataRow RowAttemptingToUpdate)
            {
                bool result = false;

                // for this test, none of the account may be "",
                if ((AccountFrom == "") && (AccountTo == ""))
                    return false;
                else if (AccountFrom == "")
                    AccountFrom = AccountTo;
                else if (AccountTo == "")
                    AccountTo = AccountFrom;

                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached) &&
                        (row != RowAttemptingToUpdate))
                    {
                        /// we check to see if the new interval does
                        /// not fall outside the interval in a record
                        string rowAccountFrom = tools.object2string(row[AccountFromColumn]);
                        string rowAccountTo = tools.object2string(row[AccountToColumn]);
                        if (!(((AccountFrom.CompareTo(rowAccountFrom) < 0) &&
                              (AccountTo.CompareTo(rowAccountFrom) < 0)) ||
                             ((AccountFrom.CompareTo(rowAccountTo) > 0) &&
                              (AccountTo.CompareTo(rowAccountTo) > 0))))
                        {
                            result = true;
                        }
                    }
                }

                return result;
            }
            #endregion
        }

        partial class SalesStatDailyColumnsDataTable
        {
            private string _LastMsg = "";
            public string LastMsg
            {
                get { return _LastMsg; }
            }

            private int GetNextID()
            {
                int ID = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached) &&
                        (tools.object2int(row[IDColumn]) > ID))
                    {
                        ID = tools.object2int(row[IDColumn]);
                    }
                }
                return ID + 1;
            }

            protected override void OnColumnChanged(System.Data.DataColumnChangeEventArgs e)
            {
                // setup a new record the first time a value is added to it
                if ((e.Column != IDColumn) && tools.IsNullOrDBNull(e.Row[IDColumn]))
                {
                    //@@@TODO  - virker ikke endnu
                    e.Row[IDColumn] = GetNextID();
                    //e.Row[SystemColumnColumn] = false;
                    //if (e.Column != ColumnNoColumn)
                    //e.Row[ColumnNoColumn] = 0;
                    //if (e.Column != AverageColumn)
                    //  e.Row[AverageColumn] = false;
                }

                if (!tools.IsNullOrDBNull(e.ProposedValue))
                {
                    if (e.Column == ColumnNoColumn)
                    {
                        // when selecting a value for the ColumnNo field,
                        // we need to check if any other record holds this value,
                        // and if so, clear the field in that other record.
                        foreach (DataRow row in Rows)
                        {
                            if ((row.RowState != DataRowState.Deleted) &&
                                (row.RowState != DataRowState.Detached) &&
                                (row != e.Row) &&
                                (tools.object2int(row[ColumnNoColumn]) == tools.object2int(e.ProposedValue)))
                            {
                                row[ColumnNoColumn] = DBNull.Value;

                                // also clear any Average flag
                                if (tools.object2bool(row[AverageColumn]))
                                    row[AverageColumn] = DBNull.Value;
                            }
                        }
                    }
                    else if ((e.Column == AverageColumn) && (tools.object2bool(e.ProposedValue) == true))
                    {
                        // when selecting a value for the Average field
                        // null all other fields, if they have Average set to true
                        foreach (DataRow row in Rows)
                        {
                            if ((row.RowState != DataRowState.Deleted) &&
                                (row.RowState != DataRowState.Detached) &&
                                (row != e.Row) && (tools.object2bool(row[AverageColumn])))
                            {
                                row[AverageColumn] = DBNull.Value;
                            }
                        }
                    }
                }

                base.OnColumnChanged(e);
            }

            /// <summary>
            /// Checks if the record has a ColumnNo value assigned.
            /// </summary>
            public bool RecordCanBeSetAverage(DataRow Row)
            {
                if (Row == null) return false;
                return (tools.object2int(Row[ColumnNoColumn]) > 0);
            }

            public bool IsSystemRecord(DataRow Row)
            {
                return tools.object2bool(Row[SystemColumnColumn]);
            }

            /// <summary>
            /// Verifies that certain needed values
            /// has been written to the table. If not,
            /// the method returns false and LastMsg contains
            /// a user friendly string. Remember to call
            /// grid.EndEdit and binding.EndEdit before calling
            /// this method, to make sure all values entered
            /// are checked.
            /// </summary>
            public bool VerifyNeededValues()
            {
                bool okAverage = false;
                int ok6Columns = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        // check if an average column has been selected
                        if (tools.object2bool(row["Average"]))
                            okAverage = true;

                        // check that all 6 columns has been selected
                        if (tools.object2int(row["ColumnNo"]) >= 1)
                            ++ok6Columns;
                    }
                }

                if (!okAverage)
                {
                    _LastMsg = "[Du skal vælge en gennemsnitskolonne]";
                    return false;
                }
                else if (ok6Columns != 6)
                {
                    _LastMsg = "[Der skal vælges ialt 6 kolonner til rapporten]";
                    return false;
                }

                return true;
            }
        }
    }
}
