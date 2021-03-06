define(['jquery', 'js.cookie', 'toolkit', 'jquery.validate', 'jquery.validate.unobtrusive', 'blockUI'], function ($, Cookies) {
    var validatorOptions = {
        validClass: 'has-success',
        errorClass: 'has-error',
        highlight: function (element, errorClass, validClass) {
            $(element).closest(".form-group")
                .removeClass(validClass)
                .addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest(".form-group")
                .removeClass('has-error')
                .addClass(validClass);
        }
    };
    $.validator.setDefaults(validatorOptions);
    $.validator.unobtrusive.options = {
        errorClass: validatorOptions.errorClass,
        validClass: validatorOptions.validClass,
    };
    $(function () {
        $("a[data-language").click(function (e) {
            e.preventDefault();
            var lang = $(this).data("language");
            var cookie = $.validator.format("c={0}|uic={0}", lang);
            Cookies.set(".AspNetCore.Culture", cookie, { path: '/' });
            window.location.reload();
        });
    });

    window._enableBlockUI = true;
    $.blockUI.defaults.fadeOut = 200;
    $(document).ajaxStart(function(){
    	if (window._enableBlockUI)
    		$.blockUI()
    }).ajaxStop(function(){
    	if (window._enableBlockUI)
    		$.unblockUI()
    });
});
//# sourceMappingURL=hd.js.map