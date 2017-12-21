define(['module/manager', 'module/search'], function (manager, search) {

	var contentType = {
		configs: {
		},
		init: function (configs) {
			var _this = contentType;
			$.extend(_this.configs, configs);
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: contentType.init,
	}
});
