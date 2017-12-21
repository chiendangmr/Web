define(['module/manager', 'module/search'], function (manager, search) {

	var sponsorProgram = {
		configs: {
			filter: function (filterText) {
			}
		},
		init: function (configs) {
			var _this = sponsorProgram;
			$.extend(_this.configs, configs);
			var make = manager.common.makeTreeList;
			make.init(_this.configs);
			search.init(_this.configs);
		},
	}
	return {
		init: sponsorProgram.init,
	}
});
