define(['module/manager', 'module/search'], function (manager, search) {

	var retailSpotBooking = {
		configs: {
		},
		init: function (configs) {
			var _this = retailSpotBooking;
			$.extend(_this.configs, configs);
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: retailSpotBooking.init,
	}
});
