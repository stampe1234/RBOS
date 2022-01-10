using System.Data;
using System.Data.OleDb;
using System;
using System.Collections.Generic;

namespace RBOS
{


    public partial class DanskeSpilDataSet
    {




        partial class Danske_SpilDataTable
        {
            public static bool Delete(DateTime BookDate)
            {
                db.ExecuteNonQuery(string.Format(@"delete from Danske_Spil where BookDate = '{0}'
                        ", BookDate.Date));
                return true;
            }
            public static void CreateNewRecord(DateTime BookDate, double OnlineSalgTerminal, double OnlineGevinst, double QuickClearetTerminal)
            {
                BookDate = BookDate.Date;

                db.ExecuteNonQuery(string.Format(@"
                    insert into Danske_Spil
                    (BookDate,OnlineSalesTerminal,OnlinePayoutTerminal,QuickTerminal)
                    values ({0},{1},{2},{3})
                    ",
                     tools.datetime4sql(BookDate),
                     tools.decimalnumber4sql(OnlineSalgTerminal),
                     tools.decimalnumber4sql(OnlineGevinst),
                     tools.decimalnumber4sql(QuickClearetTerminal)));
            }
            public static DateTime GetMaxDanskeSpilDate()
            {
                return tools.object2datetime(db.ExecuteScalar(@"
                    select max(BookDate)
                    from Danske_Spil
                    "));
            }
            public static DateTime GetDanskeSpilMinDate()
            {
                return tools.object2datetime(db.ExecuteScalar(@"
                    select min(BookDate)
                    from Danske_Spil
                    "));
            }
            public static bool UpdateDanskeSpil(DateTime FromDate, DateTime ToDate)
            {

                for (DateTime loopDate = FromDate.Date; loopDate.Date <= ToDate.Date; loopDate = loopDate.AddDays(1).Date)
                {
                    //OnlineSalg kasse
                    double EODAmount = tools.object2double(db.ExecuteScalar(string.Format(
                    "  (select Sum(Amount) From EOD_Sales " +
                    " where (BookDate = '{0}' " +
                    " And SubCategory = '201110201')) "
                    , loopDate)));

                    db.ExecuteNonQuery(string.Format(
                   " update Danske_Spil " +
                   " set OnlineSalesDesk = '{0}' " +
                   " where BookDate = '{1}' ",
                   tools.decimalnumber4sql(EODAmount), loopDate));

                    //OnlineGevinst kasse
                    EODAmount = tools.object2double(db.ExecuteScalar(string.Format(
                    "  (select Sum(Amount) From EOD_Sales " +
                    " where (BookDate = '{0}' " +
                    " And SubCategory = '201110203')) "
                    , loopDate)));

                    EODAmount = EODAmount * -1;
                    db.ExecuteNonQuery(string.Format(
                   " update Danske_Spil " +
                   " set OnlinePayoutDesk = '{0}' " +
                   " where BookDate = '{1}' ",
                   tools.decimalnumber4sql(EODAmount), loopDate));

                    //QuickGevinst kasse
                    EODAmount = tools.object2double(db.ExecuteScalar(string.Format(
                    "  (select Sum(Amount) From EOD_Sales " +
                    " where (BookDate = '{0}' " +
                    " And SubCategory = '201110204')) "
                    , loopDate)));
                    EODAmount = EODAmount * -1;

                    db.ExecuteNonQuery(string.Format(
                   " update Danske_Spil " +
                   " set QuickDesk = '{0}' " +
                   " where BookDate = '{1}' ",
                   tools.decimalnumber4sql(EODAmount), loopDate));

                }


                return true;


            }

        }

    }
}



namespace RBOS.DanskeSpilDataSetTableAdapters {
    
    
    public partial class Danske_SpilTableAdapter {
    }
}
