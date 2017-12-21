define(['module/manager'], function (manager) {

	var indexBooking = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
		},
	}
	return {
		init: indexBooking.init,
	}
});
