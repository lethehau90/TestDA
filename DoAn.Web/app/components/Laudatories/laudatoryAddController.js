/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('laudatoryAddController', laudatoryAddController)

    laudatoryAddController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService']

    function laudatoryAddController($scope, $state, $stateParams, apiService, notificationService) {

        $scope.laudatory = {
            Status: true
        }

        $scope.Addlaudatory = Addlaudatory

        function Addlaudatory() {
            apiService.post('/api/laudatory/create', $scope.laudatory, function (result) {
                notificationService.displaySuccess('Thêm thành công ' + result.data.Name)
                $state.go('laudatory')
            }, function (error) {
                console.log('lỗi')
            })
        }



    }

})(angular.module('doan.laudatories'))