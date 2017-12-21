define(['module/manager'], function (manager) {

	var approveSpotByContractCode = {
		configs: {
			columns: [],
			model: {},
			data: {},
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			var _this = approveSpotByContractCode;
			$.extend(_this.configs, configs);
			_this.initGrid();
		//	makeGrid.init(configs);
		},
		initGrid: function () {
			var _this = approveSpotByContractCode;
			$("#grid").kendoGrid({
				dataSource: {
					transport: {
						read: {
							url: 'Report/ApproveSpotByContractCode/GetAllSpotByContractCode',
							data: _this.configs.data,
						}
					},
					schema: {
						model: _this.configs.model,
						data: "Data",
						total: "Total"
					},
					serverPaging: true,
					serverFiltering: true,
					type: "aspnetmvc-ajax",
				},
				columns: _this.configs.columns,
				selectable: 'single',
				pageable: {
					pageSize: 10,
					pageSizes: [10, 20, 50, 100, 1000, 10000],
					refresh: true
				},
				sortable: true,
				resizable: true,
			});
		},
	}
	return {
		init: approveSpotByContractCode.init,
	}
});
