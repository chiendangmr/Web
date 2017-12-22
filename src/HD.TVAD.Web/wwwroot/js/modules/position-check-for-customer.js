﻿define(['module/manager'], function (manager) {

	var positionCheckForCustomer = {
		configs: {
			url: "",
			columns: [],
			model: {},
		},
		init: function (configs) {
			var makeGrid = manager.common.makeGrid;
			var _this = positionCheckForCustomer;
			$.extend(_this.configs, configs);
			_this.initGrid();
		//	makeGrid.init(configs);
		},
		initGrid: function () {
			var _this = positionCheckForCustomer;
			$("#grid").kendoGrid({
				dataSource: {
					transport: {
						read: {
							url: _this.configs.url,
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
				groupable: true,
				dataBound: _this.onDataBound,
			});
		},
		onDataBound: function () {

			$('input.header[type="checkbox"]').off().on('change', function (e) {
				console.log(e);
				var checked = e.target.checked;
				$('input.booking[type="checkbox"]').each(function (i, v) {
					v.checked = checked;
				});
			});
		},
	}
	return {
		init: positionCheckForCustomer.init,
	}
});