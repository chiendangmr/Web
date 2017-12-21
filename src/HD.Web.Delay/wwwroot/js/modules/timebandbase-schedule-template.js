define(['module/manager'], function (manager) {

	var module = {
		configs: {
		},
		init: function (configs) {
			var make = manager.common.makeGrid;
			make.init(configs);
			console.log("This in channel.init: ", this);
		},
	}
	return {
		init: module.init,
	}
});
