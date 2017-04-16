/// <reference path="\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('doan.customImages', ['doan.common']).config(config)

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('customimage', {
                url: '/customimage',
                parent: 'base',
                templateUrl: '/app/components/customImages/customImageListView.html',
                controller: 'customImageListController'
            })
            .state('customimageadd', {
                url: '/customimageadd',
                parent: 'base',
                templateUrl: '/app/components/customImages/customImageAddView.html',
                controller: 'customImageAddController'
            })
            .state('customimageedit', {
                url: '/customimageedit/:id',
                parent: 'base',
                templateUrl: '/app/components/customImages/customImageEditView.html',
                controller: 'customImageEditController'
            });
    }
})();