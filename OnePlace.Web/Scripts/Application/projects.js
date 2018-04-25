ngApp.controller('projectdetail', function ($scope, $http) {

    var promise = $http.get(apiUrls.Setups.Projects);
    promise.then(function (data) {
        $scope.projects = data.data;
    });


    var promise = $http.get(apiUrls.Setups.Languages);
    promise.then(function (data) {
        $scope.languages = data.data;
    })



    $scope.saveProject = function (projectItem) {
        var promise = $http.post(apiUrls.Setups.Projects, projectItem);
        promise.then(function (data) {

//save multilanguage for project
            //var promise = $http.post(apiUrls.Setups.ProjectLanguages, );
            //promise.then(function (data) {
            //    $scope.languages = data.data;
            //})

            $scope.projects.push(data.data);

        });
    };
    $scope.removeProject = function (selectedProject) {
        var promise = $http.delete(apiUrls.Setups.Projects, { params: { id: selectedProject.ProjectID } });
        promise.then(function (data) {
            var index = $scope.projects.indexOf(selectedProject);
            $scope.projects.splice(index, 1);
            console.log("success");
        });
    }


    $scope.newProject = {
        Name: '',
        Region: '',
        DPMID: '',
        DefaultLanguageID: '',
        IsMultilingual:false,
        StagePreviewURL: '',
        StageCDURL: '',
        ProdPreviewURL: '',
        ProdCDURL: '',
        Comment: ''
        
   }

});