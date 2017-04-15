/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('doan.donations', ['doan.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('donation', {
                url: '/donation',
                parent: 'base',
                templateUrl: '/app/components/donations/donationListView.html',
                controller: 'donationListController'
            })
            .state('donationadd', {
                url: '/donationadd',
                parent: 'base',
                templateUrl: '/app/components/donations/donationAddView.html',
                controller: 'donationAddController'
            })
            .state('donationedit', {
                url: '/donationedit/:id',
                parent: 'base',
                templateUrl: '/app/components/donations/donationEditView.html',
                controller: 'donationEditController'
            })
    }
})()