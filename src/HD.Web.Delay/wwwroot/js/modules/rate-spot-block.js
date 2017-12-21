define(['module/manager'], function (manager) {

	var rateSpotBlock = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			console.log("This in rateSpotBlock.init: ", this);
		},
	}
	return {
		init: rateSpotBlock.init,
	}
});
