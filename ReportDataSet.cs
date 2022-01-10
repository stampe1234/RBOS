using System.Data.OleDb;
using System.Data;

namespace RBOS.ReportDataSetTableAdapters
{
    partial class OrderHeaderTableAdapter
    {
    }
    /// <summary>
    /// Custom code on SalesMarginTableAdapter.
    /// We want to extract and manipulate the SQL not available by default.
    /// The query for the SalesMarginDataAdapter will contain a
    /// WHERE (1 = 1) inside the sql, and then the report form should replace
    /// this with where clauses
    /// </summary>
    public partial class SalesMarginTableAdapter : System.ComponentModel.Component
    {
        private string origSelectCommand = "";

        public void SetSelectCommand(string sql)
        {
            if (origSelectCommand == "")
                InitCommandCollection();
            this._commandCollection[0].CommandText = sql;
        }

        public string GetOriginalSelectCommand()
        {
            if (origSelectCommand == "")
            {
                InitCommandCollection();
                origSelectCommand = this._commandCollection[0].CommandText;
            }
            return origSelectCommand;
        }
    }

    /// <summary>
    /// Custom code on ItemBasicDataTableAdapter.
    /// We want to extract and manipulate the SQL not available by default.
    /// The query for the ItemBasicDataTableAdapter will contain a
    /// WHERE (1 = 1) at the end, and then the report form should add
    /// filter clauses to the query like ( AND blalba.yadiyadi = 1 )
    /// </summary>
    public partial class ItemBasicDataTableAdapter : System.ComponentModel.Component
    {
        private string origSelectCommand = "";

        public void SetSelectCommand(string sql)
        {
            if (origSelectCommand == "")
                InitCommandCollection();
            this._commandCollection[0].CommandText = sql;
        }

        public string GetOriginalSelectCommand()
        {
            if (origSelectCommand == "")
            {
                InitCommandCollection();
                origSelectCommand = this._commandCollection[0].CommandText;
            }
            return origSelectCommand;
        }
    }

    /// <summary>
    /// Custom code on SalesPackTableAdapter
    /// We want to extract and manipulate the SQL not available by default.
    /// The query for the ItemBasicDataTableAdapter will contain a
    /// WHERE (1 = 1) at the end, and then the report form should add
    /// filter clauses to the query like ( AND blalba.yadiyadi = 1 )
    /// </summary>
    public partial class SalesPackTableAdapter : System.ComponentModel.Component
    {
        private string origSelectCommand = "";

        public void SetSelectCommand(string sql)
        {
            if (origSelectCommand == "")
                InitCommandCollection();
            this._commandCollection[0].CommandText = sql;
        }

        public string GetOriginalSelectCommand()
        {
            if (origSelectCommand == "")
            {
                InitCommandCollection();
                origSelectCommand = this._commandCollection[0].CommandText;
            }
            return origSelectCommand;
        }
    }

    /// <summary>
    /// Custom code on ItemTransactionsTableAdapter.
    /// We want to extract and manipulate the SQL not available by default.
    /// The query for the ItemTransactionsTableAdapter will contain a
    /// WHERE (1 = 1) in the end, and then the report form should add
    /// filter clauses to the query like ( WHERE (blalba.yadiyadi = 1) )
    /// </summary>
    public partial class ItemTransactionsTableAdapter : System.ComponentModel.Component
    {
        private string origSelectCommand = "";

        public void SetSelectCommand(string sql)
        {
            if (origSelectCommand == "")
                InitCommandCollection();
            this._commandCollection[0].CommandText = sql;
        }

        public string GetOriginalSelectCommand()
        {
            if (origSelectCommand == "")
            {
                InitCommandCollection();
                origSelectCommand = this._commandCollection[0].CommandText;
            }
            return origSelectCommand;
        }
    }

    /// <summary>
    /// Custom code on ItemSalesSumTableAdapter.
    /// We want to extract and manipulate the SQL not available by default.
    /// The query for the ItemSalesSumTableAdapter will contain a
    /// WHERE (1 = 1) in the end, and then the report form should add
    /// filter clauses to the query like ( WHERE (blalba.yadiyadi = 1) )
    /// </summary>
    public partial class ItemSalesSumTableAdapter : System.ComponentModel.Component
    {
        private string origSelectCommand = "";

        public void SetSelectCommand(string sql)
        {
            if (origSelectCommand == "")
                InitCommandCollection();
            this._commandCollection[0].CommandText = sql;
        }

        public string GetOriginalSelectCommand()
        {
            if (origSelectCommand == "")
            {
                InitCommandCollection();
                origSelectCommand = this._commandCollection[0].CommandText;
            }
            return origSelectCommand;
        }
    }
}

