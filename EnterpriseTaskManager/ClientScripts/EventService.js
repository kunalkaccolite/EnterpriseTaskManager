app.service("EventService", function ($http) {

    this.getEventTransactionlist = function () {
        var response = $http.get('/Home/GetEventTransactionList' );
       
        return response;
    };

    this.getEventTypeDetails = function (EventType) {
        var response = $http.get('/Home/GetEventTypeDetails?EventType='+EventType );
        return response;
};



    this.postInfo = function (insurance) {
        var req = $http.post('/api/Insurance', insurance);
        return req;
    };

});