angular.module('TaskManager').service("EventService", function ($http) {


    //Get request to retrieve  transaction list
    this.getEventTransactionlist = function (EventType, ShowAllTasks) {
        var response = $http.get('/Home/GetEventTransactionList?EventType=' + EventType + '&ShowAllTasks=' + ShowAllTasks);
        return response;
    };


    //Get request for getting dispalay parameters and other details specific to event
    this.getEventTypeDetails = function (EventType) {
        var response = $http.get('/Home/GetEventTypeDetails?EventType=' + EventType);
        return response;
    };

    //Post to Go to target URL
        this.GoToUrl = function (SelectedTask, ActionData) {
        var objectdataString = JSON.stringify(SelectedTask.ObjectData);
        var response = $http.post('/Home/GoToUrl?ObjectData=' + objectdataString + '&BodyFormat=' + ActionData.BodyFormat + '&TargetURL=' + ActionData.TargetURL + '&MethodType=' + ActionData.MethodType + '&parentTransactionId=' + SelectedTask.EventTransactionID);
        return response;
    }


    this.getEventTypeForUser = function (userName) {
        var req = $http.get('/Home/GetEventTypeForUser');
        return req;
    };


    this.getEventActionList = function (EventTypeDescription) {
        var req = $http.get('/Home/GetEventActionList', { params: { EventType: EventTypeDescription } });
        return req;
    };


    // Pagination implementation
    this.GetPager = function (totalItems, currentPage, EventTransactionList, pageSize) {
        // default to first page
        currentPage = currentPage || 1;

        // default page size is 10
        pageSize = pageSize || 10;

        // calculate total pages
        var totalPages = Math.ceil(totalItems / pageSize);

        var startPage, endPage;
        if (totalPages <= 10) {
            // less than 10 total pages so show all
            startPage = 1;
            endPage = totalPages;
        } else {
            // more than 10 total pages so calculate start and end pages
            if (currentPage <= 6) {
                startPage = 1;
                endPage = 10;
            } else if (currentPage + 4 >= totalPages) {
                startPage = totalPages - 9;
                endPage = totalPages;
            } else {
                startPage = currentPage - 5;
                endPage = currentPage + 4;
            }
        }

        // calculate start and end item indexes
        var startIndex = (currentPage - 1) * pageSize;
        var endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);
        
        // create an array of pages to ng-repeat in the pager control
        // var N = 10;
         pages=Array.apply(null, { length: endPage+1 }).map(Number.call, Number)
       //  var pages = _.range(startPage, endPage + 1);(startPage, endPage + 1);
        pages.shift()
        // return object with all pager properties required by the view
        return {
            totalItems: totalItems,
            currentPage: currentPage,
            pageSize: pageSize,
            totalPages: totalPages,
            startPage: startPage,
            endPage: endPage,
            startIndex: startIndex,
            endIndex: endIndex,
            pages: pages
        };
    }

    this.GetSearchParams = function (itemList, searchString) {
        
        var SearchDropDownValues = {};

            var searchStringArray = searchString.split(",");
            var stringArray = []; var key, value;
            for (var i = 0; i < searchStringArray.length; i++) {
                searchStringArray[i] = searchStringArray[i].trim();
                var keyValuePair= searchStringArray[i].split(":");
                key = keyValuePair[0];
                value = keyValuePair[1];
                console.log(key);
                console.log(value);
                if (isInArray(key, itemList)){

                    SearchDropDownValues[key] = value;
                }
                     
            }

            console.log(SearchDropDownValues);
            return SearchDropDownValues;
            };

         function isInArray(value, array) {
            return array.indexOf(value) > -1;
         }
    
});