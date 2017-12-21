using HD.TVAD.Entities.Context;
using HD.TVAD.Entities.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.StartData
{
    public enum UserPermissions
    {


		[Display(Name = "Quyền nhập dữ liệu")]
		ImportData,

		[Display(Name = "Quản lý băng")]
		ImportData_Asset,
		[Display(Name = "Thêm sửa xoá")]
		ImportData_Asset_CRUD,

		[Display(Name = "Quản lý khách hàng")]
		ImportData_Customer,
		[Display(Name = "Thêm sửa xoá")]
		ImportData_Customer_CRUD,

		[Display(Name = "Quản lý chương trình")]
		ImportData_SponsorProgram,
		[Display(Name = "Thêm sửa xoá")]
		ImportData_SponsorProgram_CRUD,

		[Display(Name = "Quản lý phụ lục quảng cáo")]
		ImportData_NormalBooking,
		[Display(Name = "Thêm sửa xoá")]
		ImportData_NormalBooking_CRUD,

		[Display(Name = "Quản lý phụ lục tài trợ book ngoài")]
		ImportData_BookingIn,
		[Display(Name = "Thêm sửa xoá")]
		ImportData_BookingIn_CRUD,

		[Display(Name = "Quản lý phụ lục tài trợ book trong")]
		ImportData_BookingOut,
		[Display(Name = "Thêm sửa xoá")]
		ImportData_BookingOut_CRUD,

		[Display(Name = "Quản lý phát sóng quảng cáo")]
		ImportData_SpotBooking,
		[Display(Name = "Thêm sửa xoá phát sóng")]
		ImportData_SpotBooking_CRUD,
		[Display(Name = "Thêm sửa xoá băng")]
		ImportData_SpotBooking_AssetCRUD,

		[Display(Name = "Quản lý phát sóng tài trợ book ngoài")]
		ImportData_SpotBookingOut,
		[Display(Name = "Thêm sửa xoá phát sóng")]
		ImportData_SpotBookingOut_CRUD,
		[Display(Name = "Thêm sửa xoá băng")]
		ImportData_SpotBookingOut_AssetBookingCRUD,

		[Display(Name = "Quản lý phát sóng tài trợ book trong")]
		ImportData_SpotBookingIn,
		[Display(Name = "Thêm sửa xoá phát sóng")]
		ImportData_SpotBookingIn_CRUD,
		[Display(Name = "Thêm sửa xoá băng")]
		ImportData_SpotBookingIn_AssetBookingCRUD,

		[Display(Name = "Quản lý phát sóng thu lẻ")]
		ImportData_SpotBookingRetail,
		[Display(Name = "Thêm sửa xoá hợp đồng")]
		ImportData_SpotBookingRetail_ContractCRUD,
		[Display(Name = "Thêm sửa xoá phát sóng")]
		ImportData_SpotBookingRetail_CRUD,
		[Display(Name = "Thêm sửa xoá băng")]
		ImportData_SpotBookingRetail_AssetBookingCRUD,

		[Display(Name = "In chứng nhận phát sóng worlcup")]
		ImportData_PrintCertifiWorldCup,
		[Display(Name = "Được thay đổi in kèm vị trí")]
		ImportData_ChangePrintPostition,
		[Display(Name = "Được thay đổi in kèm *")]
		ImportData_ChangePrintSao,
		[Display(Name = "Được in ngày in")]
		ImportData_PrintCurrentDate,


		[Display(Name = "Sử dụng tổng hợp")]
		Report,

		[Display(Name = "Xem các phát sóng không duyệt")]
		Report_ViewNotApproveBooking,
		[Display(Name = "Huỷ các phát sóng không duyệt")]
		Report_ViewNotApproveBooking_Cancel,


		[Display(Name = "Duyệt phát sóng theo phụ lục")]
		Report_ApproveBookingByContractCode,
		[Display(Name = "Sắp xếp, ghi chú cắt")]
		Report_OrderNoteCuts,
		[Display(Name = "Tổng hợp,sửa giá TVC theo đơn giá")]
		Report_ReportEditTVCByPrice,
		[Display(Name = "Sửa nhanh tính tiền vị trí cho khách hàng")]
		Report_EditPositionCostForCustomer,
		[Display(Name = "Điều chỉnh áp dụng chính sách tăng giảm giá phát sóng")]
		Report_ManagerUpDownPrice,
		[Display(Name = "Theo dõi thời lượng phát sóng")]
		Report_DurationOnAir,


		[Display(Name = "Sử dụng kế toán")]
		Accounting,
		[Display(Name = "Cài đặt tỉ lệ chọn vị trí")]
		Accounting_SetPositionRate,
		[Display(Name = "Giảm giá khách hàng")]
		Accounting_CustomerDiscount,
		[Display(Name = "Giảm giá chương trình")]
		Accounting_SponsorProgramDiscount,
		[Display(Name = "Giảm giá phụ lục")]
		Accounting_AnnexContractDiscount,

		[Display(Name = "Sử dụng quản trị")]
		ManagerSystem,
		[Display(Name = "Quản lý block tính giá")]
		ManagerSystem_SpotBlock,
		[Display(Name = "Quản lý các kênh phát sóng")]
		ManagerSystem_Channel,
		[Display(Name = "Quản lý mã giờ phát sóng")]
		ManagerSystem_TimeBand,
		[Display(Name = "Quản lý đơn giá phát sóng")]
		ManagerSystem_TimeBandPrice,
		[Display(Name = "Check giá")]
		ManagerSystem_CheckPrice,
		[Display(Name = "Tính giá đặc biệt cho phụ lục")]
		ManagerSystem_SpecialPriceForContract,
		[Display(Name = "Giá theo ngày ký")]
		ManagerSystem_SpecialPriceForContract_BySignDate,
		[Display(Name = "Giá đặc biệt")]
		ManagerSystem_SpecialPriceForContract_Special,

		[Display(Name = "Tính giá đặc biệt quảng cáo")]
		ManagerSystem_SpecialPriceForBooking,
		[Display(Name = "Tính giá đặc biệt tài trợ")]
		ManagerSystem_SpecialPriceForSponsor,
		[Display(Name = "Quản lý thu lẻ")]
		ManagerSystem_RetaiBooking,
		[Display(Name = "Cài đặt in vị trí, in * phụ lục")]
		ManagerSystem_PrintSetting,


		[Display(Name = "Quyền khác")]
		Other,
		[Display(Name = "Copy file băng")]
		Other_CopyAsset,
		[Display(Name = "Ingest băng")]
		Other_IngestAsset,
		[Display(Name = "Check băng kỹ thuật")]
		Other_CheckTechicalAsset,
		[Display(Name = "Duyệt list phát sóng")]
		Other_ApprovePlaylist,
		[Display(Name = "Preview list")]
		Other_PreviewList,
		[Display(Name = "Print to tape")]
		Other_PrintToTape,
		[Display(Name = "Gửi TKC")]
		Other_SentToTKC,
		[Display(Name = "Duyệt list thu lẻ")]
		Other_ApproveRetailPlaylist,
		[Display(Name = "Check băng nội dung")]
		Other_CheckContentAsset,

		[Display(Name = "Quyền đặc biệt")]
		Special,
		[Display(Name = "Quyền không cho vào list")]
		Special_NotTakeToList,
		[Display(Name = "Quyền nhập book trong")]
		Special_ImportBookingIn,
		[Display(Name = "Thêm sửa xoá phát sóng đã phát sóng")]
		Special_ApprovedSpotCRUD,
		[Display(Name = "Thêm sửa xoá phát sóng vào cắt đã đầy")]
		Special_InsetSpotToFullCutCRUD,
		[Display(Name = "Đổi băng các phát sóng đã duyệt")]
		Special_ChangeAssetBookingApproved,
		[Display(Name = "Quyền sửa cách tính nhiều mã băng")]
		Special_ChangePriceTypeToManyAsset,


		[Display(Name = "Manager")]
        Manager,

        [Display(Name = "Manager user group")]
        Manager_UserGroup,
		[Display(Name = "List user group")]
		Manager_UserGroup_Access,
		[Display(Name = "Create user group")]
		Manager_UserGroup_Create,
		[Display(Name = "Edit user group")]
        Manager_UserGroup_Edit,
		[Display(Name = "Delete user group")]
		Manager_UserGroup_Delete,
		[Display(Name = "Set permission for user group")]
        Manager_UserGroup_SetPermission,

        [Display(Name = "Manager user")]
        Manager_User,
		[Display(Name = "List user")]
		Manager_User_Access,
		[Display(Name = "Create user")]
		Manager_User_Create,
		[Display(Name = "Edit user")]
		Manager_User_Edit,
		[Display(Name = "Delete user")]
		Manager_User_Delete,
		[Display(Name = "Set group for user")]
        Manager_User_SetUserGroup,
        [Display(Name = "Set permission for user")]
		Manager_User_SetPermission,

		[Display(Name = "Spot block")]
		Manager_SpotBlock,
		[Display(Name = "List all spot block")]
		Manager_SpotBlock_Access,
		[Display(Name = "Create spot block")]
		Manager_SpotBlock_Create,
		[Display(Name = "Edit spot block")]
		Manager_SpotBlock_Edit,
		[Display(Name = "Delete spot block")]
		Manager_SpotBlock_Delete,





	}

	public static class UserPermissionExtensions
    {
        public static void RegisterAll(TVAdContext context)
        {
            Dictionary<string, string> permissions = new Dictionary<string, string>();
            foreach (UserPermissions permission in Enum.GetValues(typeof(UserPermissions)))
            {
                permissions.Add(permission.ToString(), permission.GetDisplayName());
            }

            // Get all permission in db
            var pType = PermissionTypeEnum.UserPermission.ToString();
            var dbPermissions = context.Security_Permissions.Where(p => p.Type == pType).ToList();
            context.Security_Permissions.RemoveRange(dbPermissions.Where(p => !permissions.ContainsKey(p.Value)));
            context.SaveChanges();

            // Add or update permission
            Dictionary<string, int> indexs = new Dictionary<string, int>();
            foreach (var permission in permissions)
            {
                var parentName = "";
                var lastIndex = permission.Key.LastIndexOf('_');
                if (lastIndex >= 0)
                    parentName = permission.Key.Substring(0, lastIndex);

                var permissionOld = context.Security_Permissions
                    .Where(p => p.Type == pType && p.Value == permission.Key)
                    .Include(p => p.Parent)
                    .FirstOrDefault();

                var index = 0;
                if (indexs.ContainsKey(parentName))
                    index = indexs[parentName] + 1;
                if (indexs.ContainsKey(parentName))
                    indexs.Remove(parentName);
                indexs.Add(parentName, index);
                if (permissionOld == null)
                {
                    context.Security_Permissions.Add(new Entities.Entities.Security.Permission()
                    {
                        Type = PermissionTypeEnum.UserPermission.ToString(),
                        Value = permission.Key,
                        DisplayName = permission.Value,
                        Parent = parentName == "" ? null : context.Security_Permissions.Local.FirstOrDefault(p => p.Type == pType && p.Value == parentName),
                        Index = index
                    });
                }
                else if (permissionOld.DisplayName != permission.Value
                    || (parentName == "" && permissionOld.Parent != null)
                    || (parentName != "" && (permissionOld.Parent == null || permissionOld.Parent.Value != parentName))
                    || permissionOld.Index != index)
                {
                    permissionOld.DisplayName = permission.Value;
                    permissionOld.Parent = parentName == "" ? null : context.Security_Permissions.Local.FirstOrDefault(g => g.Type == PermissionTypeEnum.UserPermission.ToString() && g.Value == parentName);
                    permissionOld.Index = index;
                }
            }
            context.SaveChanges();

            #region Set full quyền cho root
            var rootGroup = context.Security_Groups.Where(g => g.ParentId == null).Include(g => g.Group_Permissions).First();

            var pids = rootGroup.Group_Permissions.Select(p => p.PermissionId).ToList();
            var permissionMiss = context.Security_Permissions
                .Where(p => p.Type == pType)
                .Where(p => !pids.Contains(p.Id))
                .ToList();
            if (permissionMiss.Count > 0)
            {
                foreach (var permission in permissionMiss)
                    rootGroup.Group_Permissions.Add(new Group_Permission()
                    {
                        Group = rootGroup,
                        Permission = permission
                    });
                context.SaveChanges();
            }
            #endregion
        }
    }
}
