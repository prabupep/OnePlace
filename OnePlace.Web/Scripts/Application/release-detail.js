//CONSTANTS
LabelText = {
    add_new_project: 'New Project',
    select_project : 'Select from list'
};

Files = [{ FilePath: '$:/EMS/test/test', Status: '' }, { FilePath: '$:/EMS/test/test', Status: '' }];

ChangeSets = [{ ChangeSetNumber: '12345' }, { ChangeSetNumber: '23423423' }];
SCPackage = [{ FilePath: '$:/EMS/test/test', Status: '' }, { FilePath: '$:/EMS/test/test', Status: '' }];

Languages = [{ Name: 'en-fr', LanguageCode: 'en-fr' }, { Name: 'en-UK', LanguageCode: 'en-UK' }, { Name: 'ar-AE', LanguageCode: 'ar-AE' }, { Name: 'da-DK', LanguageCode: 'da-DK' }];

Release = {
    ReleaseID: '',
    ReleaseTitle: '',
    Region: '',
    ProjectID: '',
    DeploymentType: '',
    RequireBuild: false,
    Status: '',
    Comment: '',
    Reviewer:''
}

//NEW RELEASE REQUEST
ngApp.controller('releasedetail', function ($scope, $http) {
    // CONSTANTS
    $scope.showaddproject = false;
    $scope.NewProject = LabelText.add_new_project;
    $scope.TfsDetail = 'TFS Details';
    $scope.SCDetails = 'Sitecore Packages';
    $scope.ExternalService = 'External Services';

    $scope.files = Files;
    $scope.packages = SCPackage;
    $scope.changesets = ChangeSets;
    $scope.saveNewRelease = function (newReleaseItem) {
        var promise = $http.post(apiUrls.Releases.Release, newReleaseItem);
        promise.then(function (data) {
            var releaseID = data.data.ReleaseID;
            console.log('Release saved successfully')
            alert("Your request submitted successfully");
            $('.release-date:input:checked').each(function (index,item) {
                var datePickerId = $(item).attr('data-date-picker-id');
                var releaseDateDetail = {
                    ReleaseID: releaseID,
                    DateType: $(datePickerId).attr('data-type'),
                    StartDateTime: $(datePickerId).val(),
                    Status:''
                }
                var releaseDatePromise = $http.post(apiUrls.Releases.ReleaseDate, releaseDateDetail);
                promise.then(function (data) {
                    console.log("Release date succesfully inserted")
                });

            });
        });
    }
   

    

    var promise = $http.get(apiUrls.Setups.Projects);
    promise.then(function (data) {
        $scope.projects = data.data;
    });




    $scope.showModalPopUp = function (modal) {
        $(modal).modal('show');
    }


    $scope.addItemDetails = function (collectionList, item) {
        collectionList.push(item);
    }

    $scope.newRelease = {
        
        ReleaseTitle: '',
        Region: '',
        ProjectID: '',
        DeploymentType: '',
        RequireBuild: false,
        Status: '',
        Comment: '',
        Reviewer: '',
        Notification: ''
    }
});






