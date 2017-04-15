/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('controlPanelEditController', controlPanelEditController)

    controlPanelEditController.$inject = ['$scope','$state', '$stateParams','apiService', 'notificationService']

    function controlPanelEditController($scope, $state, $stateParams, apiService, notificationService) {

        $scope.controlPanel = []

        $scope.getDetailControlPanel = getDetailControlPanel
        $scope.EditcontrolPanel = EditcontrolPanel

        function EditcontrolPanel() {
            apiService.put('/api/controlpanel/update', $scope.controlPanel, function (result) {
                notificationService.displaySuccess('Cập nhật thành công ' + result.data.Name)
                $state.go('controlpanel')
            }, function (error) {
                console.log('lỗi')
            })
        }

        function getDetailControlPanel() {
            apiService.get('/api/controlpanel/getbyid/' + $stateParams.id, null, function (result) {
                $scope.controlPanel = result.data
            }, function (error) {
                console.log('lỗi')
            })
        }

        getDetailControlPanel()

    }

})(angular.module('doan.controlPanels'))