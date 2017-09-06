$("#modalid").css({
    display: 'block'
});

$(".disabledbutton").css({
    "background-color": "#d9d9d9",
    color: "#737373"
});

function submitnickname() {
    nickname = $("#nickname").val();
    console.log("nickname set to " + nickname);

    $(".setnickname").css({ display: "none" });
    $(".chooseroomdiv").css({ display: "block" });
};


function publicroomchosen() {

    $(".chooseroomdiv").css({ display: "none" });
    $(".choosecreateorjoindiv").css({ display: "block" });
}

function choosegame() {
    $(".choosecreateorjoindiv").css({ display: "none" });
    $(".choosegamediv").css({ display: "block" });


}