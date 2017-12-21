define(['module/manager', 'module/search'], function (manager, search) {

	var annexContractPartnerPriceAtSignDate = {
		configs: {
		},
		init: function (configs) {
			var _this = annexContractPartnerPriceAtSignDate;
			$.extend(_this.configs, configs);
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			search.init(_this.configs);
		},
	}
	return {
		init: annexContractPartnerPriceAtSignDate.init,
	}
});
