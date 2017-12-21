define(['module/manager'], function (manager) {

	var annexContractAsset = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
		},
	}
	return {
		init: annexContractAsset.init,
	}
});
