

var app = angular.module("TaskManager", ['ngAnimate', 'ui.bootstrap']);





app.run(function ($rootScope, $timeout, $document, EventService) {
    
    console.log('starting run');

    // Timeout timer value
    var TimeOutTimerValue = 60000;

    // Start a timeout
    var TimeOut_Thread = $timeout(function () { LogoutByTimer() }, TimeOutTimerValue);
    var bodyElement = angular.element($document);

    angular.forEach(['keydown', 'keyup', 'click', 'mousemove', 'DOMMouseScroll', 'mousewheel', 'mousedown', 'touchstart', 'touchmove', 'scroll', 'focus'],
        function (EventName) {
            bodyElement.bind(EventName, function (e) { TimeOut_Resetter(e) });
        });

    function LogoutByTimer() {
        $rootScope.$emit('Initialize', {});
       
          }

    function TimeOut_Resetter(e) {
       
         /// Stop the pending timeout
        $timeout.cancel(TimeOut_Thread);

        /// Reset the timeout
        
        TimeOut_Thread = $timeout(function () { LogoutByTimer() }, TimeOutTimerValue);
    }

})


app.filter('search', function () {

    return function (instances, searchParams) {

       var filtered = [];
        var filter = [];



        angular.forEach(instances, function (row) {
            var x = true;
          
            x = x && (!searchParams["ResolvedBy"] || row.ResolvedBy.toLowerCase().includes(searchParams["ResolvedBy"].toLowerCase()))
              
          
            angular.forEach(Object.keys(searchParams), function (key) {
                 if (isNaN(row.ObjectData[key]))
               x=x&&(!searchParams[key] || row.ObjectData[key].toLowerCase().includes (searchParams[key].toLowerCase()))
                else
                    x = x && ((!searchParams[key] ||row.ObjectData[key].toString().includes(searchParams[key])))
                    
            })
            if (x)
                filtered.push(row);
                
         
        });
        return filtered;
    };

});