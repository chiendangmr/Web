define(['jquery','blockUI', 'kendo.core.min', 'kendo.aspnetmvc.min', 'kendo.grid.min', 'kendo.treelist.min', 'kendo.notification.min'], function () {

    //	$.validator.setDefaults({ ignore: [] }); // Enable validation for hidden fields

    $.ajaxSetup({
        timeout: 10000,
        error: function (event, request, settings) {
            //debugger;
            switch (event.status) {
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
        }
    });
    //$.blockUI.defaults.fadeOut = 200;
    //$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

    $('#modal').on('shown.bs.modal', function () {
        $('#Name').focus();
    });
    $('#modal').on('shown.bs.modal', function () {
        $('#Length').focus();
    });
    $('#modal').on('shown.bs.modal', function () {
        $('#Rate').focus();
    });
    notification = $("#notification").kendoNotification({
        width: "12em",
        //templates: [{
        //	type: "time",
        //		template: "<div style='padding: .6em 1em'>Time is: <span class='timeWrap'>#: time #</span></div>"
        //	}]
    }).data("kendoNotification");

    var settings;
    var manager = {
        configs: {},
        init: function (configs) {
            $.extend(manager.configs, configs);

        },
        common: {
            submitForm: {
                configs: {
                    formId: '',
                    responseCallback: function (response) {
                        console.log(response);
                        if (typeof response == 'object') {
                            if (response.result == "OK") {
                                $("#modal").modal("hide");
                                notification.show(response.message);
                                setTimeout(function () {
                                	var grid = $(".k-grid").data('kendoGrid');
                                	if (grid) {
                                		if (response.id != "00000000-0000-0000-0000-000000000000")
                                			grid.options.settings.dataItemId = response.id;
                                		else
                                		if (response.data)
                                			grid.options.settings.dataItemId = response.data.Id;

                                		grid.dataSource.read();
                                	}
                                	var tree = $(".k-treelist").data('kendoTreeList');
                                	if (tree)
                                	{
                                		if (response.id != "00000000-0000-0000-0000-000000000000")
                                			tree.options.settings.dataItemId = response.id;
                                		else
                                		if (response.data)
                                			tree.options.settings.dataItemId = response.data.Id;

                                		tree.dataSource.read();
                                	}
                                }, 300);
                            }
                            else {
                                alert(response.message);
                            }
                        }
                        else {
                            alert(response);
                        }
                    }
                },
                init: function (configs) {
                    var _this = manager.common.submitForm;
                    $.extend(_this.configs, configs);
                    _this.parseValidate(_this.configs.formId);
                    _this.bindEvents(_this.configs.formId);
                },
                bindEvents: function (formId) {
                    $('#' + formId).off().on('submit', this.submit);
                },
                parseValidate: function (formId) {
                    var form = $("#" + formId);
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);
                },
                submit: function (e) {
                    //	e.preventDefault;
                    var form = $(this);

                    if (form.valid()) {
                        $.ajax({
                            url: $(this).attr("action"),
                            type: $(this).attr('method'),
                            data: $(this).serialize(),
                            success: manager.common.submitForm.configs.responseCallback,
                            statusCode: {
                                404: function () {
                                    alert("page not found");
                                },
                                401: function () {
                                    //	alert("Session timeout, please login again!");
                                    //	var returnUrl = location.origin + "/Home/Auth/LogIn?ReturnUrl=" + location.pathname;
                                    //	location.replace(returnUrl);
                                }
                            }
                        });
                    }
                    else {
                        //	alert("Try again please!");
                    }
                    return false;
                },
            },
            makeGrid: {
                configs: {
                    url: {
                        area: "Manager",
                        controller: "Home",
                        getAll: "GetAll",
                        delete: "Delete",
                        create: "Create",
                        edit: "Edit",
                        viewEvidence: "ViewEvidence",
                        id: ""
                    },
                    function: {
                        onChange: function () {

                        },
                        detailInit: null,
                        customOnBound: function (e) {

                        },
                    },
                    DOMid: {
                        grid: 'grid',
                        editTemplate: 'edit-template'
                    },
                    DOMclass: {
                        entity: "",
                        delete: ".delete",
                        create: ".create",
                        edit: ".edit",
                        viewEvidence: ".viewEvidence"
                    },
                    model: {
                        id: 'Id',
                        fields: {

                        }

                    },
                    data: {},
                    columns: [],
                    group: [],
					sort: [],
                    settings: {
                    	selectFirstRow: true,
                    	groupable: false,
                    	dataItemId: "",
                    	serverSorting: false,
                    }
                },
                init: function (configs) {
                    console.log("This in makeGrid.init: ", this);
                    var _this = manager.common.makeGrid;
                    $.extend(_this.configs.url, configs.url);
                    $.extend(_this.configs.columns, configs.columns);
                    $.extend(_this.configs.DOMid, configs.DOMid);
                    $.extend(_this.configs.DOMclass, configs.DOMclass);
                    $.extend(_this.configs.function, configs.function);
                    $.extend(_this.configs.data, configs.data);
                    $.extend(_this.configs.model, configs.model);
                    $.extend(_this.configs.group, configs.group);
                    $.extend(_this.configs.sort, configs.sort);
                    $.extend(_this.configs.settings, configs.settings);
                    _this.initGrid();
                    _this.bindCreateButtonClick();
                    _this.configs.function.detailInit = function () { }; // clear after init 
                    _this.configs.function.onChange = function () { };
                },
                initGrid: function () {
                    var _this = this;
                    var url = _this.configs.url;
                    var DOMid = _this.configs.DOMid;
                    var DOMclass = manager.common.makeGrid.configs.DOMclass;
                    $("#" + DOMid.grid).kendoGrid({
                        dataSource: {
                            transport: {
                                read: {
                                    url: url.area + '/' + url.controller + '/' + url.getAll,
                                    dataType: "JSON",
                                    type: "GET",
                                    data: _this.configs.data
                                }
                            },
                            schema: {
                                model: _this.configs.model,
                                data: "Data",
                                total: "Total"
                            },
                            serverGrouping: true,
                            serverPaging: true,
                            serverSorting: _this.configs.settings.serverSorting,
                            serverFiltering: true,
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
                            group: _this.configs.group,
                            sort: _this.configs.sort
                        },
                        detailInit: _this.configs.function.detailInit,
                        columns: _this.configs.columns,
                        dataBound: _this.onGirdBound,
                        change: _this.configs.function.onChange,
                        selectable: 'single',

                        pageable: {
                        	pageSize: 10,
                        	pageSizes: [10, 20, 50, 100, 1000, 10000],
                        	refresh: true
                        },
                        sortable: true,
                        resizable: true,
						groupable: _this.configs.settings.groupable,
                        //		filterable: true,
                        //	navigatable: true,
                        link: {
                            create: url.area + '/' + url.controller + '/' + url.create + '/' + url.id,
                            delete: url.area + '/' + url.controller + '/' + url.delete,
                            edit: url.area + '/' + url.controller + '/' + url.edit,
                            viewEvidence: url.area + '/' + url.controller + '/' + url.viewEvidence,
                            entity: DOMclass.entity,
                        },
                        settings: {
                        	selectFirstRow: _this.configs.settings.selectFirstRow,
                        	dataItemId: _this.configs.settings.dataItemId,
                        },
                        noRecords: {
                            template: "No data available"
                        },

                    });

                    _this.configs.columns = [];
                },
                onGirdBound: function () {
                	var grid = this;
                	var dataItems = grid.dataSource.data();
                	console.log("dataItems: ", dataItems);
                	if (grid.options.settings.dataItemId != '') {
                		for (i = 0; i < dataItems.length; i++)
                		{
                			var dataItem = dataItems[i];
                			if (dataItem.id == grid.options.settings.dataItemId)
                			{
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

                    $("button.delete" + grid.options.link.entity).bind("click", function (e) {
                        if ($(this).hasClass("disabled")) {
                            return false;
                        }
                        $("#modal .modal-content").load(grid.options.link.delete + '/' + this.dataset.id, function (response, status, xhr) {
                            if (status == 'success') {
                                $("#modal .modal-content").html(response);
                                $("#modal").modal("show");
                            }
                        });
                    });

                    $("button.edit" + grid.options.link.entity).bind("click", function (e) {
                        if ($(this).hasClass("disabled")) {
                            return false;
                        }
                        $.get(grid.options.link.edit + '/' + this.dataset.id, function (response, status, xhr) {
                            if (status == 'success') {
                                $("#modal .modal-content").html(response);
                                $("#modal").modal("show");
                            }
                        });
                    });

                    $("button.viewEvidence" + grid.options.link.entity).bind("click", function (e) {
                        if ($(this).hasClass("disabled")) {
                            return false;
                        }
                        var viewEvidenceWindow = $("#viewEvidenceWindow").kendoWindow({
                            width: "800px",
                            height: "600px",
                            title: "View Booked Evidence",
                            content: {
                                url: "/Manager/SpotBooking/ViewEvidence", data: { spotBookingId: this.dataset.id }
                            },
                            modal: true,
                            deactivate: function () {
                                this.destroy();
                                $("#div-annexDetail").append("<div id='viewEvidenceWindow'></div>");
                            }
                        }).data("kendoWindow").center().open();
                        //$.get(grid.options.link.viewEvidence + '/' + this.dataset.id, function (response, status, xhr) {
                        //    if (status == 'success') {
                        //        $("#modal .modal-content").html(response);
                        //        $("#modal").modal("show");
                        //    }
                        //});
                    });

                    //$("#context-menu").kendoContextMenu({
                    //    target: "tr",
                    //    //	alignToAnchor: true
                    //    select: function (e) {
                    //        var trUid = e.target.dataset.uid;
                    //        var dataItem = grid.dataSource.getByUid(trUid);
                    //        var action = e.item.dataset.action;
                    //        switch (action) {
                    //            case "edit":
                    //                $.get(grid.options.link.edit + '/' + dataItem.id, function (response, status, xhr) {
                    //                    if (status == 'success') {
                    //                        $("#modal .modal-content").html(response);
                    //                        $("#modal").modal("show");
                    //                    }
                    //                });
                    //                break;
                    //            case "delete":
                    //                $("#modal .modal-content").load(grid.options.link.delete + '/' + dataItem.id, function (response, status, xhr) {
                    //                    if (status == 'success') {
                    //                        $("#modal .modal-content").html(response);
                    //                        $("#modal").modal("show");
                    //                    }
                    //                });
                    //                break;

                    //        }
                    //        // handle event
                    //    }
                    //});

                    var _this = manager.common.makeGrid;

                    _this.configs.function.customOnBound(grid);
               //     _this.configs.function.customOnBound = function () { }; // reset
                    _this.configs.data = {}; // reset
                    grid.options.settings.dataItemId = ''; // reset
                },
                bindCreateButtonClick: function () {

                    var url = manager.common.makeGrid.configs.url;
                    var DOMclass = manager.common.makeGrid.configs.DOMclass;
                    var link = url.area + '/' + url.controller + '/' + url.create + '/' + url.id;
                    var domSelect = "button" + DOMclass.create + DOMclass.entity;

                    $(domSelect).attr('data-link', link).bind("click", function () {
                    	if ($(this).hasClass("disabled")) {
                    		return false;
                    	}
                        $("#modal .modal-content").load(this.dataset.link, function () {

                            $("#modal").modal("show");
                        });
                    });

                },
            },
            makeTreeList: {
                configs: {
                    url: {
                        area: "Manager",
                        controller: "Home",
                        getAll: "GetAll",
                        delete: "Delete",
                        create: "Create",
                        edit: "Edit",
                    },
                    DOMid: {
                        grid: 'tree-list',
                        editTemplate: 'edit-template'
                    },
                    DOMclass: {
                        delete: "delete",
                        create: "create",
                        edit: "edit",
                    },
                    columns: [],
                    model: {
                        id: 'Id',
                        parentId: 'ParentId',
                        fields: {
                            ParentId: { field: "ParentId", nullable: true }
                        }

                    },
                    settings: {
                    	selectFirstRow: true,
                    	dataItemId: "",
                    },
                    sort: [],
                    function: {
                    	onChange: function () {

                    	},
                    	detailInit: null,
                    	customOnBound: function (e) {

                    	},
                    },
                },
                init: function (configs) {
                    console.log("This in makeGrid.init: ", this);
                    var _this = manager.common.makeTreeList;
                    $.extend(_this.configs.url, configs.url);
                    $.extend(_this.configs.columns, configs.columns);
                    $.extend(_this.configs.DOMid, configs.DOMid);
                    $.extend(_this.configs.model, configs.model);
                    $.extend(_this.configs.sort, configs.sort);
                    $.extend(_this.configs.function, configs.function);

                    _this.initTree();
                    _this.bindCreateButtonClick();

                    _this.configs.function.onChange = function () { }; // clean affter init
                },
                initTree: function () {
                    var _this = this;
                    var url = _this.configs.url;
                    var DOMid = _this.configs.DOMid
                    $("#" + DOMid.grid).kendoTreeList({
                        dataSource: {
                            transport: {
                                read: {
                                    url: url.area + '/' + url.controller + '/' + url.getAll,
                                    dataType: "JSON",
                                    type: "GET"
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
                            sort: _this.configs.sort
                        },
                        columns: _this.configs.columns,
                        dataBound: _this.onBound,
                        change: _this.configs.function.onChange,
                        selectable: 'single',

                        pageable: {
                            pageSize: 2
                        },
                        sortable: true,
                        resizable: true,
                        settings: {
                        	selectFirstRow: _this.configs.settings.selectFirstRow,
                        	dataItemId: _this.configs.settings.dataItemId,
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

                    var url = manager.common.makeTreeList.configs.url;

                    $("button.delete").bind("click", function () {
                        if ($(this).hasClass("disabled")) {
                            return false;
                        }
                        $("#modal .modal-content").load(url.area + '/' + url.controller + '/' + url.delete + '/' + this.dataset.id, function (response, status, xhr) {

                            if (status == 'success') {
                                $("#modal .modal-content").html(response);
                                $("#modal").modal("show");
                            }
                        });
                    });

                    $("button.edit").bind("click", function () {
                        if ($(this).hasClass("disabled")) {
                            return false;
                        }
                        $.get(url.area + '/' + url.controller + '/' + url.edit + '/' + this.dataset.id, function (response, status, xhr) {
                            if (status == 'success') {
                                $("#modal .modal-content").html(response);
                                $("#modal").modal("show");
                            }
                        });
                    });


                },
                bindCreateButtonClick: function () {

                    var url = manager.common.makeTreeList.configs.url;

                    $("button.create").bind("click", function () {
                        $("#modal .modal-content").load(url.area + '/' + url.controller + '/' + url.create + '/', function () {

                            $("#modal").modal("show");
                        });
                    });

                },
            }
        }
    };
    return {
        common: manager.common
    }
});
