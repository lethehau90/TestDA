/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('laudatoryEditController', laudatoryEditController)

    laudatoryEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService']

    function laudatoryEditController($scope, $state, $stateParams, apiService, notificationService) {

        $scope.Editlaudatory = Editlaudatory
        $scope.getDetailLaudatory = getDetailLaudatory

        function Editlaudatory() {
            apiService.put('/api/laudatory/update', $scope.laudatory, function (result) {
                notificationService.displaySuccess('Cập nhật thành công ' + result.data.Name)
                $state.go('laudatory')
            }, function (error) {
                console.log('lỗi')
            })
        }

        function getDetailLaudatory() {
            apiService.get('/api/laudatory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.laudatory = result.data
            }, function (error) {
                console.log('lỗi')
            })
        }

        $scope.getDetailLaudatory();

    }

})(angular.module('doan.laudatories'))