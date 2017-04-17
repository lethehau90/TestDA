/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('customHeaderEditController', customHeaderEditController)

    customHeaderEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService']

    function customHeaderEditController($scope, $state, $stateParams, apiService, notificationService) {

        $scope.customHeader = []

        $scope.getDetailCustomHeader = getDetailCustomHeader
        $scope.EditCustomHeader = EditCustomHeader

        function EditCustomHeader() {
            apiService.put('/api/customheader/update', $scope.customHeader, function (result) {
                notificationService.displaySuccess('Cập nhật thành công ' + result.data.Name)
                $state.go('customheader')
            }, function (error) {
                console.log('lỗi')
            })
        }

        function getDetailCustomHeader() {
            apiService.get('/api/customheader/getbyid/' + $stateParams.id, null, function (result) {
                $scope.customHeader = result.data
            }, function (error) {
                console.log('lỗi')
            })
        }

        getDetailCustomHeader()

    }

})(angular.module('doan.customHeaders'))