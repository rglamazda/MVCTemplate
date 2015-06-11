"use strict"

app.controller("productsController", function ($scope, $location, productsService) {

    productsService.getAllProducts().then(function (result) {
        $scope.allProducts = result.data;
        console.log($scope.allProducts);
    });

});