define(['module/manager', 'module/search'], function (manager, search) {

	var producer = {
		configs: {
		},
		init: function (configs) {
			var _this = producer;
			$.extend(_this.configs, configs);
			var makeTree = manager.common.makeTreeList;
			makeTree.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: producer.init,
	}
});
