/// <reference path="\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('customHeaderListController', customHeaderListController);

    customHeaderListController.$inject = ['$scope', '$state', 'notificationService', 'apiService', '$filter']

    function customHeaderListController($scope, $state, notificationService, apiService, $filter) {

        $scope.customHeaders = [];

        $scope.getControlPanel = getControlPanel;

        function getControlPanel() {
            apiService.get('/api/customheader/getall', null, function (result) {
                if (result.data.length === 0) {
                    notificationService.displayWarning('Không có bản ghi nào')
                }
                else {
                    $scope.customHeaders = result.data;
                }
            }, function (error) {
                console.log('lỗi')
            })
        }

        getControlPanel()
    }

})(angular.module('doan.customHeaders'))