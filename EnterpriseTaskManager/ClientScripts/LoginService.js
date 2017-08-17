angular.module('TaskManager').service('LoginService', function ($http) {


    this.LoginValidate = function (UserData) {
        var result = $http({
            method: "Post",
            url: '/Login/ValidateUser', //pass UserData values to class file  
            data: {
                userName: UserData.Email,
                password: UserData.Password
            }
        });  
        return result;  
    }  
});  