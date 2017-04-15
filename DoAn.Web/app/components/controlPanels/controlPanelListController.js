/// <reference path="\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('controlPanelListController', controlPanelListController);

    controlPanelListController.$inject = ['$scope', '$state', 'notificationService', 'apiService', '$filter']

    function controlPanelListController($scope, $state, notificationService, apiService, $filter) {

        $scope.controlPanels = [];

        $scope.getControlPanel = getControlPanel;

        function getControlPanel() {
            apiService.get('/api/controlpanel/getall', null, function (result) {
                if (result.data.length === 0) {
                    notificationService.displayWarning('Không có bản ghi nào')
                }
                else {
                    $scope.controlPanels = result.data;
                }
            }, function (error) {
                console.log('lỗi')
            })
        }

        getControlPanel()
    }

})(angular.module('doan.controlPanels'))