app.controller("HomeController", function ($scope, $http,$location) {


    $scope.init = function () {
        $http.get('/Home/GetEventTransactionList')
            .then(function (response) {

                $scope.EventTransactionList = response.data;
                console.log(response);
            })
            .error(function (response) {
                alert("error");
            });
    }
    $scope.IsVisible = false;


    $scope.ShowHide = function (EventTransaction) {

        $scope.EventTypeData = EventTransaction.EventTypeDescription;
        if (EventTransaction.IsResolved == "No") {
            $http.get('/Home/GetEventActionList', { params: { EventType: EventTransaction.EventTypeDescription } })
                .then(function (response) {

                    $scope.ActionList = response.data;
                    $scope.IsVisible = $scope.IsVisible ? true : true;
                    console.log(response);
                })
                .error(function (response) {
                    alert("error");
                });
        }

        if (EventTransaction.IsResolved == "Yes") {

            $scope.IsVisible = false;

        }
    }

    $scope.Open = function (Action) {
        $location.path(Action.TargetURL );
    }
});