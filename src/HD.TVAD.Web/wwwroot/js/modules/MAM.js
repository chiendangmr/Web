define(['jquery','kendo.all.min'], function () {
    var MAM = {
    	configs: {
    		columns: [],
    		settings: {
    			selectFirstRow: true,
    			dataItemId: "",
    		}
    	},
        init: function (configs) {
            //console.log(this);
            var _this = MAM;
            $.extend(_this.configs, configs)
            $.extend(_this.configs.settings, configs.settings);
            _this.initGrid();
            _this.bindEvents();
        },
        initGrid: function () {
        	var _this = MAM;
            $("#asset-grid").kendoGrid({
            	dataSource: {
            		transport: {
            			read: {
            				url: "MAM/Content/GetAllAssetForGrid",
            				dataType: "JSON",
            				type: "GET"
            			}
            		},
            		schema: {
            			model: {
            				id: 'Id',
            				fields: {      
            					Code:{type:"string"},
            					BlockDuration: { type: "number" },
            					CreateTime: { type: "date" },
            					Approve: { type: "bool" },
            					ApproveEndDate: { type: "date" },                             
            				}
            			},
            			data: "Data",
            			total: "Total"
            		},                    
            		serverPaging: true,
            		serverFiltering: true,                    
            		serverSorting: true,
            		type: "aspnetmvc-ajax",
            		error: function (e) {
            			switch (e.xhr.status) {
            				case 401: // unauthorize
            					alert("Session timeout, please login again!");
            					var returnUrl = location.origin + "/Home/Auth/LogIn?ReturnUrl=" + location.pathname;
            					location.replace(returnUrl);
            					break;
            				case 500: // inner server error
            					alert("Internal Server Error");
            					break;
            				case 404: // Not Found
            					alert("Not Found");
            					break;
            				case 403: // unauthenticaion
            					alert("Not have perrmission");
            					break;
            			}
            		},
            		sort: [
						{
							field: "CreateTime", dir : "desc"
            		}]
                },
                columns: _this.configs.columns,
                selectable: "single",
                dataBound: _this.onGirdBound,
                change: _this.onGirdChange,
                sortable: {
                    mode: "multiple",
                    allowUnsort: true,
                    showIndexes: true
                },
                resizable: true,
                filterable: {
                    mode: "row"                    
                },                
                pageable: {
                    pageSize: 20,
                    refresh: true,
                    pageSizes: [10, 15, 20, 25, 30, 50],
                    buttonCount: 5
                },
                settings: {
                	selectFirstRow: _this.configs.settings.selectFirstRow,
                	dataItemId: _this.configs.settings.dataItemId,
                },
            });

        },
        onGirdBound: function () {
        	var grid = this;
        	var dataItems = grid.dataSource.data();
        	console.log("dataItems: ", dataItems);
        	if (grid.options.settings.dataItemId != '') {
        		for (i = 0; i < dataItems.length; i++) {
        			var dataItem = dataItems[i];
        			if (dataItem.id == grid.options.settings.dataItemId) {
        				grid.select("tr[data-uid='" + dataItem.uid + "']");
        				break;
        			}
        		}
        	}
        	else
        		if (grid.dataSource.at(0) && grid.options.settings.selectFirstRow || dataItems.length == 1) {
        			var uid = grid.dataSource.at(0).uid;
        			grid.select("tr[data-uid='" + uid + "']");
        		}

        	grid.options.settings.dataItemId = ''; // clear
        },
        onGirdChange: function (arg) {
            var grid = arg.sender;
            var selected = grid.dataItem(this.select());
            $("#detail-partial").load("MAM/Content/" + "Detail/" + selected.Id, function () {
            	$("#detail-partial").animate({ opacity: 0.1 }, 0).animate({ opacity: 1 }, 200);
            });
        },
        bindEvents: function () {

        }
    };
    return {
        init: MAM.init
    };
});