/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('doan.controlPanels', ['doan.common']).config(config)

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('controlpanel', {
                url: '/controlpanel',
                parent: 'base',
                templateUrl: '/app/components/controlPanels/controlPanelListView.html',
                controller: 'controlPanelListController'
            })
            .state('controlpaneladd', {
                url: '/controlpaneladd',
                parent: 'base',
                templateUrl: '/app/components/controlPanels/controlPanelAddView.html',
                controller: 'controlPanelAddController'
            })
            .state('controlpaneledit', {
                url: '/controlpaneledit/:id',
                parent: 'base',
                templateUrl: '/app/components/controlPanels/controlPanelEditView.html',
                controller: 'controlPanelEditController'
            });
    }
})();