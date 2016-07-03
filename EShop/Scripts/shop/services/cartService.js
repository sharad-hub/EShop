(function (app) {
    'use strict';
    app.factory('cartService', cartService)
    //apiService.$inject('$http', '$location', '$rootScope')
    cartService.$inject = ['$http', '$location', 'notificationService', '$rootScope', '$cookieStore'];

    //angular.module("cart", [])
    function cartService() {
        var cartData = [];
        var wishlistData = [];

        //if ($localStorage.items === undefined) {
        //    $localStorage.items = [];
        //};

        //$scope.localStorage = $localStorage

        return {
            addProduct: function (id, name, price) {
                //AddToCart(product)
                //id, name, price
                var addedToExistingItem = false;
                //angular.forEach($localStorage.items, function (item) {
                //    if (items.id === id) {
                //        item.quantity++;
                //        addedToExistingItem = true;
                //    }
                //});
                //if (!addedToExistingItem) {
                //    $localStorage.items.push(angular.extend({
                //        count: 1, id: id, price: price, name: name
                //    }, id));

                //}

                for (var i = 0; i < cartData.length; i++) {
                    if (cartData[i].id == id) {
                        cartData[i].count++;
                        addedToExistingItem = true;
                        break;
                    }
                }

                if (!addedToExistingItem) {
                    cartData.push({
                        count: 1, id: id, price: price, name: name
                    });
                }
            },
            removeProduct: function (id) {
                for (var i = 0; i < cartData.length; i++) {
                    if (cartData[i].id == id) {
                        cartData.splice(i, 1);
                        break;
                    }
                }
               // $localStorage.items.splice(index, id);
            },
            getProducts: function () {
                return cartData; //$localStorage; //
            },
            getWishlistData: function () {
                return wishlistData;
            },
            addWishlist: function (id, name, price) {
                var itemExistsInWishlist = false;
                for (var i = 0; i < wishlistData.length; i++) {
                    if (wishlistData[i].id == id) {
                        itemExistsInWishlist = true;
                        break;
                    }
                }
                if (!itemExistsInWishlist) {
                    wishlistData.push({
                        id: id, price: price, name: name
                    });
                }
            },
            removeWishlist: function (id) {
                for (var i = 0; i < wishlistData.length; i++) {
                    if (wishlistData[i].id == id) {
                        wishlistData.splice(i, 1);
                        break;
                    }
                }
            }


        }
    };
})(angular.module('common.core'));