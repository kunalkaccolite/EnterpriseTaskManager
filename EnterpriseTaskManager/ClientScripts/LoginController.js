app.controller('LoginController', ['$scope', 'LoginService', 'EventService', function ($scope, LoginService, $rootScope, EventService) {
    $scope.InvalidCredentials = false;

    $scope.submit = function () {
        var UserData = {
            Email: $scope.Email,
            Password: $scope.Password,
        }


        //Validate User Credentials
        LoginService.LoginValidate(UserData).then(function (pl) {
            if (pl.data == "True") {
                window.location.pathname = "/Home/Index"
            }
            else {
                $scope.InvalidCredentials = true;
            }
        });
    }
}]);
