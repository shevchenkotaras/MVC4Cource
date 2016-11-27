//$(function () {
//    var ajaxFormSubmit = function () {
//        var $form = $(this);

//        var option = {
//            url: $form.att("action"),
//            type: $form.att("method"),
//            data: $form.serialize()
//        }

//        $.ajax(option).done(function (data) {
//            var $target = $($form.att("data-otf-target"));
//            $target.replaceWith(data);
//        });
//        return false;
//    }

//    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
//})

$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        }

        $.ajax(option).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            $target.replaceWith(data);
        });
        return false;
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomplete")
        };

        $input.autocomplete(options);
    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);
});