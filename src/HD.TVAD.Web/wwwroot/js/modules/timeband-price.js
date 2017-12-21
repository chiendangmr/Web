define(['module/manager', 'module/search'], function (manager, search) {

	var timeBandPrice = {
		configs: {
			filter: function (filterText) {
			}
		},
		init: function (configs) {
			var _this = timeBandPrice;
			$.extend(_this.configs, configs);
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: timeBandPrice.init,
	}
});
