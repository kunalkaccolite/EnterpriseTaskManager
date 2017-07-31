using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseTaskManager.DataAccess
{
    public static class SQLQueriesConstants
    {
        public static string sp_GetActionListForEventType = "sp_GetActionListForEventType";
        public static string sp_GetTransactionDetails = "sp_GetTransactionDetails";
        public static string sp_InsertIntoEventTransaction = "sp_InsertIntoEventTransaction";
        public static string sp_EventTypeDetails = "sp_EventTypeDetails";
    } 
}
