ngApp.controller('releaselist', function ($scope, $http) {
    var promise = $http.get(apiUrls.Releases.ReleaseList);
    promise.then(function (data) {
        $scope.releases = data.data;
    })

    $scope.filterRelease = function (item) {

        if ($scope.ReleaseTitle != undefined && $scope.ReleaseTitle != '' ) {
            return (item.ReleaseTitle.indexOf($scope.ReleaseTitle) != -1);
        }
        else if ($scope.ReleaseStatus != undefined && $scope.ReleaseStatus != '' ) {
            return (item.Status.indexOf($scope.ReleaseStatus) != -1);
        }
        else if ($scope.ReleaseRegion != undefined && $scope.ReleaseRegion != '' ) {
            return (item.Region.indexOf($scope.ReleaseRegion) != -1);
        }
        else {
            return true;
        }


    };
});