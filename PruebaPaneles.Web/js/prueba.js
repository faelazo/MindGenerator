jQuery(document).ready(function () {

    jQuery('#tabs').tabs();

    jQuery('#exit').dialog({
        modal: true,
        resizable: false,
        width: 300,
        autoOpen: false,
        buttons: {
            Ok: function () {

                jQuery(location).attr("href", "login.htm");
            },
            Cancel: function () {

                jQuery(this).dialog("close");
            }
        }
    });

    jQuery('#btLogout').button();

    jQuery('#btLogout').click(function () {
        
        jQuery('#exit').dialog("open");
    });

    

});

function pintar() {
    alert('Si entra');
    jQuery('#lbUser').css("background-color", "red");
}