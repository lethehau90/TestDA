/// <reference path="\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('customImageListController', customImageListController);

    customImageListController.$inject = ['$scope', '$state', 'notificationService', 'apiService', '$filter']

    function customImageListController($scope, $state, notificationService, apiService, $filter) {

        $scope.customImages = [];

        $scope.getcustomImage = getcustomImage;

        function getcustomImage() {
            apiService.get('/api/customimage/getall', null, function (result) {
                if (result.data.length === 0) {
                    notificationService.displayWarning('Không có bản ghi nào')
                }
                else {
                    $scope.customImages = result.data;
                }
            }, function (error) {
                console.log('lỗi')
            })
        }

        $scope.getcustomImage()
    }

})(angular.module('doan.customImages'))