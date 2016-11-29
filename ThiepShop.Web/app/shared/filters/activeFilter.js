(function (app) {
    app.filter('activeFilter', function () {
        return function (input) {
            if(input==true)
            {
                return 'Mở';
            }
            else
            {
                return 'Khóa';
            }

        }
    })
})(angular.module('thiepshop.common'));