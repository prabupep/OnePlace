ngApp.controller('languagesCTRL', function ($scope, $http) {

    var promise = $http.get(apiUrls.Setups.Languages);
    promise.then(function (data) {
        $scope.languages = data.data;
    });


    $scope.saveLanguage = function (languageItem) {
        var promise = $http.post(apiUrls.Setups.Languages, languageItem);
        promise.then(function (data) {
            $scope.languages.push(data.data);
        });
    };
    $scope.removeLanguage = function (selectedLanguage) {
        var promise = $http.delete(apiUrls.Setups.Languages, { params: { id: selectedLanguage.LanguageID } });
        promise.then(function (data) {
            var index = $scope.languages.indexOf(selectedLanguage);
            $scope.languages.splice(index, 1);
            console.log("success");
        });
    }


    $scope.newLanguage = {
        Name:'',
        LanguageCode: ''
    }

});