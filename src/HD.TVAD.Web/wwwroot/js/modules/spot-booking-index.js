define(['module/manager'], function (manager) {
   
    var spotBooking = {
        configs: {            
        },
        init: function (configs) {
            var makeGrid = manager.common.makeGrid;
            makeGrid.init(configs);            
        }        
    }
    return {
        init: spotBooking.init,
    }
});
