using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Infrastructure.Identity
{
    /// <summary>
    /// Bảng chứa mã các quyền trên hệ thống
    /// </summary>
    public enum ModuleType : int
    {
        None = 0,
        /// <summary>
        /// Quyền truy cập vào toàn bộ phần mềm
        /// </summary>
        Application = 1,
        /// <summary>
        /// Quyền truy cập vào các chức năng hệ thống
        /// </summary>
        Administrator = 2,
        /// <summary>
        /// Quản lý nhóm tài khoản
        /// </summary>
        UserGroup = 3,
        /// <summary>
        /// Phân quyền cho nhóm tài khoản
        /// </summary>
        Permission = 4,
        /// <summary>
        /// Quản lý tài khoản
        /// </summary>
        User = 5,
        /// <summary>
        /// Quản lý asset
        /// </summary>
        Asset = 6,
        /// <summary>
        /// Duyệt nội dung của asset
        /// </summary>
        ApproveContentAsset = 7,
        /// <summary>
        /// Duyệt chất lượng của asset
        /// </summary>
        ApproveQualityAsset = 8,
        /// <summary>
        /// Quản lý file highres của asset
        /// </summary>
        MediaHighres = 9,
        /// <summary>
        /// Quản lý nhà sản xuất
        /// </summary>
        Producer = 10,
        /// <summary>
        /// Quản lý đơn vị đăng ký clip
        /// </summary>
        Register = 11,
        /// <summary>
        /// Quản lý nhóm sản phẩm
        /// </summary>
        ProductGroup = 12,
        /// <summary>
        /// Quản lý storage
        /// </summary>
        StorageLocation = 13
    }
}
