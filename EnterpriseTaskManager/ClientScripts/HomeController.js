app.controller("HomeController", function ($scope, $http,$location,$log, EventService) {

   

    $scope.init = function () {
    

        $scope.ItemsToBEShown = [];
        $scope.EventType = "Registration";
   

        var GetEventTypeDetails = EventService.getEventTypeDetails($scope.EventType);

        GetEventTypeDetails.then(function (d) {
            $scope.data = d.data;
            $scope.data.InputTypeObject = JSON.parse($scope.data.InputTypeObject);
            $scope.Columns = Object.keys($scope.data.InputTypeObject);
            angular.forEach($scope.Columns, function (item) {
                $scope.ItemsToBEShown.push($scope.data.InputTypeObject[item]);
            })

        });




        var promisePost = EventService.getEventTransactionlist();

        promisePost.then(function (d) {
            $scope.EventTransactionList = d.data;
            angular.forEach($scope.EventTransactionList, function (item) { item.ObjectData = JSON.parse(item.ObjectData); });

            console.log($scope.EventTransactionList);
               $scope.Getdata = function (item, EventTransaction) {
                 return EventTransaction.ObjectData[item];
            }
        }, function (err) {
            alert("Some Error Occured " + err);
            });

            
    }
    $scope.IsVisible = false;

    $scope.DropDownVisible = false;

    $scope.GetEventType = function (EventType) {
        var GetEventTypeDetails = EventService.getEventTypeDetails(EventType);

        GetEventTypeDetails.then(function (d) {
            $scope.ItemsToBEShown.length = 0;
            $scope.data = d.data;
            $scope.data.InputTypeObject = JSON.parse($scope.data.InputTypeObject);
            $scope.Columns = Object.keys($scope.data.InputTypeObject);
            angular.forEach($scope.Columns, function (item) {
                $scope.ItemsToBEShown.push($scope.data.InputTypeObject[item]);
             
            })
        });
    }

    $scope.ShowHide = function (EventTransaction) {

        $scope.EventTypeData = EventTransaction.EventTypeDescription;
        if (EventTransaction.IsResolved  == "No") {
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

    $scope.items = [
        'The first choice!',
        'And another choice for you.',
        'but wait! A third!'
    ];

    $scope.status = {
        isopen: false
    };

    $scope.toggled = function (open) {
        $log.log('Dropdown is now: ', open);
    };

    $scope.toggleDropdown = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();
        $scope.status.isopen = !$scope.status.isopen;
    };


    $scope.ShowAllDetails= function(EventTransaction){
        $scope.DropDownVisible = $scope.DropDownVisible ? false : true;
}

});