app.controller("HomeController", function ($scope, $rootScope, $http, EventService) {

    $scope.init = function () {

        console.log("initialize called");
        $scope.ItemsToBEShown = [];
        $scope.query = {};
        $scope.EventType = "Registration";
        $scope.query.EventTypeDescription = $scope.EventType;
        $scope.query.IsResolved = "No";
        $scope.ObjectDataKeys = [];
        $scope.selectedRow = undefined;
        $scope.IsVisible = false;
        $scope.searchParams = {};
        $scope.SearchDropDownValues = {}
        $scope.ShowAllTasks = false;
        $scope.row1 = {};

        $scope.userName = 'payal';
        var GetEventTypeForUser = EventService.getEventTypeForUser();

        GetEventTypeForUser.then(function (d) {
            $scope.EventTypeForUser = d.data;

        });

        var GetEventTypeDetails = EventService.getEventTypeDetails($scope.EventType);

        GetEventTypeDetails.then(function (d) {
            $scope.data = d.data;
            $scope.data.DisplayParameters = JSON.parse($scope.data.DisplayParameters);
            $scope.Columns = Object.keys($scope.data.DisplayParameters);
            angular.forEach($scope.Columns, function (item) {
                $scope.ItemsToBEShown.push($scope.data.DisplayParameters[item]);
            })


        });

        $scope.GetEventTransaction($scope.EventType);

    }

    $scope.GetEventTransaction = function (EventType) {

        var promisePost = EventService.getEventTransactionlist(EventType, $scope.ShowAllTasks);

        promisePost.then(function (d) {
            $scope.EventTransactionList = d.data;
            angular.forEach($scope.EventTransactionList, function (item) {
                item.ObjectData = JSON.parse(item.ObjectData);
                item.ObjectDataKeys = Object.keys(item.ObjectData);
            });
            $scope.initController();
            $scope.Getdata = function (item, EventTransaction) {
                return EventTransaction.ObjectData[item];
            }
            $scope.row1 = $scope.EventTransactionList[0];

        }, function (err) {
            alert("Some Error Occured " + err);
            });
       

    }

    $scope.ShowAllTask = function () {

        if ($scope.ShowAllTasks) {
            $scope.query.IsResolved = undefined
            $scope.GetEventTransaction($scope.EventType);
        }
        else {
            $scope.query.IsResolved = 'No';
            $scope.GetEventTransaction($scope.EventType);
        }
    }

    $rootScope.$on("Initialize", function () {
        $scope.init();
    });

    $scope.IsVisible = false;

    $scope.DropDownVisible = false;

    $scope.GetEventType = function (EventType) {
        $scope.IsVisible = false;
        $scope.selectedRow = undefined;
        $scope.query.EventTypeDescription = $scope.EventType;
        var GetEventTypeDetails = EventService.getEventTypeDetails(EventType);

        GetEventTypeDetails.then(function (d) {
            $scope.ItemsToBEShown.length = 0;
            $scope.data = d.data;
            $scope.data.DisplayParameters = JSON.parse($scope.data.DisplayParameters);
            $scope.Columns = Object.keys($scope.data.DisplayParameters);
            angular.forEach($scope.Columns, function (item) {
                $scope.ItemsToBEShown.push($scope.data.DisplayParameters[item]);

            })
            $scope.GetEventTransaction(EventType, $scope.ShowAllTasks);
        });

      
    }


    $scope.InitializeSearchParams = function () {
        $scope.SearchDropDownValues = {}
    }

    $scope.ShowHide = function (EventTransaction, index) {
        $scope.selectedRow = index;
        $scope.selectedTask = EventTransaction;
        $scope.EventTypeData = EventTransaction.EventTypeDescription;
        if (EventTransaction.IsResolved == "No") {
            var promiseGet = EventService.getEventActionList(EventTransaction.EventTypeDescription);

            promiseGet.then(function (d) {
                $scope.ActionList = d.data;
                $scope.IsVisible = true;


            }, function (err) {
                alert("some error occured" + err);
            });
        }

        if (EventTransaction.IsResolved == "Yes") {
            $scope.IsVisible = false;
        }
    }


    $scope.GoToUrl = function (ActionData) {

        var promiseGoToUrl = EventService.GoToUrl($scope.selectedTask, ActionData);
        promiseGoToUrl.then(function (d) {

            $scope.init();
            $scope.EventTransactionList = d.data;
        }, function (err) {
            alert("Some Error Occured " + err);
        });



    }



    $scope.pager = {};
    $scope.setPage = setPage;


    $scope.initController = function () {
        // initialize to page 1
        $scope.setPage(1);
    }

    function setPage(page) {
        $scope.dummyItems = $scope.EventTransactionList // dummy array of items to be paged
        if (page < 1 || page > $scope.pager.totalPages) {
            return;
        }

        // get pager object from service
        $scope.pager = EventService.GetPager($scope.EventTransactionList.length, page, $scope.EventTransactionList);

        // get current page of items
        $scope.items = $scope.dummyItems.slice($scope.pager.startIndex, $scope.pager.endIndex + 1);

        var result = document.getElementById("TableExample");
        // $(result).DataTable();

    }



    $scope.fill = function () {
                    $scope.SearchDropDownValues = EventService.GetSearchParams($scope.ItemsToBEShown, $scope.searchString)
    };

});