/// <reference path="\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('laudatoryListController', laudatoryListController);

    laudatoryListController.$inject = ['$scope', '$state', 'notificationService', 'apiService', '$filter', '$ngBootbox']

    function laudatoryListController($scope, $state, notificationService, apiService, $filter, $ngBootbox) {

        $scope.laudatories = [];

        $scope.getlaudatories = getlaudatories;

        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.keyword = '';

        $scope.search = search;

        $scope.deletelaudatory = deletelaudatory

        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;



        //deleteMultiple
        function deleteMultiple() {
            $ngBootbox.confirm('Bạn có chắc chắc muốn xóa bản ghi đã chọn ?').then(function () {
                var listId = [];
                $.each($scope.selected, function (i, item) {
                    listId.push(item.ID);
                })
                var config = {
                    params: {
                        listId: JSON.stringify(listId)
                    }
                }
                apiService.del('/api/laudatory/deletemulti', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi')
                    search()
                }, function (error) {
                    notificationService.displayError('Xóa không thành công')
                });
            });
        }

        //selectAll
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.laudatories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.laudatories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.isAll = false;

        //listening use watch
        $scope.$watch("laudatories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        //deleteProductCategory
        function deletelaudatory(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/laudatory/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công')
                    search()
                }, function () {
                    notificationService.displayError('Xóa không thành công')
                });
            });
        };

        //search
        function search() {
            getlaudatories();
        }

        function getlaudatories(page) {
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page || 0,
                    pagesize: 12
                }
            }
            apiService.get('/api/laudatory/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không có bản ghi nào')
                }
                $scope.laudatories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function (error) {
                console.log('lỗi')
            })
        }

        $scope.getlaudatories()
    }

})(angular.module('doan.laudatories'))