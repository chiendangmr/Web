define(['module/manager', 'module/search'], function (manager, search) {

	var retailCustomer = {
		configs: {
			filter: function (filterText) {
			}
		},
		init: function (configs) {
			var _this = retailCustomer;
			$.extend(_this.configs, configs);
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: retailCustomer.init,
	}
});
