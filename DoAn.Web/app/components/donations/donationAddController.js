/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('donationAddController', donationAddController)

    donationAddController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService']

    function donationAddController($scope, $state, $stateParams, apiService, notificationService) {

        $scope.donation = {
            Status : true
        }

        $scope.Adddonation = Adddonation

        function Adddonation() {
            apiService.post('/api/donation/create', $scope.donation, function (result) {
                notificationService.displaySuccess('Thêm thành công ' + result.data.Name)
                $state.go('donation')
            }, function (error) {
                console.log('lỗi')
            })
        }

      

    }

})(angular.module('doan.donations'))