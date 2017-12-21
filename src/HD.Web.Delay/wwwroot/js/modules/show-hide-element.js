define(['jquery'], function ($) {

    var obj = {
        configs: {
            iconUrl: "/images/arrowright.png",            
            id: "arrow"
        },
        init: function (configs) {
            var _this = obj;
            $.extend(_this.configs, configs);
            _this.toggle(_this.configs);
        },
        toggle: function (configs) {
            var el = document.getElementById(configs.id);
            var box = el.getAttribute("class");
            console.log(box);
            if (box.includes("hiden")) {               
                $(".need-show-hide").hide();                
                $("#" + configs.id).removeClass("hiden");
                $("#" + configs.id).addClass("show");                
            }
            else {                
                $(".need-show-hide").show();                
                $("#" + configs.id).removeClass("show");
                $("#" + configs.id).addClass("hiden");                
            }
        },

        delay: function (elem, src, delayTime) {
            window.setTimeout(function () { elem.setAttribute("src", src); }, delayTime);
        }
    }
    return {
        init: obj.init,
    }
});
