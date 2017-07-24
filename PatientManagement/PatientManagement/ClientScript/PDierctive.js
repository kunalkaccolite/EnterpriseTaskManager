app.directive('personForm',
    function () {
 
        return {
            restrict: 'E',
            templateUrl: '/ClientScript/HTML/PatientForm.html'
        }
 
    });
app.directive('insuranceForm',
    function () {
        return {
            restrict: 'E',
            templateUrl:'/ClientScript/HTML/InsurancePage.html'
        }
    }
)