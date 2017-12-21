define(['module/manager', 'knockout', 'kendo.tooltip.min'], function (manager, ko) {

	var spot_approval = {
		configs: {
			url: {
				getAll: "Booking/Spot/" + "GetAllSpot",
			},
			columns: [],
			data: {},
			group: [
				{
					field: "broadcastDate", dir: "asc"
				},
				{
					field: "channelName", dir: "asc"
				},
				{
					field: "timeBandDescription", dir: "asc"
				},
				{
					field: "timeBandSliceDescription", dir: "asc",
				},

			],
		},
		init: function (configs) {
			var _this = spot_approval;
			$.extend(_this.configs.columns, configs.columns);
			$.extend(_this.configs.url, configs.url);
			$.extend(_this.configs.data, configs.data);
			$.extend(_this.configs.group, configs.group);
			_this.initGrid();
			_this.initBindEvent();

		},
		initGrid: function () {
			var _this = spot_approval;
			$("#grid-spot").kendoGrid({
				dataSource: {
					transport: {
						read: {
							url: _this.configs.url.getAll,
							dataType: "JSON",
							type: "GET",
							data: _this.configs.data
						}
					},
					requestStart: function (e) {
						console.time("RequestTime");
						console.time("ToDataBound");
					},
					requestEnd: function (e) {
						console.timeEnd("RequestTime");
					},
					schema: {
						model: {
							id: 'Id',
							fields: {
								broadcastDate: { field: "BroadcastDate", type: "date" },
								timeBandName: { field: "TimeBandName", type: "text" },
								timebandNameToSort: { field: "TimebandNameToSort", type: "text" },
								timeBandId: { field: "TimeBandId", type: "text" },
								timeBandSliceName: { field: "TimeBandSliceName", type: "text" },
								approveOnAir: { field: "ApproveOnAir", type: "bool" },
								positionCost: { field: "PositionCost", type: "bool" },
								position: { field: "Position", type: "number" }, 
								tmpOrder: { field: "TmpOrder", type: "number" },
								index: { field: "Index", type: "number" }, 
								assetCode: { field: "AssetCode", type: "text" },
								assetId: { field: "AssetId", type: "text" },
								assetBlockDuration: { field: "AssetBlockDuration", type: "number" }, 
								bookingAssetType: { field: "BookingAssetType", type: "number" },
								bookingTypeId: { field: "BookingTypeId", type: "number" },
								maxDuration: { field: "MaxDuration", type: "number" },
								spotId: { field: "SpotId", type: "text" },
								spotBookingId: { field: "SpotBookingId", type: "text" },
								contractCode: { field: "ContractCode", type: "text" },
								timeBandDescription: { field: "TimeBandDescription", type: "text" },
								timeBandSliceDescription: { field: "TimeBandSliceDescription", type: "text" },
								channelName: { field: "ChannelName", type: "text" },
								channelId: { field: "ChannelId", type: "text" },
								productName: { field: "ProductName", type: "text" },
							}
						},
					//	data: "Data",
					//	total: "Total"
					},
					group: _this.configs.group,
					sort: [
					//	{ field: "approveOnAir", dir: "desc" },
						{ field: "tmpOrder", dir: "asc" },
						{ field: "index", dir: "asc" },
						{ field: "position", dir: "asc" },

					],
					//	serverFiltering: true,

				},
				columns: _this.configs.columns,
			//	selectable: "single",
				dataBound: _this.onGridBound,
				resizable: true,
			//	change: onGirdspotBookingChange,
			//	groupable: true,
			//	filterable: true,
			//	sortable: true,
			//	pageable: {
					//pageSize: 2,
			//		refresh: true
			//	}

			});
		},
		onGridBound: function () {
			console.timeEnd("ToDataBound");
			console.time("GridBound");
			spotDataItems = this.dataSource.data()
			console.log(spotDataItems);
			var grid = this;

			var _this = spot_approval;
			if (SPOT_GRID_CHANGE) //
			{
				$.each(spotDataItems, function (i, spotItem) {
					var itemIndex = spot_approval.util.findRowIndex(spotItem.uid);
					spotItem.index = itemIndex; // reload index
				});
				SPOT_GRID_CHANGE = false;
			}
			spot_approval.bindEvent();

			this.table.find("tbody > tr:not(.k-grouping-row)").each(function (i, trItem) {
				var spotId = grid.dataSource.getByUid(trItem.dataset.uid).spotId;
				$(trItem).attr('data-spotid', spotId);
				$(trItem).kendoDraggable({
					hint: function (e) {
						var item = $('<div class="k-grid k-widget" style="background-color: DarkOrange; color: black;"><table><tbody><tr>' + e.html() + '</tr></tbody></table></div>');
						return item;
					},
					group: spotId,
				});

				$(trItem).kendoDropTarget({
					group: spotId,
					drop: function (e) {
						var checkbox = $(e.dropTarget[0]).find("input[type='checkbox']:checked.approveOnAir");
					//	if (!checkbox.length) // disable no approveonAir can drag
						//	return;
						var checkboxcurrentTarget = $(e.draggable.currentTarget[0]).find("input[type='checkbox']:checked.approveOnAir");
					//	if (!checkboxcurrentTarget.length) // disable no approveonAir can drag
						//	return;
						var dropTargetUid = $(e.dropTarget[0]).data('uid');
						var currentTargetUid = $(e.draggable.currentTarget[0]).data('uid');

						var grid = $("#grid-spot").data('kendoGrid');
						var dataSource = grid.dataSource;

						var dataItemDropTarget = dataSource.getByUid(dropTargetUid);						
						var dataItemCurrentTarget = dataSource.getByUid(currentTargetUid);
						var spotId = dataItemCurrentTarget.spotId;
						if (!_this.util.savedSpot(spotId)) {
							alert("Please save previous cut!");
							return false;
						}

						var dropTargetIndexOfGroup = _this.util.findRowIndex(dropTargetUid);
						var currentTargetIndexOfGroup = _this.util.findRowIndex(currentTargetUid);
						if (currentTargetIndexOfGroup > dropTargetIndexOfGroup) {

							e.dropTarget.before(e.draggable.currentTarget);
						}
						else {
							e.dropTarget.after(e.draggable.currentTarget);
						}
						_this.UI.orderPositionOnAir(spotId);
						_this.dataSource.orderTmpOrder(spotId);
						//	_this.dataSource.setIndexPositionOnAirForNonApprovedBooking(dataItemCurrentTarget.spotId);

						notification.show("Changed order");
						spot_approval.util.onUserModifiedGrid(true, spotId);
					}
				});
			});

			console.timeEnd("GridBound");

		},
		onGridChange: function (arg) {
			var grid = arg.sender;
			var selected = grid.dataItem(this.select());
		},
		util: {
			searchTree:	function (element, matchingUid) {
			if (element.uid == matchingUid) {
				return element;
			} else if (element.items != null) {
				var i;
				var result = null;
				for (i = 0; result == null && i < element.items.length; i++) {
					result = searchTree(element.items[i], matchingUid);
				}
				return result;
			}
			return null;
			},
			findRowIndex: function (rowUid) {
				var grid = $("#grid-spot").data("kendoGrid");
				var rowItem = $("tr[data-uid='" + rowUid + "']");
				var rowIndex = $("tr", grid.tbody).index(rowItem);
				var rowParentIndex = spot_approval.util.searchRowParent(rowUid);
				return rowIndex - rowParentIndex;
			},
			searchRowParent: function (rowUid) {
				var grid = $("#grid-spot").data("kendoGrid");
				var rowItem = $("tr[data-uid='" + rowUid + "']");
				var RowParent = rowItem.prevAll("tr.k-grouping-row")[0];
				var rowParentIndex = $("tr", grid.tbody).index(RowParent);
				return rowParentIndex;
			},
			searchFirstRowOfGroup: function (rowUid) {
				var grid = $("#grid-spot").data("kendoGrid");
				var rowItem = $("tr[data-uid='" + rowUid + "']");
				var RowParent = rowItem.prevAll("tr.k-grouping-row")[0];
				var nextRowParent = $(RowParent).next()[0];
				return nextRowParent;
			},
			onUserModifiedGrid: function (changed, spotId) {
				if (changed)
				{
					$("button.save[data-spotid='" + spotId + "']")
						.removeClass("btn-primary-outline")
						.removeClass("disabled")
						.addClass("btn-danger")
					;
				}
				else {
					$("button.save[data-spotid='" + spotId + "']")
						.removeClass("btn-danger")
						.addClass("btn-primary-outline")
						.addClass("disabled");
				}
			},
			savedSpot: function (spotId) {
				var saveSpotBtn = $("button.save");
				for (i = 0; i < saveSpotBtn.length; i++)
				{
					var notSaved = $(saveSpotBtn[i]).hasClass("btn-danger");
					if (saveSpotBtn[i].dataset.spotid != spotId && notSaved)
						return false;
				}
				return true;
			}
		},
		network: {
			saveSpot: function (spotId, spotBookings) {
				$.ajax({
					url: "Booking/Spot/SaveSpot",
					type: 'POST',
					data: { SpotId: spotId, spotBookings: spotBookings }

				}).done(function (response) {
					console.log(response);
					if (response.result == 'OK') {
						notification.show(response.message);
						spot_approval.util.onUserModifiedGrid(false, spotId);
						var grid = $('#grid-spot').data("kendoGrid");
						SPOT_GRID_CHANGE = false;
					//	grid.dataSource.fetch();
					//	grid.refresh();

					}
					else {
						alert(response.message);
					}
				});
			},			
			AddSpotAsset: function (spotId, spotBookings) {
				$.ajax({
					url: "Booking/Spot/AddSpotAsset",
					type: 'POST',
					data: { SpotId: spotId, spotBookings: spotBookings }

				}).done(function (response) {
					console.log(response);
					alert(response.message)
				});
			},
		},
		bindEvent: function () {
			var _this = this;
			$("button.save").off().on('click', function () {

				if ($(this).hasClass("disabled"))
					return false;

				var grid = $('#grid-spot').data("kendoGrid");
				console.log("clicked");
				var str = this.dataset.items;
				var items = $.parseJSON(str);
				console.log(items);
				var bookings = [];
				var spotId;
				$.each(items, function (i, item) {
					var spotItem = grid.dataSource.getByUid(item._uid); // get again
					if (true) {
						bookings.push({
							Id: spotItem.id,
							SpotId: spotItem.spotId,
							Index: spotItem.index,
							BookingAssetType: spotItem.bookingAssetType,
							AssetId: spotItem.assetId,
							PositionCost: spotItem.positionCost,
							IsApproved: spotItem.approveOnAir,
							TmpOrder : spotItem.tmpOrder,
						});
					}
					spotId = spotItem.spotId;
				});
				spot_approval.network.saveSpot(spotId, bookings);
			});

			$("button.download").off().on('click', function () {
				if ($(this).hasClass("disabled"))
					return false;
				var grid = $('#grid-spot').data("kendoGrid");
				console.log("clicked");
				alert("Not yet support!");
			});

			$("button.send").off().on('click', function () {
				if ($(this).hasClass("disabled"))
					return false;
				var grid = $('#grid-spot').data("kendoGrid");
				console.log("clicked");
				alert("Not yet support!");
			});
			$("button.preview").off().on('click', function () {
				if ($(this).hasClass("disabled"))
					return false;
				var grid = $('#grid-spot').data("kendoGrid");

					$("#modal .modal-content").load("Booking/Spot/Preview/" +this.dataset.spotid, function () {

						$("#modal").modal("show");
					});
			});
			
			$("input[type='checkbox'].approveOnAir").off().on('change', function () {
				console.log("checbox changed " + this.checked);
				var trItem = $(this).closest("tr[role='row']");
				var uidItem = trItem.data('uid');
				var grid = $('#grid-spot').data("kendoGrid");
				var dataItem = grid.dataSource.getByUid(uidItem);
				var spotId = dataItem.spotId;
				if (!_this.util.savedSpot(spotId))
				{
					alert("Please save previous cut!");
					return false;
				}
				dataItem.approveOnAir = this.checked;
				var itemIndex = 999;
				var approvedBookingsCount = _this.UI.countBookingApprovedOnAir(spotId);
				console.log("approvedBookingsCount: ", approvedBookingsCount);
				if (this.checked) {
					itemIndex = approvedBookingsCount;
					dataItem.index = itemIndex; 
					_this.UI.setIndexPositionOnAir(dataItem.id, itemIndex);
					_this.UI.orderPositionOnAir(spotId);

				//	_this.UI.appendBtnOrder(dataItem.id);
				//	_this.bindOrderBtnEvent();
				}
				else {
					dataItem.index = itemIndex;
					_this.UI.setIndexPositionOnAir(dataItem.id, itemIndex);
					_this.UI.orderPositionOnAir(spotId);
					_this.dataSource.setIndexPositionOnAirForNonApprovedBooking(spotId);

				//	_this.UI.clearBtnOrder(dataItem.id);
				}

				_this.UI.updateProgressBar(spotId);
				_this.dataSource.orderTmpOrder(spotId);

				spot_approval.util.onUserModifiedGrid(true, this.dataset.spotid);
			});

			$("input[type='checkbox'].positionCost").off().on('change', function () {
				console.log("checbox changed " + this.checked);
				var trItem = $(this).closest("tr[role='row']");
				var uidItem = trItem.data('uid');
				var grid = $('#grid-spot').data("kendoGrid");
				var dataItem = grid.dataSource.getByUid(uidItem);
				var spotId = dataItem.spotId;
				if (!_this.util.savedSpot(spotId)) {
					alert("Please save previous cut!");
					return false;
				}
				//var dataItem = grid.dataItem(trItem);
				dataItem.positionCost = this.checked;

				spot_approval.util.onUserModifiedGrid(true, spotId);
			});

			$("button.add-asset").off().on('click', function () {

				spot_approval.util.onUserModifiedGrid(true, this.dataset.spotid);

				$("#modal .modal-content").load("Booking/Spot/AddSpotAsset/" + this.dataset.spotid, function () {

					$("#modal").modal("show");
				});
			});
			$("button.view-template").off().on('click', function () {
				$("#modal .modal-content").load("Booking/Spot/ViewTemplate/" + this.dataset.timebandid, function () {

					$("#modal").modal("show");
				});
			});
		//	_this.bindOrderBtnEvent();
		},
		initBindEvent: function () {
			var _this = this;
			$("#context-menu").kendoContextMenu({
				//	alignToAnchor: true
				target: "#grid-spot",
				filter: "tr",
				open: function (e) {
					var grid = $("#grid-spot").data("kendoGrid");
				//	var trUid = e.target.dataset.uid;
					//var selected = grid.select();
				//	if (selected[0].dataset.uid != trUid)
					//	grid.select(e.target);
				},
				select: function (e) {
					var grid = $("#grid-spot").data("kendoGrid");
					var dataSource = grid.dataSource;
					var rowTr = e.target;
					var trUid = e.target.dataset.uid;
					var spotId = e.target.dataset.spotid;
					if (!_this.util.savedSpot(spotId)) {
						alert("Please save previous cut!");
						return false;
					}
					var dataItem = grid.dataSource.getByUid(trUid);
					var action = e.item.dataset.action;
					var prevTr = $(e.target).prev()[0];
					var nextTr = $(e.target).next()[0];
					var currentTargetUid = trUid;
					var currentTargetIndex = _this.util.findRowIndex(currentTargetUid);
					var dropTargetIndex = 0;
					var dropTargetUid = '';
					var firstRow = {};
					switch (action) {
						case "on-top":
							console.log("on-top");
							firstRow = _this.util.searchFirstRowOfGroup(currentTargetUid);
							dropTargetUid = firstRow.dataset.uid;
							break;
						case "move-up":
							console.log("move-up");
							dropTargetUid = prevTr.dataset.uid;

							break;
						case "move-down":
							console.log("move-down");
							dropTargetUid = nextTr.dataset.uid;

							break;
						case "on-bottom":
							console.log("on-bottom");

							break;
					}
					// handle event
					if (dropTargetUid) {

						var dropTargetIndexOfGroup = _this.util.findRowIndex(dropTargetUid);
						var currentTargetIndexOfGroup = _this.util.findRowIndex(currentTargetUid);

						if (currentTargetIndexOfGroup > dropTargetIndexOfGroup) {
							if (action == "on-top")
								$(firstRow).before($(rowTr));
							else
								$(prevTr).before($(rowTr));
						}
						else {
							$(nextTr).after($(rowTr));
						}
						_this.UI.orderPositionOnAir(spotId);
						_this.dataSource.orderTmpOrder(spotId);


						notification.show("Changed order");
						spot_approval.util.onUserModifiedGrid(true, spotId);
					}
					else
						alert("Can't move!");

				}
			});
		},
		bindOrderBtnEvent: function () {
			var _this = this;
			$("button.order").off().on('click', function () {
				console.log("clicked");
				var grid = $('#grid-spot').data("kendoGrid");
				var rowTr = $(this).closest('tr')[0];
				var trUid = rowTr.dataset.uid;
				var spotId = rowTr.dataset.spotid;
				var dataItem = grid.dataSource.getByUid(trUid);
				var action = this.dataset.action;
				var prevTr = $(rowTr).prev()[0];
				var nextTr = $(rowTr).next()[0];
				var currentTargetUid = trUid;
				var dropTargetIndex = 0;
				var dropTargetUid = '';
				var firstRow = {};

				switch (action) {
					case "on-top":
						console.log("on-top");
						firstRow = _this.util.searchFirstRowOfGroup(currentTargetUid);
						dropTargetUid = firstRow.dataset.uid;
						break;
					case "move-up":
						console.log("move-up");
						dropTargetUid = prevTr.dataset.uid;

						break;
					case "move-down":
						console.log("move-down");
						dropTargetUid = nextTr.dataset.uid;

						break;
					case "on-bottom":
						console.log("on-bottom");

						break;
				}
				// handle event
				if (dropTargetUid) {
					var dropTargetIndexOfGroup = _this.util.findRowIndex(dropTargetUid);
					var currentTargetIndexOfGroup = _this.util.findRowIndex(currentTargetUid);

					if (currentTargetIndexOfGroup > dropTargetIndexOfGroup) {
						if (action == "on-top")
							$(firstRow).before($(rowTr));
						else
						$(prevTr).before($(rowTr));
					}
					else {
						$(nextTr).after($(rowTr));
					}
					_this.UI.orderPositionOnAir(spotId);

					notification.show("Changed order");
					spot_approval.util.onUserModifiedGrid(true, spotId);

				}
				else
					alert("Can't move!");
			});
		},
		UI: {
			setIndexPositionOnAir: function (id, index) {
				if (index == 999)
					$(".positionOnAir." + id).html("");
				else
					$(".positionOnAir." + id).html(index.toString());
			},

			countBookingApprovedOnAir: function (spotId) {
				var result = $("tr[data-spotid=" + spotId + "]" + " " + "input[type='checkbox']:checked.approveOnAir");
				return result.length;
			},
			orderPositionOnAir: function (spotId) {
				var _this = spot_approval;
				var checkedBookings = $("tr[data-spotid=" + spotId + "]" + " " + "input[type='checkbox']:checked.approveOnAir");
				var dataItemBookings = [];
				var grid = $('#grid-spot').data("kendoGrid");
				$.each(checkedBookings, function (i, checkedBooking) {
					var trItem = $(this).closest("tr[role='row']");
					var dataItem = grid.dataSource.getByUid(trItem.data("uid"));
					dataItemBookings.push(dataItem);
				});
				var compareIndex = function (a, b) {
					var indexA = _this.util.findRowIndex(a.uid);
					var indexB = _this.util.findRowIndex(b.uid);
					if (indexA < indexA)
						return -1;
					if (indexA > indexA)
						return 1;
					return 0;
				}
			//	dataItemBookings.sort(compareIndex);

				$.each(dataItemBookings, function (i, dataItemBooking) {
					_this.dataSource.setIndexPositionOnAir(dataItemBooking.uid, i + 1);
					_this.UI.setIndexPositionOnAir(dataItemBooking.id, i + 1);
				});
				return;
			},
			appendBtnOrder: function (id) {
				$(".order-btn." + id).closest('td').html(kendo.template($("#order-btn-template").html())({ id: id, approve: true }));
			},
			clearBtnOrder: function (id) {
				$(".order-btn." + id).empty();
			},
			updateProgressBar: function (spotId) {

				var grid = $('#grid-spot').data("kendoGrid");
				var dataItems = grid.dataSource.data();
				var dataItemOfSpot = [];

				$.each(dataItems,function (i, dataItem) {
					if (dataItem.spotId == spotId)
						dataItemOfSpot.push(dataItem);
				});

				var total = 0;
				var _uids = [];
				var sliceId = "";
				var timeBandId = "";
				var maxDuration;
				$.each(dataItemOfSpot, function (i, v) {
					if (v.approveOnAir) {
						total = total + v.assetBlockDuration;
					};
					_uids.push({ _uid: v.uid });
					spotId = spotId;
					sliceId = v.timeBandSliceId;
					timeBandId = v.timeBandId;
					maxDuration = v.maxDuration;
				});
				var durationPercent = 0;
				durationPercent = Math.floor(total / maxDuration * 100);
				var progressBarClass = "progress-bar-success";
				if (durationPercent > 70 && durationPercent < 80)
					progressBarClass = "progress-bar-info";
				else if (durationPercent > 80 && durationPercent < 90)
					progressBarClass = "progress-bar-warning";
				else if (durationPercent > 90)
					progressBarClass = "progress-bar-danger";

				var progressBarTemplateRender = kendo.template($("#progress-bar-template").html())({
					progressBarClass: progressBarClass,
					totalTime: total,
					maxDuration: maxDuration,
					durationPercent: durationPercent
				});
				var progressBar = $(".progress." + spotId).html(progressBarTemplateRender);
				this.updateTotalDuration(spotId, total);
			},
			updateTotalDuration: function (spotId, duration) {
				var totalDuration = $(".total-duration." + spotId).html(duration.toString());
			},

		},
		dataSource: {
			setIndexPositionOnAir: function (uid, index) {
				var grid = $('#grid-spot').data("kendoGrid");
				var item = grid.dataSource.getByUid(uid);
				//	var dataItem = grid.dataItem(trItem);
				item.index = index;
				return;
			},
			setTmpOrder: function (uid, orderIndex) {
				var grid = $('#grid-spot').data("kendoGrid");
				var item = grid.dataSource.getByUid(uid);
				//	var dataItem = grid.dataItem(trItem);
				item.tmpOrder = orderIndex;
				return;
			},
			orderTmpOrder: function (spotId) {
				var _this = spot_approval;
				var trRowBookings = $("tr[data-spotid=" + spotId + "]");
				var dataItemBookings = [];
				var grid = $('#grid-spot').data("kendoGrid");
				$.each(trRowBookings, function (i, trRowBooking) {
					var trItem = $(this);
					var dataItem = grid.dataSource.getByUid(trItem.data("uid"));
					dataItemBookings.push(dataItem);
				});
				var compareIndex = function (a, b) {
					var indexA = _this.util.findRowIndex(a.uid);
					var indexB = _this.util.findRowIndex(b.uid);
					if (indexA < indexA)
						return -1;
					if (indexA > indexA)
						return 1;
					return 0;
				}
				//	dataItemBookings.sort(compareIndex);

				$.each(dataItemBookings, function (i, dataItemBooking) {
					_this.dataSource.setTmpOrder(dataItemBooking.uid, i + 1);
				});
				return;
			},
			setIndexPositionOnAirForNonApprovedBooking: function (spotId) {
				var _this = this;
				var grid = $('#grid-spot').data("kendoGrid");
				var uncheckedBookings = $("tr[data-spotid=" + spotId + "]" + " " + "input[type='checkbox']:unchecked.approveOnAir");

				$.each(uncheckedBookings, function (i, uncheckedBooking) {
					var trItem = $(uncheckedBooking).closest("tr[role='row']");
					var dataItem = grid.dataItem(trItem);

					_this.setIndexPositionOnAir(dataItem.uid, 999);
				});

			},
		}
	}
	return {
		init: spot_approval.init,
	}
});
