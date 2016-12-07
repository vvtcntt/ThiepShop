(function (app) {
    app.controller('groupProductAddController', groupProductAddController);
    groupProductAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService', '$stateParams'];
    function groupProductAddController($scope, apiService, notificationService, $state, commonService, $stateParams) {
        $scope.groupProduct = {
            DateCreate: new Date,
            Active: true,
            Priority: false,
            idUser: '1',         
            Level: '1'

        }
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.groupProduct.ParentID = $stateParams.id;
        $scope.getOrdMenu = getOrdMenu;
        function getOrdMenu(input) {
            getOrd(input);
        }
        function getOrd(id) {
            id = id || $stateParams.id;
            var config = {
                params:{
                    id: id
                }
            }
            apiService.get('/api/GroupProduct/GetOrd', config, function (result) {
                $scope.groupProduct.Ord = result.data;
            });
        }
        //Load Style Dropdownlist
        function times(n, str) {
            var result = '';
            for (var i = 0; i < n; i++) {
                result += str;
            }
            return result;
        };

        function recur(item, level, arr) {
            arr.push({
                name: item.Name,
                id: item.id,
                level: level,
                indent: times(level, '–')
            });

            if (item.children) {
                item.children.forEach(function (item) {
                    recur(item, level + 1, arr);
                });
            }
        };
        $scope.parentGroupProduct = [];
        $scope.flatFolders = [];
        function loadParentGroupProduct() {   
            apiService.get('/api/GroupProduct/getallParent', null, function (result) {
                $scope.parentGroupProduct = commonService.getTree(result.data, 'id', 'ParentID');

                $scope.parentGroupProduct.forEach(function (item) {
                    recur(item, 0, $scope.flatFolders);
                
                });
 
            });
        }
        $scope.addGroupProduct = addGroupProduct;
        function addGroupProduct() {
            $scope.groupProduct.Tag = commonService.getSeoTitle($scope.groupProduct.Name);
            apiService.post('/api/groupproduct/create', $scope.groupProduct, function (result)
            {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới');
                $state.go('groupProduct', { 'id': $scope.groupProduct.ParentID });
            }, function (error) {
                notificationService.displayError('Thêm mới không thành công !');
            });
        }
        getOrd();

        loadParentGroupProduct(); 

    }
})(angular.module('thiepshop.groupProduct'));
