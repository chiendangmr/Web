define(['module/manager', 'kendo.all.min'], function (manager) {

    var evidence = {
        configs: {
            channelId: "",
            date: "",
        },
        init: function (configs) {
            var _this = evidence;
            $.extend(_this.configs, configs);

            _this.makeGrid();
        },
        makeGrid: function () {
            var _this = evidence;
            $("#grid").kendoGrid({
                batch: true,
                //height: "400px",                
                dataSource: evidence.gridDataSource(),
                selectable: true,
                columns: [
                    { field: "RecordTime", format: "{0: yyyy-MM-dd HH-mm-ss}", title: _this.configs.recordTimeStr },
                    { field: "FileName", title: _this.configs.fileNameStr },
                    { field: "Path", title: _this.configs.pathStr },
                    { field: "AssetName", title: _this.configs.assetNameStr }
                ],
                pageable: true
            }).data("kendoGrid");
        },
        gridDataSource: function () {
            return {
                type: "aspnetmvc-ajax",
                transport: {
                    read: {
                        type: "GET",
                        url: '/MAM/Evidence/GetAllEvidence',
                        dataType: 'json',
                        data: { channelId: evidence.configs.channelId, date: evidence.configs.date }
                    }
                },
                pageSize: 20,
                schema: {
                    type: "json",
                    model: {
                        id: "Id",
                        fields: {
                            RecordTime: { type: "date" },
                            FileName: { type: "string" },
                            Path: { type: "string" },
                            AssetName: { type: "string" }
                        }
                    }
                }
            };
        }
    }
    return {
        init: evidence.init,
    }
});
