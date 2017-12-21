define(['module/manager'], function (manager) {

	var annexContract = {
		configs: {
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			makeGrid.init(configs);
			console.log("This in annexContractDiscount.init: ", this);
		},
	}
	return {
		init: annexContract.init,
	}
});
