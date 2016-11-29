(function () {
    angular.module("thiepshop.groupProduct", ['thiepshop.common']).config(config);
    config.$inject = ["$stateProvider", "$urlRouterProvider"]
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('groupProduct', {
            url: "/groupProduct/:id",
            templateUrl: "/app/components/groupproduct/groupproductListView.html",
            controller: "groupProductListController"
        })
            .state('groupProduct_add', {
            url: "/groupProduct_add",
            templateUrl: "/app/components/groupproduct/groupproductAddView.html",
            controller: "groupProductAddController"
        })
            .state('groupProduct_edit', {
                url: "/groupProduct_edit/:id",
            templateUrl: "/app/components/groupproduct/groupproductEditView.html",
            controller: "groupProductEditController"
        });


    }
})();