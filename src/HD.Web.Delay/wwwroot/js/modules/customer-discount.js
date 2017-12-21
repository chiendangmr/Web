define(['module/manager'], function (manager) {

	var customerDiscount = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
		},
	}
	return {
		init: customerDiscount.init,
	}
});
