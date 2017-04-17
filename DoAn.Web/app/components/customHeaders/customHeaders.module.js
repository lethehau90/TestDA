/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('doan.customHeaders', ['doan.common']).config(config)

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('customheader', {
                url: '/customheader',
                parent: 'base',
                templateUrl: '/app/components/customHeaders/customHeaderListView.html',
                controller: 'customHeaderListController'
            })
            .state('customheaderedit', {
                url: '/customheaderedit/:id',
                parent: 'base',
                templateUrl: '/app/components/customHeaders/customHeaderEditView.html',
                controller: 'customHeaderEditController'
            });
    }
})();