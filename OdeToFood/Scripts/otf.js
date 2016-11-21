$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);

        var option = {
            url: $form.att("action"),
            type: $form.att("method"),
            data: $form.serialize()
        }

        $.ajax(option).done(function (data) {
            var $target = $($form.att("data-otf-target"));
            $target.replaceWith(data);
        });
        return false;
    }

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
})