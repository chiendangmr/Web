define(['module/manager'], function (manager) {

       var module = {
            configs: {
            },
            init: function (configs) {
            	var makeGrid = manager.common.makeGrid;
            	makeGrid.init(configs);
            },
        }
    return {
    	init: module.init,
    }
});
