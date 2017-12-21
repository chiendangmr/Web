using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Infrastructure.Identity
{
    /// <summary>
    /// Định nghĩa các quyền
    /// </summary>
    public enum PermissionActionType : int
    {
        /// <summary>
        /// Không có quyền
        /// </summary>
        None = 0,
        /// <summary>
        /// Toàn quyền
        /// </summary>
        Full = 1,
        /// <summary>
        /// Quyền được truy cập
        /// </summary>
        View = 2,
        /// <summary>
        /// Quyền được tạo mới
        /// </summary>
        Create = 3,
        /// <summary>
        /// Quyền được sửa
        /// </summary>
        Edit = 4,
        /// <summary>
        /// Quyền được xóa
        /// </summary>
        Delete = 5,
        /// <summary>
        /// Quyền được upload
        /// </summary>
        Upload = 6,
        /// <summary>
        /// Quyền được download
        /// </summary>
        Download = 7
    }
}
