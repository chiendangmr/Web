define(['module/manager', 'module/search'], function (manager, search) {

	var customer = {
		configs: {
			filter: function (filterText) {
			}
		},
		init: function (configs) {
			var _this = customer;
			$.extend(_this.configs, configs);
			var makeTree = manager.common.makeTreeList;
			makeTree.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: customer.init,
	}
});
