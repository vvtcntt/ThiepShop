/// <reference path="D:\Data\MVC\CodeWeb\CMS\Git\ThiepShop.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('thiepshop',
        ['thiepshop.products',
            'thiepshop.groupProduct',
         'thiepshop.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();