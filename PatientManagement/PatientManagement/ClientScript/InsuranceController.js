app.controller('InsuranceController', function ($scope, insuranceService) {
    //The Gender Object
    $scope.selectedGender = "Male";
    $scope.gender = ["Male", "Female"];



    //Function to Reset Scope variables
    function initialize() {
        $scope.PatientId = 0;
        $scope.PatientName = "";
        $scope.InsuranceCompanyID = "";
        $scope.InsuranceCompanyName = "";
        $scope.InsuredPersonID = "";
        $scope.InsuredPersonName = "";
        $scope.InsurancePlanId = "";
        $scope.PlanEffectiveDate = "";
        $scope.PlanExpiryDate = "";
        $scope.InsurancePlanType = "";


    }


    //Function to Calculate Age
    function calculateAge(dateString) {
        var currentday = new Date();
        var bDate = new Date(dateString);
        var age = currentday.getFullYear() - bDate.getFullYear();
        var mt = currentday.getMonth() - bDate.getMonth();
        if (mt < 0 || (mt === 0 && currentday.getDate() < bDate.getDate())) {
            age--;
        }
        return age;
    }

    $scope.getAge = function () {
        $scope.Age = calculateAge($scope.BirthDate);
    }

    //Function to Submit the form
    $scope.submitForm = function () {
        var Insurance = {};
        Insurance.PatientId = $scope.PatientId;
        Insurance.InsurancePlanId = $scope.InsurancePlanId;
        Insurance.InsuranceCompanyId = $scope.InsuranceCompanyID;
        Insurance.InsuranceCompanyName = $scope.InsuranceCompanyName;
        Insurance.InsuredSGroupEmpId = $scope.InsuredPersonID;
        Insurance.InsuredSGroupEmpName = $scope.InsuredPersonName;
        Insurance.PlanType = $scope.InsurancePlanType;
        Insurance.CreatedBy = "Paya;";
        Insurance.PlanEffectiveDate = $scope.ProcedureCode;
        Insurance.PlanExpirationDate = $scope.PlanExpiryDate;
    

        var promisePost = insuranceService.postInfo(Insurance);
        promisePost.then(function (d) {
            $scope.PersonId = d.data.PersonId;
        }, function (err) {
            alert("Some Error Occured "+err);
        });
    };
    //Function to Cancel Form
    $scope.cancelForm = function () {
        $scope.selectedGender = "Male";
        initialize();
    };
});