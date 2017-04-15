/// <reference path="\Assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('donationListController', donationListController);

    donationListController.$inject = ['$scope', '$state', 'notificationService', 'apiService', '$filter', '$ngBootbox']

    function donationListController($scope, $state, notificationService, apiService, $filter, $ngBootbox) {

        $scope.donations = [];

        $scope.getDonations = getDonations;

        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.keyword = '';

        $scope.search = search;

        $scope.deleteDonation = deleteDonation

        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;

        //search
        function search() {
            getDonations();
        }

        function getDonations(page) {
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page || 0,
                    pagesize: 12
                }
            }
            apiService.get('/api/donation/getall', config, function (result) {
                if (result.data.length === 0) {
                    notificationService.displayWarning('Không có bản ghi nào')
                }
                else {
                    $scope.donations = result.data.Items;
                    $scope.page = result.data.page;
                    $scope.pagesCount = result.data.TotalPages;
                    $scope.totalCount = result.data.TotalCount;
                }
            }, function (error) {
                console.log('lỗi')
            })
        }

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
                apiService.del('/api/donation/deletemulti', config, function (result) {
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
                angular.forEach($scope.donations, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.donations, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.isAll = false;

        //listening use watch
        $scope.$watch("donations", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        //deleteProductCategory
        function deleteDonation(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/donation/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công')
                    search()
                }, function () {
                    notificationService.displayError('Xóa không thành công')
                });
            });
        };

        getDonations()
    }

})(angular.module('doan.donations'))