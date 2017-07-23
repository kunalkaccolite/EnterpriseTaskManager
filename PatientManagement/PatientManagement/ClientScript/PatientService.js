app.service("patientService", function ($http) {
 
    this.getInfo = function (id) {
        var req = $http.get('/api/PersonInformationAPI/' + id);
        return req;
    };
 
    this.getAppInfo = function () {
        var req = $http.get('/api/PersonInformationAPI');
        return req;
    }
 
    this.postInfo = function (patient) {
        var req = $http.post('/api/Patient', patient);
        return req;
    };
 
});