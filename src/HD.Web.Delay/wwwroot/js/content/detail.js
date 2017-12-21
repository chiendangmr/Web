define(['module/manager', 'kendo.all.min'], function (manager) {
        
    var contentDetail = {
        configs: {
            contentId: "",
            contentTypeId: "35A26283-44B2-E711-8446-00155D0A2E00",
            contentName:""
        },
        init: function (configs) {
            var _this = contentDetail;
            $.extend(_this.configs, configs);
            _this.bindEvent();
        },
        bindEvent() {
            $("#upload-btn").off().on('click', contentDetail.upload);            
            $("#preview-btn").off().on('click', contentDetail.previewAndApprove);            
            $("#delete-btn").off().on('click', contentDetail.delete);
            $("#create-btn").off().on('click', contentDetail.create);
            $("#edit-btn").off().on('click', contentDetail.edit); 
            $("#viewdoc-btn").off().on('click', contentDetail.viewdoc);
        },
        upload: function () {
            var _this = contentDetail;            
            var hdstationWebComponentsUploadWindow;
            function InitUpload(id) {
                function Monitor(condition, callback, timeout, timedoutCallback) {
                    var start = new Date();
                    var monitor = setInterval(function () {
                        if (condition()) {
                            clearInterval(monitor);
                            callback();
                        } else if (new Date() - start > timeout) {
                            clearInterval(monitor);
                            if (typeof timedoutCallback == "function") timedoutCallback();
                        }
                    }, 50);
                }
                hdstationWebComponentsUploadWindow = window.open(null, "hdstationWebComponentsUploadWindow", "location=0,width=900,height=610");
                if (hdstationWebComponentsUploadWindow == null) {
                    alert('@Localizer["Cannot open the upload manager window"]');
                    return;
                }
                if (hdstationWebComponentsUploadWindow.document.location.origin != "null") {
                    if (typeof hdstationWebComponentsUploadWindow.OpenInit == "function") {
                        hdstationWebComponentsUploadWindow.OpenInit(id);
                    }
                } else {
                    hdstationWebComponentsUploadWindow = window.open("/MediaAssets/Upload/Upload", "hdstationWebComponentsUploadWindow");
                    $(hdstationWebComponentsUploadWindow).ready(function (event) {
                        Monitor(
                            function () {
                                return typeof hdstationWebComponentsUploadWindow.OpenInit == "function";
                            },
                            function () { hdstationWebComponentsUploadWindow.OpenInit(id); },
                            15000,
                            function () { alert('@Localizer["Error occurred when open upload"]') }
                        );
                    }, true);
                    console.log("open new");
                }

            }
            InitUpload(_this.configs.contentId);
        },   
        viewdoc: function () {
            var width = window.innerWidth;
            var height = window.innerHeight;
            var _this = contentDetail;
            var previewWindow = $("#viewdocWindow").kendoWindow({
                width: width - 500,
                height: height - 100,
                title: _this.configs.viewDocWindowName,                
                content: { url: "/MAM/Content/ViewDoc", data: { ContentId: _this.configs.contentId, contentTypeId: _this.configs.contentTypeId } },
                modal: true,
                deactivate: function () {
                    this.destroy();
                    $("#detail-partial").append("<div id='viewdocWindow'></div>");
                }
            }).data("kendoWindow").center().open();            
        },
        previewAndApprove: function () {
            var width = window.innerWidth;
            var height = window.innerHeight;
            var _this = contentDetail;
            var previewWindow = $("#previewWindow").kendoWindow({
                width: width-300,
                height: height-100,
                title: _this.configs.previewWindowName,
                content: { url: "/MAM/Content/PreviewAndApprove", data: { contentId: _this.configs.contentId } },
                modal: true,
                deactivate: function () {
                    this.destroy();
                    $("#detail-partial").append("<div id='previewWindow'></div>");
                }
            }).data("kendoWindow").center().open();
        },
        delete: function () {
            if (confirm("Are you sure to delete this item?")) {
                $.ajax(
                    {
                        type: 'POST',
                        url: '/MAM/Content/Delete',
                        dataType: 'json',
                        data: { id: contentDetail.configs.contentId },
                        success: function (response) {
                            console.log(response);
                            if (typeof response === 'object') {
                                if (response.result === "OK") {
                                    $("#modal").modal("hide");
                                    notification.show(response.message);
                                    setTimeout(function () {
                                        if ($(".k-grid").data('kendoGrid')) {
                                            $(".k-grid").data('kendoGrid').dataSource.read();
                                        }
                                        else {
                                            $(".k-treelist").data('kendoTreeList').dataSource.read();
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
                    });
            };
        },
        create: function () {            
        	$("#detail-partial").load("/MAM/Content/Create?lastContentId=" + contentDetail.configs.contentId, function () {
        		$("#detail-partial").animate({ opacity: 0.1 }, 0).animate({ opacity: 1 }, 200);
        	});
        },
        edit: function () {
        	$("#detail-partial").load("/MAM/Content/Edit/" + contentDetail.configs.contentId, function () {
        		$("#detail-partial").animate({ opacity: 0.1 }, 0).animate({ opacity: 1 }, 200);
        	})
        }
    }
    return {
        init: contentDetail.init,
    }
});
