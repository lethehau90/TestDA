/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('customImageEditController', customImageEditController)

    customImageEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService']

    function customImageEditController($scope, $state, $stateParams, apiService, notificationService) {

        $scope.customImage = []

        $scope.getDetailControlPanel = getDetailControlPanel
        $scope.EditCustomImage = EditCustomImage

        function EditCustomImage() {
            apiService.put('/api/customimage/update', $scope.customImage, function (result) {
                notificationService.displaySuccess('Cập nhật thành công ' + result.data.Type)
                $state.go('customimage')
            }, function (error) {
                console.log('lỗi')
            })
        }

        function getDetailControlPanel() {
            apiService.get('/api/customimage/getbyid/' + $stateParams.id, null, function (result) {
                $scope.customImage = result.data
            }, function (error) {
                console.log('lỗi')
            })
        }

        //finder
        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.customImage.Images = fileUrl;
                })
            }
            finder.popup();
        }

        getDetailControlPanel()

    }

})(angular.module('doan.customImages'))