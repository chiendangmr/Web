define(['module/manager'], function (manager) {

	var assetUpload = {
		configs: {
			assetId: "",
			fileTypeId: 0,
		},
		init: function (configs) {
			var _this = assetUpload;
			$.extend(_this.configs, configs);

			_this.makeGrid();
			_this.initHidden();
			_this.bindEvent();
		},
		makeGrid: function () {
			$("#gridFileUpload").kendoGrid({
				batch: true,
				height: "500px",
				dataSource: assetUpload.gridFileUploadDataSource(),
				columns: [
					{ field: "assetName", title: "Asset Name" },
					{ field: "version", title: "Version" },
					{ field: "active", title: "Active" },
					{ field: "createTime", format: "{0: yyyy-MM-dd}", title: "Create Time" }
				],
				pageable: true
			}).data("kendoGrid");
		},
		gridFileUploadDataSource: function () {
			return {
				type: "aspnetmvc-ajax",
				transport: {
					read: {
						type: "GET",
						url: '/MAM/Content/GetAllVersion',
						dataType: 'json',
						data: { AssetId: assetUpload.configs.assetId }
					}
				},
				pageSize: 20,
				schema: {
					type: "json",
					model: {
						id: "id",
						fields: {
							assetName: { type: "string" },
							version: { type: "string" },
							active: { type: "boolean" },
							createTime: { type: "date" }
						}
					}
				}
			};
		},
		initHidden: function () {
			if (assetUpload.configs.fileTypeId !== 4) {
				$("#TextContent").prop("readonly", true);
			}
			else {
				$("#Files").prop("disabled", true);    }    
		},
		bindEvent: function () {
			$("#btnCloseFileUploadWindow").click(function (e) {
				e.preventDefault();
				$(this).closest(".k-window-content").data("kendoWindow").close();
			});
		},
	}
	return {
		init: assetUpload.init,
	}
});
