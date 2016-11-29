(function (app) {
    app.controller('groupProductListController', groupProductListController);
    groupProductListController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams', 'commonService']
    function groupProductListController($scope, apiService, notificationService, $stateParams, commonService) {
        $scope.groupProduct = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getGroupProduct = getGroupProduct;
        function getGroupProduct(page,id) {
            page = page || 0; id = $stateParams.id;
            id = id || 0;
            var config = {
                params: {
                    keyword:$scope.keyword,
                    page: page,
                    pageSize: 1,
                    id:id
                }
            }
            apiService.get('/api/groupproduct/getall', config, function (result) {
                //if (result.data.TotalCount == 0)
                //{
                //    notificationService.displayWarning('Không có bản ghi nào');
                //}
                //else
                //{
                //    notificationService.displaySuccess('Đã tìm thấy :' + result.data.TotalCount + ' bản ghi');

                //}
                $scope.groupProduct = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log("Không thể load được sản phẩm !");
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
        $scope.changeMenu = changeMenu;
        function changeMenu(input1,input2) {
            notificationService.displaySuccess('Đã tìm thấy id là :' + input1 + ' bản ghi' + input2);
        }
        loadParentGroupProduct();
        $scope.getGroupProduct();
    }
})(angular.module('thiepshop.groupProduct'));