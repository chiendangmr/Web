define(['module/manager'], function (manager) {

	var annexContractDiscount = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
		},
	}
	return {
		init: annexContractDiscount.init,
	}
});
