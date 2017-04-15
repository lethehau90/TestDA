/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('doan.laudatories', ['doan.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('laudatory', {
                url: '/laudatory',
                parent: 'base',
                templateUrl: '/app/components/Laudatories/laudatoryListView.html',
                controller: 'laudatoryListController'
            })
            .state('laudatoryadd', {
                url: '/laudatoryadd',
                parent: 'base',
                templateUrl: '/app/components/Laudatories/laudatoryAddView.html',
                controller: 'laudatoryAddController'
            })
            .state('laudatoryedit', {
                url: '/laudatoryedit/:id',
                parent: 'base',
                templateUrl: '/app/components/Laudatories/laudatoryEditView.html',
                controller: 'laudatoryEditController'
            })
    }
})()