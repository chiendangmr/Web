define(['module/manager'], function (manager) {

	var benefitPrice = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
		},
	}
	return {
		init: benefitPrice.init,
	}
});
