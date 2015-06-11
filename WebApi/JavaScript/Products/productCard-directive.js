"use strict"

app.directive("productCard", function ($compile) {
    return {
        restrict: 'E',
        replace: true,
        templateUrl: '/Templates/Products/ProductCard.html',
        scope: {
            image: '=',
            name: '=',
            description: '=',
            productID: '='
        }
    }
});