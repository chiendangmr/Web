define(['module/manager', 'module/search'], function (manager, search) {

	var spotBooking = {
		configs: {
		},
		init: function (configs) {
			var _this = spotBooking;
			$.extend(_this.configs, configs);
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: spotBooking.init,
	}
});
