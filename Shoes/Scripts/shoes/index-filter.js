$(document).ready(function () {
    $(".dropdowns-filter").change(function () {
        $(".dropdowns-filter").removeClass("active");
        var typeName = $(this).data("type");
        var type = $("." + typeName);
        var first = $(this).find("option:first-child").val();
        var selectedId = $(this).val();

        var otherFilters = $(".dropdowns-filter:not([data-type=" + typeName + "])");
        otherFilters.find("option").removeAttr('selected');
        otherFilters.find("option:first").attr('selected', 'selected');
        if (selectedId == first) {
            type.parent().show();
        } else {
            $(this).addClass("active");
            type.parent().hide();
            $("." + typeName + "[value=" + selectedId + "]").parent().show();
        }

        var selectedCount = $(".shoes-block:visible ").length;
        $("#selectedCount").text(selectedCount + "/");
    });

    $("#refresh").click(function () {
        $(".dropdowns-filter").removeClass("active");
        var filters = $(".dropdowns-filter");
        filters.find("option").removeAttr('selected');
        filters.find("option:first").attr('selected', 'selected');
        $(".shoes-block").show();

        var selectedCount = $(".shoes-block:visible ").length;
        $("#selectedCount").text(selectedCount + "/");
    });

    $(".size").click(function () {
        $(".size").removeClass("active");
        $(this).addClass("active");
        var type = $(this).attr("id");
        switch (type) {
            case "small":
                clear();
                $(".shoes-block").addClass("col-sm-3");
                break;
            case "medium":
                clear();
                $(".shoes-block").addClass("col-sm-4");
                break;
            case "big":
                clear();
                $(".shoes-block").addClass("col-sm-6");
                break;
            case "full":
                clear();
                $(".shoes-block").addClass("col-sm-12");
                break;
        }
    });

    function clear() {
        $(".shoes-block").removeClass("col-sm-3");
        $(".shoes-block").removeClass("col-sm-4");
        $(".shoes-block").removeClass("col-sm-6");
        $(".shoes-block").removeClass("col-sm-12");
    }
});