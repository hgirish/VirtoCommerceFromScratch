VirtoCommerce = function() {
    this.Stores = [];
    this.DynamicContent = {};
};
VirtoCommerce.prototype.constructor = VirtoCommerce.prototype;

VirtoCommerce.prototype = {
    initialize: function() {
        
    },
    setCookie: function(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toGMTString();
        var path = "path=/";
        document.cookie = cname + "=" + cvalue + "; " + expires + "; " + path;
    },
    getCookie: function(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i].trim();
            if (c.indexOf(name) === 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }
}

var VirtoCommerce = new VirtoCommerce();