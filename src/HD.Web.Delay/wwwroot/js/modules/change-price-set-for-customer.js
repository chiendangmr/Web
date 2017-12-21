define(['module/manager'], function (manager) {

	var changePriceSetForCustomer = {
		configs: {
			url: "",
			group: {},
			columns: [],
			model: {},
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			var _this = changePriceSetForCustomer;
			$.extend(_this.configs, configs);
			_this.initGrid();
			//	makeGrid.init(configs);
		},
		initGrid: function () {
			var _this = changePriceSetForCustomer;
			$("#grid").kendoGrid({
				dataSource: {
					transport: {
						read: {
							url: _this.configs.url,
						}
					},
					group: _this.configs.group,
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
				//pageable: {
				//	pageSize: 10,
				//	pageSizes: [10, 20, 50, 100, 1000, 10000],
				//	refresh: true
				//},
				sortable: true,
				resizable: true,
			});
		},
	}
	return {
		init: changePriceSetForCustomer.init,
	}
});
