define(['module/manager'], function (manager) {

	var timeBandSliceForType = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			console.log("This in timeBandSliceForType.init: ", this);
		},
	}
	return {
		init: timeBandSliceForType.init,
	}
});
