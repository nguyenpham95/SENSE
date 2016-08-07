$(function () {
    $("#bm_btn_labFunc").on("click", function (event) {
        event.preventDefault();
        $(".bm_tab, .bm_tab_active").css({ "background-color": "White", "color": "rgb(161,161,161" });
        $(this).css({ "background-color": "rgb(124,197,118)", "color": "White" });
        $("#context1, #context2, #context3").css({ "display": "none", "margin-top": "20px", "opacity": "0" });
        $("#context1").css("display", "block").animate({ "margin-top": "0px", "opacity": "1" }, 400);
    });
    $("#bm_btn_p4").on("click", function (event) {
        event.preventDefault();
        $(".bm_tab, .bm_tab_active").css({ "background-color": "White", "color": "rgb(161,161,161" });
        $(this).css({ "background-color": "rgb(124,197,118)", "color": "White" });
        $("#context1, #context2, #context3").css({ "display": "none", "margin-top": "20px", "opacity": "0" });
        $("#context2").css("display", "block").animate({ "margin-top": "0px", "opacity": "1" }, 400);
    });
    $("#bm_btn_wearable").on("click", function (event) {
        event.preventDefault();
        $(".bm_tab, .bm_tab_active").css({ "background-color": "White", "color": "rgb(161,161,161" });
        $(this).css({ "background-color": "rgb(124,197,118)", "color": "White" });
        $("#context1, #context2, #context3").css({ "display": "none", "margin-top": "20px", "opacity": "0" });
        $("#context3").css("display", "block").animate({ "margin-top": "0px", "opacity": "1" }, 400);
    });
});