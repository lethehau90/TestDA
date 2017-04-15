/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('donationEditController', donationEditController)

    donationEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService']

    function donationEditController($scope, $state, $stateParams, apiService, notificationService) {

        $scope.donation = []

        $scope.Editdonation = Editdonation

        $scope.getDetailDonation = getDetailDonation

        function Editdonation() {
            apiService.put('/api/donation/update', $scope.donation, function (result) {
                notificationService.displaySuccess('Cập nhật thành công ' + result.data.Name)
                $state.go('donation')
            }, function (error) {
                console.log('lỗi')
            })
        }


        function getDetailDonation() {
            apiService.get('/api/donation/getbyid/'+$stateParams.id, null, function (result) {
                $scope.donation = result.data
            }, function (error) {
                console.log('lỗi')
            })
        }

        $scope.getDetailDonation();


    }

})(angular.module('doan.donations'))