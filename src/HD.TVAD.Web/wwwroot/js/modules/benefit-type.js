define(['module/manager'], function (manager) {

	var benefitType = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
		},
	}
	return {
		init: benefitType.init,
	}
});
