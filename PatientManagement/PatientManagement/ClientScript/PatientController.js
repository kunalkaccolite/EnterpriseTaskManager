app.controller('PatientController', function ($scope, patientService) {
    //The Gender Object
    $scope.selectedGender = "Male";
    $scope.gender = ["Male", "Female"];
 
  
  
    //Function to Reset Scope variables
    function initialize() {
        $scope.PatientId = 0;
        $scope.PatientName = "";
        $scope.BirthDate = "";
        $scope.Age = 0;
        $scope.Address = "";
        $scope.MobileNo = "";
        $scope.DoctorId = "";
        $scope.ProcedureCode = 0;
      
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
        var Patient = {};
        Patient.PatientId = $scope.PatientId;
        Patient.Name = $scope.PatientName;
        Patient.Sex = $scope.selectedGender;
        Patient.DOB=$scope.BirthDate;
        Patient.Age = calculateAge($scope.BirthDate);
        Patient.Address = $scope.Address;
        Patient.PhoneNo = $scope.MobileNo;
        Patient.DoctorId = $scope.DoctorId;
        Patient.ProcedureCode = $scope.ProcedureCode;
        Patient.Status = "Registration";
        Patient.CreatedBy = "payal";
 
        var promisePost = patientService.postInfo(Patient);
        promisePost.then(function (d) {
            $scope.PersonId = d.data.PersonId;
        }, function (err) {
            alert("Some Error Occured ");
        });
    };
    //Function to Cancel Form
    $scope.cancelForm = function () {
        $scope.selectedGender = "Male";
        initialize();
    };
});