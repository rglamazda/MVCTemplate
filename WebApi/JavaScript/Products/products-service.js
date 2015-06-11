"use strict"

app.factory("productsService", ["$http", function($http)
{
    return {
        getAllProducts: function() {
            return $http.get("/api/products");
        }
    }
}]);