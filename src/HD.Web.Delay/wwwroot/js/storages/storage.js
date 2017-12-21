define(['module/manager'], function (manager) {

    var storage = {
        configs: {
        },
        init: function (configs) {
            var make = manager.common.makeGrid;
            make.init(configs);
        },
    }
    return {
        init: storage.init,
    }
});
