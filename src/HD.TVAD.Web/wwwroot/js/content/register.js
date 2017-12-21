define(['module/manager', 'module/search'], function (manager, search) {

	var assetRegister = {
		configs: {
		},
		init: function (configs) {
			var _this = assetRegister;
			$.extend(_this.configs, configs);
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: assetRegister.init,
	}
});
