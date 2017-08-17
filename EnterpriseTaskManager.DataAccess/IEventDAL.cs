using EnterpriseTaskManager.Common;
using System;
using System.Collections.Generic;

namespace EnterpriseTaskManager.DataAccess
{
    public interface IEventDAL
    {
        bool InsertEventTransaction(EventTransaction eventTransaction);

        List<EventAction> GetEventActionForEvent(String EventType);

        List<EventTransaction> GetEventTransaction(String EventType, bool ShowAllTasks);

        EventType EventTypeDetails(string eventTypeDescription);

        bool UpdateTransactionStatus(int transactionId);

        List<EventType> GetEventTypeForUser(String userName);

        bool ValidateLogin(Users user);

    }
}