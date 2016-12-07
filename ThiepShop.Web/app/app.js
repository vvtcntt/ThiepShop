/// <reference path="D:\Data\MVC\CodeWeb\CMS\Git\ThiepShop.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('thiepshop',
        ['thiepshop.products',
            'thiepshop.groupProduct',
         'thiepshop.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/view/baseView.html',
                abstract:true
            })
            .state('login', {
                url: "/login",
                 templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",
                parent:'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
    }
})();