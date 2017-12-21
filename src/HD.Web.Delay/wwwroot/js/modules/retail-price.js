define(['module/manager', 'module/search'], function (manager, search) {

	var retailPrice = {
		configs: {
		},
		init: function (configs) {
			var _this = retailPrice;
			$.extend(_this.configs, configs);
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: retailPrice.init,
	}
});