namespace RBOS
{


    partial class ReportDataSet
    {
        partial class SalesReportDataTable
        {
        }

        partial class ItemUpdLinesDataTable
        {
        }

        partial class SalesMarginDataTable
        {
        }

        partial class ItemTransactionRBADataTable
        {
        }

        partial class OnHandReportDataTable
        {
        }

        partial class ItemSalesSumDataTable
        {
            /// <summary>
            /// Calculates the total NumberOf sum
            /// for the loaded ItemSalesSum table data
            /// </summary>
            public int CalculateNumberOfTotal()
            {
                int total = 0;
                foreach (DataRow row in Rows)
                    total += tools.object2int(row["NumberOfSum"]);
                return total;
            }

            /// <summary>
            /// Calculates the total Amoun1 sum
            /// for the loaded ItemSalesSum table data
            /// </summary>
            public double CalculateAmountTotal()
            {
                double total = 0;
                foreach (DataRow row in Rows)
                    total += tools.object2double(row["AmountSum"]);
                return total;
            }

            /// <summary>
            /// Calculates the AmountPct field for each
            /// row in the loaded ItemSalesSum table data.
            /// This value is how many the field AmountSum
            /// is of the provided AmountTotal.
            /// </summary>
            /// <param name="AmountTotal">The total of AmountSum for the loaded data.</param>
            public void CalculateAmountPercentages(double AmountTotal)
            {
                foreach (DataRow row in Rows)
                {
                    double amount = tools.object2double(row["AmountSum"]);
                    row["AmountPct"] = 0;
                    if (AmountTotal != 0)
                        row["AmountPct"] = (amount / AmountTotal) * 100;
                }
            }

            /// <summary>
            /// Calculates accumulated values for fields AccumulatedAmountSum
            /// and AccumulatedAmountPct down through each row in the provided table.
            /// Must be called after CalculateAmountPercentages on that table,
            /// as that method fills in the needed field AmountPct.
            /// </summary>
            /// <param name="Table">
            /// A table that is ready for printing. That is,
            /// do not reverse the order of the rows on the table,
            /// as the accumulated values won't make sense after that.
            /// Also make sure that CalculateAmountPercentages has been
            /// called on that table first.
            /// </param>
            /// <returns>
            /// The provided dataset with accumulated
            /// AccumulatedAmountSum and AccumulatedAmountPct. on all rows
            /// </returns>
            public ItemSalesSumDataTable CalculateAccumulatedAmountsAndPercentages(ItemSalesSumDataTable Table)
            {
                double prevAccAmountSum = 0;
                double prevAccAmountPct = 0;
                foreach (DataRow row in Table.Rows)
                {
                    double newAccAmountPct = prevAccAmountPct + tools.object2double(row["AmountPct"]);
                    double newAccAmountSum = prevAccAmountSum + tools.object2double(row["AmountSum"]);
                    row["AccumulatedAmountPct"] = newAccAmountPct;
                    row["AccumulatedAmountSum"] = newAccAmountSum;
                    prevAccAmountPct = newAccAmountPct;
                    prevAccAmountSum = newAccAmountSum;
                }
                return Table;
            }

            /// <summary>
            /// Returns the top number of records.
            /// </summary>
            public ItemSalesSumDataTable GetTop(uint Amount)
            {
                ItemSalesSumDataTable table = new ItemSalesSumDataTable();
                for (int i = 0; (i < Amount) && (i < Rows.Count); i++)
                {
                    DataRow newRow = table.NewRow();
                    newRow["ItemName"] = Rows[i]["ItemName"];
                    newRow["AmountSum"] = Rows[i]["AmountSum"];
                    newRow["NumberOfSum"] = Rows[i]["NumberOfSum"];
                    newRow["AmountPct"] = Rows[i]["AmountPct"];
                    table.Rows.Add(newRow);
                }
                return table;
            }

            /// <summary>
            /// Returns the bottom number of records,
            /// reversed from bottom and up so the worst
            /// are at the top.
            /// </summary>
            public ItemSalesSumDataTable GetBottom(uint Amount)
            {
                ItemSalesSumDataTable table = new ItemSalesSumDataTable();
                for (int i = Rows.Count - 1; (i > (Rows.Count - 1 - Amount)) && (i >= 0); i--)
                {
                    DataRow newRow = table.NewRow();
                    newRow["ItemName"] = Rows[i]["ItemName"];
                    newRow["AmountSum"] = Rows[i]["AmountSum"];
                    newRow["NumberOfSum"] = Rows[i]["NumberOfSum"];
                    newRow["AmountPct"] = Rows[i]["AmountPct"];
                    table.Rows.Add(newRow);
                }
                return table;
            }
        }
    }
}
