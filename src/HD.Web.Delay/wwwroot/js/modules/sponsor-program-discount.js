define(['module/manager'], function (manager) {

	var sponsorProgramDiscount = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
		},
	}
	return {
		init: sponsorProgramDiscount.init,
	}
});
