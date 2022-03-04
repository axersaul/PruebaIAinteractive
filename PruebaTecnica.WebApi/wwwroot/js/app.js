'use strict';

//APP BASE angular
var app = angular.module("app", []);

app.controller("orderController", ["$scope", "$http", function ($scope, $http) {
    $scope.pendingList = [];
    $scope.listInProcess = [];
    $scope.listCompleted = [];
    $scope.listDelivered = [];
    $scope.listCanceled = [];

    //Post Some products
    var products = [
        { Sku: "000001", Name: "Bowl" },
        { Sku: "000002", Name: "Plate" },
        { Sku: "000003", Name: "Chair" },
        { Sku: "000004", Name: "Mouse" },
        { Sku: "000005", Name: "Keyboard" }
    ]
    for (let prod of products)
    {
        $http.post('https://localhost:44359/api/Product', prod);
    }
    alert("Se han insertado algunos productos");

    $http.get('https://localhost:44359/api/Order').then(res => {
        for (let order of res.data)
        {
            switch (order.status)
            {
                case 0: // IS PENDING ORDER
                    $scope.pendingList.push(order);
                    break;
                case 1: // IS IN PROCESS ORDER
                    $scope.listInProcess.push(order);
                    break;
                case 2: //IS COMPLETED
                    $scope.listCompleted.push(order);
                    break;
                case 3: // IS DELIVERED
                    $scope.listDelivered.push(order);
                    break;
                case 4: // IS CANCELED
                    $scope.listCanceled.push(order);
                    break;

            }
        }
    });
    

}]);