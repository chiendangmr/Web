define(['module/manager'], function (manager) {

       var module = {
            configs: {
            },
            init: function (configs) {
            	var makeGrid = manager.common.makeGrid;
            	makeGrid.init(configs);
            	console.log("This in module.init: ", this);
            },
        }
    return {
    	init: module.init,
    }
});
