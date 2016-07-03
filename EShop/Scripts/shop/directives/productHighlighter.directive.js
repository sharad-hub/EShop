(function (app) {
	'use strict';

	app.directive('productLabel', productLabel);
	function productLabel() {
		return {
		    restrict: 'E',
		    replace: true,
			templateUrl: "/scripts/shop/directives/productHighlighter.html",
			link: function ($scope, $element, $attrs) {
			    $scope.getLabelClass = function () {			    
				    if ($attrs.labelValue === 'SALE')
					    return 'aa-badge aa-sale'
				    else if ($attrs.labelValue === 'Sold Out')
				        return 'aa-badge aa-sold-out'
					else
					    return ''
				};
			    $scope.getLabel = function () {
				    if ($attrs.labelValue === 'SALE')
				        return 'SALE'
				    else if ($attrs.labelValue === 'Sold Out')
				        return 'Sold Out'
				    else
				        return ''
				};
			}
		}
	}
})(angular.module('common.ui'));