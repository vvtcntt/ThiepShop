 
(function (app) {
    app.controller('productListController', productListController);
    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams', 'commonService', '$ngBootbox', '$filter']
    function productListController($scope, apiService, notificationService, $stateParams, commonService, $ngBootbox, $filter) {
        $scope.product = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getProduct = getProduct;
        $scope.idMenu = $stateParams.id || 0;
        $scope.deleteProduct = deleteProduct;
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;
        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.id);
            })
            var config = {
                params: {
                    checkedProduct: JSON.stringify(listId)
                }
            }
            apiService.del('/api/Products/deletemuilti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi !');
                getProduct();
            }, function (error) {

            });
        }
        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.product, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.product, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        $scope.$watch("product", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);
        function deleteProduct(id, name) {
            $ngBootbox.confirm('Bạn có muốn xóa ' + name + '  không ?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/Products/delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công ' + name);
                    getProduct();
                }, function (error) {
                    notificationService.displayError('Xóa không thành không thành công ' + name + '!');

                });

            });
        }
        function getProduct(page, id) {
            page = page || 0; id = $stateParams.id;
            id = id || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20,
                    id: id
                }
            }
            apiService.get('/api/Products/getall', config, function (result) {
                $scope.product = result.data.Items;
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
        function changeMenu(id, idCate) {
            idCate = idCate || 0;
            var config = {
                params: {
                    id: id,
                    idCate: idCate
                }
            }
            if (id == idCate) {
                notificationService.displayError('Cập nhật không thành công !');
            }
            else {
                apiService.get('/api/Products/updateIdCate', config, function () {
                    notificationService.displaySuccess('Đã được cập nhật thành công');
                    $scope.getProduct();
                }, function (error) {
                    console.log(error);
                });
            }

        }
        $scope.updateMutil = updateMutil;
        function updateMutil(id,code, active, viewhomes, ord,price,pricesale) {

            var config = {
                params: {
                    id: id,
                    code:code,
                    active: active,
                    viewhomes: viewhomes,
                    ord: ord,
                    price: price,
                    pricesale:pricesale
                }

            }
            apiService.get('/api/Products/updateMutil', config, function () {
                //notificationService.displaySuccess('Đã được cập nhật thành công');
                $scope.getProduct();
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công !');
            });
        }

        loadParentGroupProduct();
        $scope.getProduct();
    }
})(angular.module('thiepshop.products'));