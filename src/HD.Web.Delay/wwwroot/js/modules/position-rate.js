define(['module/manager', 'module/search'], function (manager, search) {
	var position_rate = {
		configs: {
			filter: function (filterText) {
			}
		},
		init: function (configs) {
			var _this = position_rate;
			$.extend(_this.configs, configs);
			var make = manager.common.makeGrid;
			make.init(_this.configs);
			search.init(_this.configs);
		},
	}
	return {
		init: position_rate.init,
	}
});
