define(['module/manager'], function (manager) {

	var TVCReportByBlockDurationForCustomer = {
		configs: {
			columns: [],
			model: {},
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			var _this = TVCReportByBlockDurationForCustomer;
			$.extend(_this.configs, configs);
			_this.initGrid();
			//	makeGrid.init(configs);
		},
		initGrid: function () {
			var _this = TVCReportByBlockDurationForCustomer;
			$("#grid").kendoGrid({
				dataSource: {
					transport: {
						read: {
							url: 'Report/TVCReportByBlockDurationForCustomer/GetAllSpot'
						}
					},
					group: [
						{
							field: "ContractCode", dir: "desc"
						},
						{
							field: "TimeBandName", dir: "asc"
						},
						{
							field: "RateCard", dir: "asc",
						},
					],
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
				sortable: true,
				resizable: true,
				groupable: true,
			});
		},
	}
	return {
		init: TVCReportByBlockDurationForCustomer.init,
	}
});
