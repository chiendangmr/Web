function userGroupContentReady(e) {
    var dataGrid = e.component;
    dataGrid.columnOption("command:edit", {
        visibleIndex: -1,
        width: 120
    });
}

function userGroupCellPrepared(e) {
    if (e.rowType === "data" && e.column.command === "edit") {
        var isEditing = e.row.isEditing,
            $links = e.cellElement.find(".dx-link");

        $links.text("");

        if (isEditing) {
            $links.filter(".dx-link-save").addClass("dx-icon-save");
            $links.filter(".dx-link-cancel").addClass("dx-icon-revert");
        } else {
            $links.filter(".dx-link-add").addClass("dx-icon-add");
            if (e.row.level > 0) {
                $links.filter(".dx-link-edit").addClass("dx-icon-edit");
                $links.filter(".dx-link-delete").addClass("dx-icon-trash");
            }
            else {
                $links.filter(".dx-link-edit").remove();
                $links.filter(".dx-link-delete").remove();
            }
        }
    }
    else if (e.rowType === "header") {
        $links = e.cellElement.filter(".dx-treelist-action");
        $links.css("text-align", "center");
    }
}

function getTreeUserGroup() {
    return $("#treeUserGroup").dxTreeList("instance");
}

function getTreePermission() {
    return $("#treePermission").dxTreeList("instance");
}

function getButtonSavePermission() {
    return $("#btnSavePermission").dxButton("instance");
}

var getPermissions = {
    load: function () {
        var groupId = null;
        if (getTreeUserGroup().getSelectedRowsData().length > 0)
            groupId = getTreeUserGroup().getSelectedRowsData()[0].Id;

        if (!groupId)
            return [];

        return $.ajax({
            type: 'GET',
            url: '/Manager/UserGroup/GetPermissionsCanSetForGroup',
            contentType: "application/json; charset=utf-8",
            data: { groupId: groupId },
            dataType: "json",
            error: function (e) { DevExpress.ui.notify("Không lấy được các quyền của nhóm được chọn"); }
        });
    }
}

function getPermissionCheck(permissionNode, permissionIds) {
    var permissionId = permissionNode.key;
    var rowIndex = getTreePermission().getRowIndexByKey(permissionId);
    if (getTreePermission().cellValue(rowIndex, 0)) {
        permissionIds.push(permissionId);

        for (var i = 0; i < permissionNode.children.length; i++) {
            var currentNode = permissionNode.children[i];
            getPermissionCheck(currentNode, permissionIds)
        }
    }
}

function savePermission(data) {
    if (getTreeUserGroup().getSelectedRowsData().length == 0)
        DevExpress.ui.notify("Chưa chọn nhóm cần sửa quyền");
    else {
        var group = getTreeUserGroup().getSelectedRowsData()[0];

        if (!group.ParentId) {
            DevExpress.ui.notify("Bạn không thể sửa quyền của nhóm của bạn.<br/>Hãy liên hệ với người quản lý cấp trên.");
        }
        else {
            var permissionIds = [];

            for (var i = 0; i < getTreePermission().getRootNode().children.length; i++) {
                var currentNode = getTreePermission().getRootNode().children[i];
                getPermissionCheck(currentNode, permissionIds)
            }

            $.ajax({
                type: 'POST',
                url: '/Manager/UserGroup/SetPermissionForGroup',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: JSON.stringify({
                    groupId: group.Id,
                    permissionIds: JSON.stringify(permissionIds)
                }),
                success: function (e) {
                    DevExpress.ui.notify("Cập nhật quyền thành công");
                    getTreePermission().cancelEditData();
                    getTreePermission().refresh();
                },
                error: function (e) {
                    DevExpress.ui.notify("Không cập nhật được quyền: " + e);
                }
            })
        }
    }
}