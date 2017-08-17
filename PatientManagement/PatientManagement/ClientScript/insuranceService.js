app.service("insuranceService", function ($http) {

    this.getInfo = function (id) {
        var req = $http.get('/api/PersonInformationAPI/' + id);
        return req;
    };

    this.getAppInfo = function () {
        var req = $http.get('/api/PersonInformationAPI');
        return req;
    }

    this.postInfo = function (insurance) {
        var req = $http.post('/api/Insurance', insurance);
        return req;
    };

});