define(['module/manager', 'module/search'], function (manager, search) {

	var productGroup = {
		configs: {
		},
		init: function (configs) {
			var _this = productGroup;
			$.extend(_this.configs, configs);
			var makeTree = manager.common.makeTreeList;
			makeTree.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: productGroup.init,
	}
});
