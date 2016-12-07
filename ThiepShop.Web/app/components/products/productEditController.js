 (function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService', '$stateParams'];
    function productEditController($scope, apiService, notificationService, $state, commonService, $stateParams) {
        $scope.products = {
            DateCreate: new Date,
            Active: true,
            Priority: false,
            idUser: '1',
            Ord: '1',
            Warranty: '0',
            Price: '0',
            PriceSale: '0'
        }
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.products.ImageLinkDetail = fileUrl;
                })
            }
            finder.popup();
        }
        $scope.moreImages = [];
        $scope.chooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                var index = $scope.moreImages.indexOf(fileUrl);
                if (index == -1) {
                    $scope.$apply(function () {
                        $scope.moreImages.push(fileUrl);
                        var index = $scope.moreImages.indexOf(fileUrl);

                    });
                }
            }
            finder.popup();
        }
        $scope.deleteMoreImages = function (input) {
            var index = $scope.moreImages.indexOf(input);
            $scope.moreImages.splice(index, 1)
        }
        function loadProductDetail() {
            apiService.get('/api/products/getbyid/' + $stateParams.id, null, function (result) {
                $scope.products = result.data;
                $scope.moreImages = JSON.parse($scope.products.MoreImages);
            }, function (error) {
                notificationService.displayError('Không lấy được dữ liệu !');

            });
        }
        $scope.keyupName = keyupName;
        function keyupName() {
            $scope.products.Title = $scope.products.Name;
            $scope.products.Keyword = $scope.products.Name;

        }
        $scope.getOrdMenu = getOrdMenu;
        function getOrdMenu(input) {
            getOrd(input);
        }
        function getOrd(id) {
            id = id || $stateParams.id;
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('/api/products/GetOrd', config, function (result) {
                $scope.products.Ord = result.data;
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
        $scope.updateProduct = updateProduct;
        $scope.renameUrl = false;
        function updateProduct() {
            if ($scope.renameUrl == true)
            {
                $scope.products.Tag = commonService.getSeoTitle($scope.products.Name);

            }
            $scope.products.MoreImages = JSON.stringify($scope.moreImages);

            apiService.put('/api/products/update', $scope.products,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới !');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công ! ' + error);
                });
        }
        //getOrd();
        loadProductDetail();
        loadParentGroupProduct();

    }
})(angular.module('thiepshop.products'));
