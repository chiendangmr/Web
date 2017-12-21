define(['module/manager', 'module/search'], function (manager, search) {

	var spotBlock = {
		configs: {
			filter: function (filterText) {
			}
		},
		init: function (configs) {
			var _this = spotBlock;
			var makeGrid = manager.common.makeGrid;
			$.extend(_this.configs, configs);
			makeGrid.init(_this.configs);
			search.init(_this.configs);
		},

	};
    return {
        init: spotBlock.init,
    }
});
