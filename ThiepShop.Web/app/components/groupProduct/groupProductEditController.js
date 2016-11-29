(function (app) {
    app.controller('groupProductEditController', groupProductEditController);
    groupProductEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService', '$stateParams'];
    function groupProductEditController($scope, apiService, notificationService, $state, commonService, $stateParams) {
        $scope.groupProduct = {
            DateCreate: new Date,
            Active: true,
            Priority: false,
            idUser: '1',
            Level: '1'

        }
        //Load chi tiết
        function loadGroupProductDetail()
        {
            apiService.get('/api/groupproduct/getbyid/' + $stateParams.id, null, function (result) {
                $scope.groupProduct = result.data;
            }, function (error) {
                notificationService.displayError('Không lấy được dữ liệu !');

            });
        }
        $scope.GetTagSeo = GetTagSeo;
        function GetTagSeo() {
            $scope.groupProduct.Tag = commonService.getSeoTitle($scope.groupProduct.Name);

        }

        function getOrd() {
            apiService.get('/api/GroupProduct/GetOrd', null, function (result) {
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
        $scope.updateGroupProduct = updateGroupProduct;
        function updateGroupProduct() {
            apiService.put('/api/groupproduct/update', $scope.groupProduct, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công');
                $state.go('groupProduct');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công !');
            });
        }
        getOrd(); GetTagSeo();
        loadParentGroupProduct();
        loadGroupProductDetail();
    }
})(angular.module('thiepshop.groupProduct'));
