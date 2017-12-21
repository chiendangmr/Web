define(['module/manager'], function (manager) {

	var spotBlockRate = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			console.log("This in spotBlockRate.init: ", this);
		},
	}
	return {
		init: spotBlockRate.init,
	}
});
