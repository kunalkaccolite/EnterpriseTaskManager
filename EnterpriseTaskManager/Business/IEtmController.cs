using System;

namespace EnterpriseTaskManager
{
    public interface IEtmController
    {
        string GetEventActionListForEvent(string EventType);

        string EventTypeDetails(String EventType);

        bool GoToURL(string ObjectData, string BodyFormat, string TargetURL, string MethodType, int parentTransactionId);

        bool UpdateEventTransaction(int transactionId);

        bool InsertEventTransaction(string eventTransactionJSON);

       string GetEventTransactionList(string EventType, bool ShowAllTasks);

        bool ValidateLogin(String userName, String password);



    }
}