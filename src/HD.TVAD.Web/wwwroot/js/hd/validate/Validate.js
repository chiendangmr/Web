define(['jquery', 'jquery.validate', 'jquery.validate.unobtrusive'], function ()
{
    $.validator.addMethod("requiredifenabled",
            function (value, element, params)
            {
                var name = $(element).attr("name");
                var otherName = typeof params.field != "undefined" && params.field != "" ? params.field : "Enabled";
                otherName = name.replace(/([^\.^\n]+)$/, otherName);
                otherName = otherName.replace(/[\\\\]*[\.]/g, "\\.");
                var otherVal = undefined;
                $("input[name=" + otherName + "]").each(function (i)
                {
                    var type = $(this).attr("type");
                    if ((typeof type == "undefined" && typeof otherVal == "undefined")
                        || (typeof type != "undefined" && type == "checkbox" && $(this).is(":checked")))
                    {
                        otherVal = $(this).val();
                    }
                });
                if (typeof otherVal!="undefined")
                {                    
                    try{
                        var neededValue = typeof params.value != "undefined" ? params.value : "true";                        
                        if (JSON.parse(otherVal) == JSON.parse(neededValue))
                        {
                            return value != "";
                        }
                    } catch (e)
                    {
                        return false;
                    }
                }
                return true;
            });

    $.validator.unobtrusive.adapters.add("requiredifenabled", ["field", "value"], function (options)
    {
        setValidationValues(options, "requiredifenabled", options.params);
    });
    function setValidationValues(options, ruleName, value)
    {
        options.rules[ruleName] = value;
        if (options.message)
        {
            options.messages[ruleName] = options.message;
        }
    }
    $("form").removeData("unobtrusiveValidation").removeData("validator");
    $.validator.unobtrusive.parse("form");
    return {};
});