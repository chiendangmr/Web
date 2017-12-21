define(['module/manager', 'kendo.tooltip.min', 'module/search'], function (manager, _, search) {

	var timeband = {
		configs: {
			model: {},
			columns: [],
			filter: function (filterText) {
			}
		},
		init: function (configs) {

			var _this = timeband;
			$.extend(timeband.configs, configs);
			//	_this.initGrid();
			_this.initTree();
			_this.bindEvent();
			search.init(_this.configs);

		},
		initGrid: function () {
			var _this = timeband;
			$("#grid-time-band").kendoGrid({
				dataSource: {
					transport: {
						read: {
							url: "Manager/TimeBand/GetAllTimeBand",
							dataType: "JSON",
							type: "GET"
						}
					},
					schema: {
						model: timeband.configs.model,
						data: "Data",
						total: "Total",
					},
					error: function (e) {
						//TODO: handle the errors
						alert(e.xhr.responseText);
					},
					group: { field: "channelName" },
					serverSorting: true,
					serverFiltering: true,
					type: "aspnetmvc-ajax",
					sort: { field: "nameForSort", dir: "desc" },
				},
				columns: timeband.configs.columns,
				selectable: "single",
				groupable: true,
				sortable: true,
				resizable: true,
				dataBound: _this.onBound,
				change: _this.onChange,

				});

		},
		initTree: function () {
			var _this = timeband;
			$("#grid-time-band").kendoTreeList({
				dataSource: {
					transport: {
						read: {
							url: "Manager/TimeBand/GetAllTimeBand",
							dataType: "JSON",
							type: "GET"
						}
					},
					schema: {
						model: timeband.configs.model,
						data: "Data",
						total: "Total",
					},
					error: function (e) {
						//TODO: handle the errors
						alert(e.xhr.responseText);
					},
				//	group: { field: "channelName" },
					serverSorting: true,
					serverFiltering: true,
					type: "aspnetmvc-ajax",
					sort: { field: "nameForSort", dir: "asc" },
				},
				columns: timeband.configs.columns,
				selectable: "single",
			//	groupable: true,
				sortable: true,
				resizable: true,
				dataBound: _this.onBound,
				change: _this.onChange,
				settings: {
					selectFirstRow: true,
					dataItemId: '',
				},

			});

		},
		onBound: function () {
			var treeList = this;
			var rows = $("tr.k-treelist-group", treeList.tbody);
			$.each(rows, function (idx, row) {
				treeList.expand(row);
			});

			var tree = this;
			var dataItems = tree.dataSource.data();
			console.log("dataItems: ", dataItems);

			if (tree.options.settings.dataItemId != '') {
				for (i = 0; i < dataItems.length; i++) {
					var dataItem = dataItems[i];
					if (dataItem.id == tree.options.settings.dataItemId) {
						tree.select($("tr[data-uid='" + dataItem.uid + "']"));
						break;
					}
				}
			}
			else
				if (tree.dataSource.at(0) && tree.options.settings.selectFirstRow || dataItems.length == 1) {
					var uid = tree.dataSource.at(0).uid;
					tree.select($("tr[data-uid='" + uid + "']"));
				}

			tree.options.settings.dataItemId = ''; // reset

			$("button.edit.timeband").bind("click", function () {
				$("#modal .modal-content").load("Manager/TimeBand" + "/Edit/" + this.dataset.id, function () {

					$("#modal").modal("show");
				});
			});
			$("button.delete.timeband").bind("click", function () {
				$("#modal .modal-content").load("Manager/TimeBand" + "/Delete/" + this.dataset.id, function () {

					$("#modal").modal("show");
				});
			});
			$("button.detail.timeband").bind("click", function () {

				location.replace(location.href + "/Detail/" + this.dataset.id);
			});


			var tooltip = $(".day-of-week").kendoTooltip({
				//	filter: "span",
				width: 500,
				height: 80,
				position: "top",
				content: function (e) {
					//	debugger;
					var target = e.target; // the element for which the tooltip is shown
					var dayOfWeekInt = target[0].dataset.dayofweek;
					var dayOfWeek = intToDayOfWeek(dayOfWeekInt);
					return kendo.template($("#dayOfWeeks-tooltip-template").html())({
						dayOfWeek: dayOfWeek
					}); // set the element text as content of the tooltip
				}
			});
			var endTimetooltip = $(".endTime").kendoTooltip({
				//	filter: "span",
				width: 200,
				height: 60,
				position: "top",
				content: function (e) {
					//	debugger;
					var target = e.target; // the element for which the tooltip is shown
					return target[0].dataset.tooltip;
				}
			});


		},
		onChange: function (arg) {
			var grid = arg.sender;
			var selected = grid.dataItem(this.select());
			if (selected)
			{
				$("#timeBandDetailPanel").load("Manager/TimeBand/" + "Detail/" + selected.id);
			}
			//	$("#timebandslice").load("Manager/TimeBandSlice/" + "Index/" + selected.id);
		},
		bindEvent: function () {

			$("#btn-add-timeband").bind("click", function () {
				$("#modal .modal-content").load("Manager/TimeBand/Create", function () {

					$("#modal").modal("show");
				});
			});
		},
	}
	return {
		init: timeband.init,
	}
});
